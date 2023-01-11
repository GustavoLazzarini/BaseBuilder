//Made by Galactspace

using System;
using UnityEngine;
using UnityEngine.UIElements;

public static class VisualElementExtentions
{
    public static void AddRange(this VisualElement target, params VisualElement[] values)
    {
        values ??= Array.Empty<VisualElement>();
        for (int i = 0; i < values.Length; i++)
            target.Add(values[i]);
    }

    public static void Show(this VisualElement target, bool value)
    {
        target.style.display = new(value ? DisplayStyle.Flex : DisplayStyle.None);
    }

    public static void Grow(this VisualElement target, int value)
    {
        target.style.flexGrow = value;
    }
}