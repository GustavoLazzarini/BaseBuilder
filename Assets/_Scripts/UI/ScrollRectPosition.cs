using UnityEngine;
using UnityEngine.EventSystems;

public class ScrollRectPosition : MonoBehaviour
{
    [SerializeField] RectTransform contentPanel;


    // Components
    RectTransform scrollRectTransform;
    RectTransform selectedRectTransform;
    GameObject lastSelected;



    void Start()
    {
        // Components
        scrollRectTransform = GetComponent<RectTransform>();
    }



    void Update()
    {
        // Get the currently selected UI element from the event system.
        GameObject selectedButton = EventSystem.current.currentSelectedGameObject;


        // Return if there are none.
        if (selectedButton == null) { return; }


        // Return if the selected game object is not inside the scroll rect.
        if (selectedButton.transform.parent != contentPanel.transform) { return; }


        // Return if the selected game object is the same as it was last frame,
        // meaning we haven't moved.
        if (selectedButton == lastSelected) { return; }


        // Get the rect tranform for the selected game object.
        selectedRectTransform = selectedButton.GetComponent<RectTransform>();


        // The position of the selected UI element is the absolute anchor position,
        // ie. the local position within the scroll rect + its height if we're
        // scrolling down. If we're scrolling up it's just the absolute anchor position.
        float selectedPositionY = Mathf.Abs(selectedRectTransform.anchoredPosition.y) + selectedRectTransform.rect.height;


        // The upper bound of the scroll view is the anchor position of the content we're scrolling.
        float scrollViewMinY = contentPanel.anchoredPosition.y;


        // The lower bound is the anchor position + the height of the scroll rect.
        float scrollViewMaxY = contentPanel.anchoredPosition.y + scrollRectTransform.rect.height;


        // If the selected position is below the current lower bound of the scroll view we scroll down.
        if (selectedPositionY > scrollViewMaxY)
        {
            float newY = selectedPositionY - scrollRectTransform.rect.height;
            contentPanel.anchoredPosition = new Vector2(contentPanel.anchoredPosition.x, newY);
        }


        // If the selected position is above the current upper bound of the scroll view we scroll up.
        else if (Mathf.Abs(selectedRectTransform.anchoredPosition.y) < scrollViewMinY)
        {
            contentPanel.anchoredPosition = new Vector2(contentPanel.anchoredPosition.x, Mathf.Abs(selectedRectTransform.anchoredPosition.y));
        }


        lastSelected = selectedButton;
    }
}
