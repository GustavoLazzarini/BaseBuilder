//Made by Galactspace

using System;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;

namespace Core.Editor.Toolbar
{
    [InitializeOnLoad]
    public static class GEITBScene
    {
        private const float WIDTH = 120;

        private static int selected = 0;
        private static int lastSelected = 0;

        private static string[] options;
        private static SceneAsset[] scenes;

        private static GUIStyle popupStyle;

        static GEITBScene()
        {
            GEITB.LeftToolbarGUI.Add(OnToolbarGUI);
        }

        private static void LoadScenes()
        {
            int count = SceneManager.sceneCountInBuildSettings;
            scenes = new SceneAsset[count];

            for (int i = 0; i < count; i++)
                scenes[i] = (SceneAsset)AssetDatabase.LoadAssetAtPath(SceneUtility.GetScenePathByBuildIndex(i), typeof(SceneAsset));
            
            options = new string[scenes.Length];
            RefreshNames();

            SelectCurrent();
        }
        private static void RefreshNames()
        {
            for (int i = 0; i < options.Length; i++)
            {
                string val = GetSceneName(SceneUtility.GetScenePathByBuildIndex(i));
                
                for (int c = 1; c < val.Length; c++)
                {
                    if (char.IsUpper(val[c]) && val[c - 1] != ' ')
                    {
                        val = val.Insert(c, " ");
                        c++;
                    }
                }

                options[i] = val;
            }
        }
        private static string GetSceneName(string path)
        {
            string val = path;
            val = val[(val.LastIndexOf('/') + 1)..];
            val = val[..val.LastIndexOf('.')];
            return val;
        }

        private static void SelectCurrent()
        {
            string cName = SceneManager.GetActiveScene().name;
            for (int i = 0; i < scenes.Length; i++)
            {
                if (scenes[i].name == cName)
                {
                    selected = i;
                    lastSelected = selected;
                    break;
                }
            }
        }

        private static void OnToolbarGUI()
        {
            GUILayout.FlexibleSpace();

            if (scenes == null || scenes.Length != EditorBuildSettings.scenes.Length)
                LoadScenes();

            if (selected == -1) SelectCurrent();

            for (int i = 0; i < options.Length; i++)
            {
                if (GetSceneName(SceneUtility.GetScenePathByBuildIndex(i)).Replace(" ", "") != options[i].Replace(" ", ""))
                {
                    RefreshNames();
                    break;
                }
            }

            if (popupStyle == null)
            {
                popupStyle = EditorStyles.popup;
                popupStyle.alignment = TextAnchor.MiddleCenter;
            }

            selected = EditorGUILayout.Popup(selected, options, popupStyle, GUILayout.Width(WIDTH));
            
            if (selected != lastSelected)
            {
                Open(selected);
                lastSelected = selected;
            }
        }
        
        private static void Open(int index)
        {
            if (index >= scenes.Length || index < 0)
                throw new ArgumentOutOfRangeException(nameof(index));

            EditorSceneManager.OpenScene(SceneUtility.GetScenePathByBuildIndex(index));
        }
    }
}