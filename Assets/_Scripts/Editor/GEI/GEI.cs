//Created by Galactspace

using UnityEditor;
using UnityEngine;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Core.Editor
{
    public static class GEI
    {
        public static VisualElement CreateInspector(SerializedObject serializedObject, bool hideScript)
        {
            ScrollView e = new();
            
            VisualElement value = new();
            value.style.paddingTop = 10;
            value.style.paddingBottom = 10;
            value.style.paddingLeft = 10;
            value.style.paddingRight = 10;

            e.style.flexGrow = 1;

            VisualElement objTitle = Title($"{serializedObject.targetObject.name} ({serializedObject.targetObject.GetType().Name})");
            value.Add(objTitle);
            e.Add(value);

            SerializedProperty property = serializedObject.GetIterator();
            if (property.NextVisible(true)) // Expand first child.
            {
                do
                {
                    if (property.propertyPath == "m_Script" && hideScript)
                    {
                        continue;
                    }
                    var field = new PropertyField(property, property.displayName);
                    field.name = "PropertyField:" + property.propertyPath;

                    if (property.propertyPath == "m_Script" && serializedObject.targetObject != null)
                    {
                        field.SetEnabled(false);
                    }

                    value.Add(field);
                    value.Bind(serializedObject);
                }
                while (property.NextVisible(false));
            }

            return e;
        }

        public static VisualElement Property(SerializedProperty property, string customName = null, bool space = false)
        {
            PropertyField field = new(property, string.IsNullOrEmpty(customName) ? property.displayName : customName);
            field.name = "PropertyField:" + property.propertyPath;
            if (space) field.style.marginTop = 10;
            return field;
        }

        public static VisualElement Property(string property, SerializedObject obj, string customName = null, bool space = false)
        {
            SerializedProperty prop = obj.FindProperty(property);
            PropertyField field = new(prop, string.IsNullOrEmpty(customName) ? prop.displayName : customName);
            field.name = "PropertyField:" + prop.propertyPath;
            if (space) field.style.marginTop = 10;
            return field;
        }

        public static void AddProp(VisualElement holder, SerializedProperty property, string customName = null)
        {
            PropertyField field = new(property, string.IsNullOrEmpty(customName) ? property.displayName : customName);
            field.name = "PropertyField:" + property.propertyPath;

            holder.Add(field);
            holder.Bind(property.serializedObject);
        }

        public static void AddProps(VisualElement holder, params SerializedProperty[] properties)
        {
            foreach (var property in properties)
            {
                PropertyField field = new(property, property.displayName);
                field.name = "PropertyField:" + property.propertyPath;

                holder.Add(field);
                holder.Bind(property.serializedObject);
            }
        }

        public static VisualElement Title(string title, int fontSize = 20, Vector4? margin = null, Vector4? padding = null, float borderRadius = 5, Color? background = null)
        {
            Label objTitle = new();
            objTitle.text = $"{title}";

            margin ??= new Vector4(10, 10, 0, 0);
            objTitle.style.marginTop = margin.Value.x;
            objTitle.style.marginBottom = margin.Value.y;
            objTitle.style.marginLeft = new StyleLength(StyleKeyword.Auto);
            objTitle.style.marginRight = new StyleLength(StyleKeyword.Auto);

            objTitle.style.backgroundColor = background ??= new Color(0, 0, 0, 0.15f);

            padding ??= new Vector4(10, 10, 10, 10);
            objTitle.style.paddingTop = padding.Value.x;
            objTitle.style.paddingBottom = padding.Value.y;
            objTitle.style.paddingLeft = padding.Value.z;
            objTitle.style.paddingRight = padding.Value.w;

            objTitle.style.borderTopLeftRadius = borderRadius;
            objTitle.style.borderTopRightRadius = borderRadius;
            objTitle.style.borderBottomLeftRadius = borderRadius;
            objTitle.style.borderBottomRightRadius = borderRadius;

            objTitle.style.fontSize = fontSize;
            return objTitle;
        }

        public static VisualElement Box(string title, Color? color, params VisualElement[] elements)
        {
            VisualElement holder = new();
            holder.style.backgroundColor = color ?? new Color(0, 0, 0, 0.15f);
            holder.style.marginTop = 10;
            holder.style.paddingTop = 10;
            holder.style.paddingBottom = 10;
            holder.style.paddingLeft = 10;
            holder.style.paddingRight = 10;
            holder.style.borderTopLeftRadius = 5;
            holder.style.borderTopRightRadius = 5;
            holder.style.borderBottomLeftRadius = 5;
            holder.style.borderBottomRightRadius = 5;

            if (!string.IsNullOrEmpty(title)) holder.Add(Title(title, 15, new Vector4(3, 3), new Vector4(5, 5, 5, 5), 5, Color.clear));
            if (elements.Length > 0) holder.AddRange(elements);

            return holder;
        }

        public static VisualElement Box(string title, Color? color, Color? border, bool topMargin = true, params VisualElement[] elements)
        {
            VisualElement holder = new();
            holder.style.backgroundColor = color ?? new Color(0, 0, 0, 0.15f);

            holder.style.borderTopWidth = 1;
            holder.style.borderBottomWidth = 1;
            holder.style.borderLeftWidth = 1;
            holder.style.borderRightWidth = 1;

            holder.style.borderTopColor = border ?? new Color(0, 0, 0, 0);
            holder.style.borderBottomColor = border ?? new Color(0, 0, 0, 0);
            holder.style.borderLeftColor = border ?? new Color(0, 0, 0, 0);
            holder.style.borderRightColor = border ?? new Color(0, 0, 0, 0);

            holder.style.marginTop = topMargin ? 10 : 0;
            holder.style.paddingTop = 10;
            holder.style.paddingBottom = 10;
            holder.style.paddingLeft = 10;
            holder.style.paddingRight = 10;
            holder.style.borderTopLeftRadius = 5;
            holder.style.borderTopRightRadius = 5;
            holder.style.borderBottomLeftRadius = 5;
            holder.style.borderBottomRightRadius = 5;

            if (!string.IsNullOrEmpty(title)) holder.Add(Title(title, 15, new Vector4(3, 3), new Vector4(5, 5, 5, 5), 5, Color.clear));
            if (elements.Length > 0) holder.AddRange(elements);

            return holder;
        }

        public static VisualElement Box(string title, params VisualElement[] elements)
        {
            VisualElement holder = new();
            holder.style.backgroundColor = new Color(0, 0, 0, 0.15f);
            holder.style.marginTop = 10;
            holder.style.paddingTop = 10;
            holder.style.paddingBottom = 10;
            holder.style.paddingLeft = 10;
            holder.style.paddingRight = 10;
            holder.style.borderTopLeftRadius = 5;
            holder.style.borderTopRightRadius = 5;
            holder.style.borderBottomLeftRadius = 5;
            holder.style.borderBottomRightRadius = 5;

            if (!string.IsNullOrEmpty(title)) holder.Add(Title(title, 15, new Vector4(3, 3), new Vector4(5, 5, 5, 5), 5, Color.clear));
            if (elements.Length > 0) holder.AddRange(elements);

            return holder;
        }

        public static VisualElement Element(Vector4 margin = default, Vector4 padding = default, Color background = default, float borderRadius = default, int grow = 0)
        {
            VisualElement e = new();

            e.Grow(grow);

            e.style.marginTop = margin.x;
            e.style.marginBottom = margin.y;
            e.style.marginLeft = margin.z;
            e.style.marginRight = margin.w;

            e.style.paddingTop = padding.x;
            e.style.paddingBottom = padding.y;
            e.style.paddingLeft = padding.z;
            e.style.paddingRight = padding.w;

            e.style.backgroundColor = background;

            e.style.borderTopLeftRadius = borderRadius;
            e.style.borderTopRightRadius = borderRadius;
            e.style.borderBottomLeftRadius = borderRadius;
            e.style.borderBottomRightRadius = borderRadius;

            return e;
        }
    }
}