using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class DropdownAutoscroller : MonoBehaviour
{
    [SerializeField] bool canScroll = false;


    // Scripts
    private GameInput _GameInput;


    // Components
    private Dropdown dropdown;


    private void Awake()
    {
        // Scripts
        _GameInput = new GameInput();


        // Components
        dropdown = GetComponent<Dropdown>();
    }
    private void OnEnable()
    {
        _GameInput.Enable();
    }
    private void OnDisable()
    {
        _GameInput.Disable();
    }


    void Update()
    {
        ToogleScroolDropdown();
        ScrollDropdown();
    }


    private void ToogleScroolDropdown()
    {
        if (_GameInput.UI.Submit.triggered) { canScroll = !canScroll; }
    }
    private void ScrollDropdown()
    {
        if(canScroll)
        {
            if (EventSystem.current.currentSelectedGameObject == transform.gameObject)
            {
                if (Input.GetButtonUp("Vertical"))
                {
                    Transform dropdownListTransform = dropdown.transform.Find("Dropdown List");
                    if (dropdownListTransform == null)
                    {
                        // Show the dropdown when the user hits the arrow keys if the dropdown is not already showing
                        dropdown.Show();
                    }
                }
            }
            else
            {
                PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
                eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                List<RaycastResult> results = new List<RaycastResult>();
                EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
                if (results.Count > 0)
                {
                    if (results[0].gameObject.transform.IsChildOf(dropdown.gameObject.transform))
                    {
                        // Pointer over the list, use default behavior
                        return;
                    }
                }

                // Autoscroll list as the selected object is changed from the arrow keys
                if (EventSystem.current.currentSelectedGameObject.transform.IsChildOf(dropdown.gameObject.transform))
                {
                    if (EventSystem.current.currentSelectedGameObject.name.StartsWith("Item "))
                    {
                        // Skip disabled items
                        Transform parent = EventSystem.current.currentSelectedGameObject.transform.parent;
                        int activeChildren = 0;
                        int totalChildren = parent.childCount;
                        for (int childIndex = 0; childIndex < totalChildren; childIndex++)
                        {
                            if (parent.GetChild(childIndex).gameObject.activeInHierarchy)
                            {
                                activeChildren++;
                            }
                        }
                        int myActiveIndex = 0;
                        for (int childIndex = 0; childIndex < totalChildren; childIndex++)
                        {
                            if (parent.GetChild(childIndex).gameObject == EventSystem.current.currentSelectedGameObject)
                            {
                                break;
                            }
                            else if (parent.GetChild(childIndex).gameObject.activeInHierarchy)
                            {
                                myActiveIndex++;
                            }
                        }

                        if (activeChildren > 1)
                        {
                            GameObject scrollbarGameObject = GameObject.Find("Scrollbar");
                            if (scrollbarGameObject != null && scrollbarGameObject.activeInHierarchy)
                            {
                                Scrollbar scrollbar = scrollbarGameObject.GetComponent<Scrollbar>();
                                if (scrollbar.direction == Scrollbar.Direction.TopToBottom)
                                    scrollbar.value = (float)myActiveIndex / (float)(activeChildren - 1);
                                else
                                    scrollbar.value = 1.0f - (float)myActiveIndex / (float)(activeChildren - 1);
                            }
                        }
                    }
                }
            }
        }
    }
}