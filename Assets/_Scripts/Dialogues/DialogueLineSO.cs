using UnityEngine;
using UnityEngine.Localization;

/// <summary>
/// DialogueLine is a Scriptable Object that represents one line of spoken dialogue.
/// It references the Actor that speaks it.
/// </summary>
[CreateAssetMenu(fileName = "newDialogueLine", menuName = "Dialogues/Dialogue Line")]
public class DialogueLineSO : ScriptableObject
{
	public ActorSO Actor { get => _actor; }
	public LocalizedString Sentence { get => _sentence; }

	[SerializeField] private ActorSO _actor = default;
	[SerializeField] private LocalizedString _sentence = default; //TODO: Connect this with localisation
	public DialogueUIDataSO dialogueUIDataSO;
}
