using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CreditsMenu : MonoBehaviour
{
    [SerializeField] Button creditsButton;

    private void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == null)
        {
            EventSystem.current.SetSelectedGameObject(creditsButton.gameObject);
        }
    }
}
