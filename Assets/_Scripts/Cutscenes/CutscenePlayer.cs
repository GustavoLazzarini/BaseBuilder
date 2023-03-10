using UnityEngine;
using UnityEngine.Playables;

/// <summary>
/// Class to trigger a cutscene.
/// </summary>

public class CutscenePlayer : MonoBehaviour
{
	[SerializeField] private CutsceneManager _cutsceneManager = default;
	[SerializeField] private PlayableDirector _playableDirector = default;
	[SerializeField] private bool _playOnStart = default;
	[SerializeField] private bool _playOnce = default;

	private void Start()
	{
		if (_playOnStart)
			_cutsceneManager.PlayCutscene(_playableDirector);
	}

	public void PlayCutscene()
    {
		_cutsceneManager.PlayCutscene(_playableDirector);

		if (_playOnce)
			Destroy(this);
	}
}
