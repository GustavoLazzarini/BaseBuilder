//Created by Galactspace

using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using System.Collections.Generic;

using UEditor = UnityEditor.Editor;

namespace Core.Editor
{
    public class SEditor : EditorWindow
    {
        private string _lastSearch;

        private ListView _leftList;
        private ListView _rightList;

        private TextField _searchBox;

        private TwoPaneSplitView _mainTab;
        private TwoPaneSplitView _mainRight;

        private VisualElement _search;
        private VisualElement _mainLeft;
        private VisualElement _inspector;
        private VisualElement _configuration;

        private List<string> _desiredTypes;
        private List<string> _existingTypes;
        private List<ScriptableObject> _scriptables;
        private Dictionary<string, List<ScriptableObject>> _types;


        [MenuItem("Tools/SEditor")]
        static void Init()
        {
            SEditor editor = GetWindow<SEditor>();
            var icon = EditorGUIUtility.IconContent("d_ScriptableObject On Icon");
            editor.titleContent = new GUIContent("SEditor", icon.image);
            editor.Show();
        }

        private void CreateGUI()
        {
            _types = new();
            _scriptables = new();
            _existingTypes = new();
            _desiredTypes = new() { "ScriptableObject" };

            string searchQuery = "";
            foreach (string t in _desiredTypes) searchQuery += $"t:{t} ";

            _mainTab = new(0, 250, TwoPaneSplitViewOrientation.Horizontal);
            _configuration = new();

            _mainLeft = new();

            _leftList = new();
            _leftList.makeItem = () => new Label();
            _leftList.onSelectionChange += SelectType;
            _leftList.bindItem = (item, index) =>
            {
                Label l = (Label)item;
                l.text = $"   {_leftList.itemsSource[index]}";
                l.style.unityTextAlign = new StyleEnum<TextAnchor>(TextAnchor.MiddleLeft);
            };

            _mainRight = new(0, 250, TwoPaneSplitViewOrientation.Horizontal);

            _rightList = new();
            _rightList.makeItem = () => new Label();
            _rightList.onSelectionChange += SelectObject;
            _rightList.bindItem = (item, index) =>
            {
                Label l = (Label)item;
                l.text = $"   {(_rightList.itemsSource[index] as ScriptableObject).name}";
                l.style.unityTextAlign = new StyleEnum<TextAnchor>(TextAnchor.MiddleLeft);
            };

            _inspector = new();

            _search = GEI.Element(Vector4.zero, new Vector4(3, 3));
            _searchBox = new();
            _searchBox.RegisterCallback<KeyDownEvent>(OnSearchValueChanged);
            _searchBox.RegisterCallback<BlurEvent>(OnSearchBlur);

            _mainTab.style.display = new(DisplayStyle.Flex);
            _configuration.style.display = new(DisplayStyle.None);

            _search.Add(_searchBox);

            _mainLeft.AddRange(_search, _leftList);
            _mainTab.AddRange(_mainLeft, _mainRight);
            _mainRight.AddRange(_rightList, _inspector);

            rootVisualElement.AddRange(_mainTab, _configuration);

            Search(searchQuery);
            _leftList.selectedIndex = 0;
        }

        private void SelectType(IEnumerable<object> itens)
        {
            _rightList.Clear();

            _rightList.itemsSource = _types[itens.First() as string];
            _rightList.Rebuild();

            _rightList.selectedIndex = 0;
        }

        private void SelectObject(IEnumerable<object> itens)
        {
            ScriptableObject scriptable = itens.First() as ScriptableObject;

            if (_mainRight.Contains(_inspector)) _mainRight.Remove(_inspector);

            _inspector = UEditor.CreateEditor(scriptable).CreateInspectorGUI();

            if (_inspector == null)
            {
                IMGUIContainer gui = new();
                VisualElement box = GEI.Box("", null, border: new Color(1, 1, 1, 0.4f));

                gui.onGUIHandler = UEditor.CreateEditor(scriptable).OnInspectorGUI;

                _inspector = GEI.Box($"{scriptable.name} ({scriptable.GetType().Name})", color: Color.clear);
                _inspector.Grow(1);

                box.Add(gui);
                _inspector.Add(box);
            } //GEI.CreateInspector(new SerializedObject(scriptable), true);
            else _inspector.Bind(new SerializedObject(scriptable));
            
            _inspector.Grow(1);

            _inspector.style.marginLeft = 10;
            _inspector.style.marginRight = 10;

            _inspector.style.paddingBottom = 10;

            _mainRight.Add(_inspector);
        }

        private void OnSearchValueChanged(KeyDownEvent value)
        {
            if (value.keyCode == KeyCode.Return) Search(_searchBox.value);
        }

        private void OnSearchBlur(BlurEvent value)
        {
            if (_lastSearch == _searchBox.value) return;
            Search(_searchBox.value);
        }

        private void Search(string search = "t:ScriptableObject")
        {
            if (string.IsNullOrEmpty(search)) search = "t:ScriptableObject";

            _lastSearch = search;

            string[] guids = AssetDatabase.FindAssets(search);

            _types.Clear();
            _leftList.Clear();
            _rightList.Clear();
            _scriptables.Clear();
            if (_mainRight.Contains(_inspector)) _mainRight.Remove(_inspector);

            foreach (string guid in guids)
            {
                ScriptableObject scriptable = AssetDatabase.LoadAssetAtPath<ScriptableObject>(AssetDatabase.GUIDToAssetPath(guid));

                if (scriptable == null) continue;

                string[] exclude = { "UnityEngine", "UnityEditor", "TMPro" };

                string namespaceName = scriptable.GetType().Namespace;
                if (namespaceName != null)
                {
                    bool continueSearch = false;

                    for (int i = 0; i < exclude.Length; i++)
                        if (namespaceName.Contains(exclude[i]))
                        {
                            continueSearch = true;
                            break;
                        }

                    if (continueSearch) continue;
                }

                _scriptables.Add(scriptable);

                string typeName = scriptable.GetType().Name;
                if (!_types.ContainsKey(typeName))
                {
                    _types.Add(typeName, new List<ScriptableObject> { scriptable });
                    _existingTypes.Add(typeName);
                }
                else _types[typeName].Add(scriptable);
            }

            if (_scriptables.Count == 0)
            {
                _leftList.itemsSource = default;
                _rightList.itemsSource = default;

                _leftList.Rebuild();
                _rightList.Rebuild();
                return;
            }

            _leftList.itemsSource = _types.Keys.ToArray();
            _leftList.Rebuild();

            _leftList.selectedIndex = 0;
        }
    }
}