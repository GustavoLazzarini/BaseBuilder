using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.UI;

public class DialogueUIController : MonoBehaviour
{
	[SerializeField] LocalizeStringEvent sizeText = default;
	[SerializeField] LocalizeStringEvent lineText = default;
	[SerializeField] LocalizeStringEvent actorNameText = default;
	[SerializeField] private GameObject box;
	[SerializeField] private GameObject tail;

	public ActorSO actor;

	public void SetDialogue(DialogueLineSO dialogueLine)
	{
		sizeText.StringReference = dialogueLine.Sentence;
		lineText.StringReference = dialogueLine.Sentence;
		if (actorNameText != null)
		{
			actorNameText.StringReference = dialogueLine.Actor.ActorName;
		}
		SetVisible(true, dialogueLine);
	}

	public void SetVisible(bool state, DialogueLineSO d = null)
    {
		if(d != null)
        {
			box.GetComponentInChildren<Image>().sprite = d.dialogueUIDataSO.boxImage;
			tail.GetComponent<Image>().sprite = d.dialogueUIDataSO.tailImage;
        }
		box.SetActive(state);
		tail.SetActive(state);
    }
}