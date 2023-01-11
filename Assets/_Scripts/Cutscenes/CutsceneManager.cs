using UnityEngine;
using UnityEngine.Playables;

[CreateAssetMenu(fileName = "newCutsceneManager", menuName = "Cutscenes/CutsceneManager")]
public class CutsceneManager : ScriptableObject
{

	[SerializeField] private InputReader _inputReader = default;
	[SerializeField] private DialogueManager _dialogueManager = default;

	private PlayableDirector _activePlayableDirector;
	private bool _isPaused;

	public bool IsCutscenePlaying => _activePlayableDirector.playableGraph.GetRootPlayable(0).GetSpeed() != 0d;

	private void OnEnable()
	{
		_inputReader.advanceDialogueEvent += OnAdvance;
	}

	private void OnDisable()
	{
		_inputReader.advanceDialogueEvent -= OnAdvance;
	}

	public void PlayCutscene(PlayableDirector activePlayableDirector)
	{
		_inputReader.EnableDialogueInput();
		_activePlayableDirector = activePlayableDirector;

		_isPaused = false;
		_activePlayableDirector.Play();
		_activePlayableDirector.stopped += HandleDirectorStopped;
	}

	public void CutsceneEnded()
	{
		if (_activePlayableDirector != null)
			_activePlayableDirector.stopped -= HandleDirectorStopped;
		
		DialogueUIController[] dialogueUIControllers = FindObjectsOfType<DialogueUIController>();
		foreach (DialogueUIController d in dialogueUIControllers)
		{
			d.SetVisible(false);
		}
		_inputReader.EnableGameplayInput();
	}

	private void HandleDirectorStopped(PlayableDirector director) => CutsceneEnded();

	public void PlayDialogueFromClip(DialogueLineSO dialogueLine)
	{
		_dialogueManager.DisplayDialogueLine(dialogueLine);
	}

	/// <summary>
	/// This callback is executed when the player presses the button to advance dialogues. If the Timeline is currently paused due to a <c>DialogueControlClip</c>, it will resume its playback.
	/// </summary>
	private void OnAdvance()
	{
		if (_isPaused)
			ResumeTimeline();
	}

	/// <summary>
	/// Called by <c>DialogueControlClip</c> on the Timeline.
	/// </summary>
	public void PauseTimeline()
	{
		_isPaused = true;
		if (_activePlayableDirector != null) { _activePlayableDirector.playableGraph.GetRootPlayable(0).SetSpeed(0); }
	}

	public void ResumeTimeline()
	{
		_isPaused = false;
        if (_activePlayableDirector != null) { _activePlayableDirector.playableGraph.GetRootPlayable(0).SetSpeed(1); }
		_dialogueManager.CloseDialogueLine();
	}
}

