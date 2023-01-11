using System;
using UnityEditor;
using UnityEngine;
using System.Reflection;
using System.Collections.Generic;

using UEditor = UnityEditor.Editor;
using UScriptable = UnityEngine.ScriptableObject;
using UnityEngine.UIElements;

namespace Core.Editor.Toolbar
{
	[InitializeOnLoad]
	public static class GEITB
	{
		static int m_toolCount;
		static GUIStyle m_commandStyle = null;

		static Type m_toolbarType = typeof(UEditor).Assembly.GetType("UnityEditor.Toolbar");

		static UScriptable m_currentToolbar;

		public static Action OnToolbarGUI;
		public static Action OnToolbarGUILeft;
		public static Action OnToolbarGUIRight;

		public const float space = 8;
		public const float largeSpace = 20;
		public const float buttonWidth = 32;
		public const float dropdownWidth = 80;
		public const float playPauseStopWidth = 140;

		public static readonly List<Action> LeftToolbarGUI = new List<Action>();
		public static readonly List<Action> RightToolbarGUI = new List<Action>();

		static GEITB()
		{
			FieldInfo toolIcons = m_toolbarType.GetField("k_ToolCount",
				BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);

			m_toolCount = toolIcons != null ? ((int)toolIcons.GetValue(null)) : 8;

			OnToolbarGUI = OnGUI;
			OnToolbarGUILeft = GUILeft;
			OnToolbarGUIRight = GUIRight;

			EditorApplication.update -= OnUpdate;
			EditorApplication.update += OnUpdate;
		}

		static void OnGUI()
		{
			// Create two containers, left and right
			// Screen is whole toolbar

			if (m_commandStyle == null)
			{
				m_commandStyle = new GUIStyle("CommandLeft");
			}

			var screenWidth = EditorGUIUtility.currentViewWidth;

			// Following calculations match code reflected from Toolbar.OldOnGUI()
			float playButtonsPosition = Mathf.RoundToInt ((screenWidth - playPauseStopWidth) / 2);

			Rect leftRect = new Rect(0, 0, screenWidth, Screen.height);
			leftRect.xMin += space; // Spacing left
			leftRect.xMin += buttonWidth * m_toolCount; // Tool buttons
			leftRect.xMin += space; // Spacing between tools and pivot
			leftRect.xMin += 64 * 2; // Pivot buttons
			leftRect.xMax = playButtonsPosition;

			Rect rightRect = new Rect(0, 0, screenWidth, Screen.height);
			rightRect.xMin = playButtonsPosition;
			rightRect.xMin += m_commandStyle.fixedWidth * 3; // Play buttons
			rightRect.xMax = screenWidth;
			rightRect.xMax -= space; // Spacing right
			rightRect.xMax -= dropdownWidth; // Layout
			rightRect.xMax -= space; // Spacing between layout and layers
			rightRect.xMax -= dropdownWidth; // Layers
			rightRect.xMax -= space; // Spacing between layers and account
			rightRect.xMax -= dropdownWidth; // Account
			rightRect.xMax -= space; // Spacing between account and cloud
			rightRect.xMax -= buttonWidth; // Cloud
			rightRect.xMax -= space; // Spacing between cloud and collab
			rightRect.xMax -= 78; // Colab

			// Add spacing around existing controls
			leftRect.xMin += space;
			leftRect.xMax -= space;
			rightRect.xMin += space;
			rightRect.xMax -= space;

			// Add top and bottom margins
			leftRect.y = 4;
			leftRect.height = 22;
			rightRect.y = 4;
			rightRect.height = 22;

			if (leftRect.width > 0)
			{
				GUILayout.BeginArea(leftRect);
				GUILayout.BeginHorizontal();
				foreach (var handler in LeftToolbarGUI)
				{
					handler();
				}

				GUILayout.EndHorizontal();
				GUILayout.EndArea();
			}

			if (rightRect.width > 0)
			{
				GUILayout.BeginArea(rightRect);
				GUILayout.BeginHorizontal();
				foreach (var handler in RightToolbarGUI)
				{
					handler();
				}

				GUILayout.EndHorizontal();
				GUILayout.EndArea();
			}
		}
		
		public static void GUILeft() {
			GUILayout.BeginHorizontal();
			foreach (var handler in LeftToolbarGUI)
			{
				handler();
			}
			GUILayout.EndHorizontal();
		}
		
		public static void GUIRight() {
			GUILayout.BeginHorizontal();
			foreach (var handler in RightToolbarGUI)
			{
				handler();
			}
			GUILayout.EndHorizontal();
		}

		static void OnUpdate()
		{
			// Relying on the fact that toolbar is ScriptableObject and gets deleted when layout changes
			if (m_currentToolbar == null)
			{
				// Find toolbar
				var toolbars = Resources.FindObjectsOfTypeAll(m_toolbarType);
				m_currentToolbar = toolbars.Length > 0 ? (UScriptable)toolbars[0] : null;
				if (m_currentToolbar != null)
				{
					var root = m_currentToolbar.GetType().GetField("m_Root", BindingFlags.NonPublic | BindingFlags.Instance);
					var rawRoot = root.GetValue(m_currentToolbar);
					var mRoot = rawRoot as VisualElement;
					RegisterCallback("ToolbarZoneLeftAlign", OnToolbarGUILeft);
					RegisterCallback("ToolbarZoneRightAlign", OnToolbarGUIRight);

					void RegisterCallback(string root, Action cb)
					{
						var toolbarZone = mRoot.Q(root);

						var parent = new VisualElement()
						{
							style = {
								flexGrow = 1,
								flexDirection = FlexDirection.Row,
							}
						};
						var container = new IMGUIContainer();
						container.style.flexGrow = 1;
						container.onGUIHandler += () => {
							cb?.Invoke();
						};

						parent.Add(container);
						toolbarZone.Add(parent);
					}
				}
			}
		}
	}
}
