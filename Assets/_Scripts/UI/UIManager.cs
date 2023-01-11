using UnityEngine;

[CreateAssetMenu(fileName = "newUIManager", menuName = "UI/UIManager")]
public class UIManager : ScriptableObject
{
	private DialogueUIController dialogueController;


	public void OpenUIDialogue(DialogueLineSO dialogueLine)
	{
		DialogueUIController[] dialogueUIControllers = FindObjectsOfType<DialogueUIController>();
		foreach (DialogueUIController d in dialogueUIControllers)
		{
			d.SetVisible(false);
		}
		foreach (DialogueUIController d in dialogueUIControllers)
        {
			if(d.actor == dialogueLine.Actor)
            {
				dialogueController = d; 
				dialogueController.SetDialogue(dialogueLine);
				break;
			}
        }
		
	}
	public void CloseUIDialogue()
	{
		if (dialogueController != null)
		{
			dialogueController.SetVisible(false);
		}
	}
}
