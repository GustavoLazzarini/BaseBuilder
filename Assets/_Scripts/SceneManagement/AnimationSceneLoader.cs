using UnityEngine;

/// <summary>
/// This class goes on a animator which, when animation finished, loads another scene
/// </summary>

public class AnimationSceneLoader : MonoBehaviour
{
	[Header("Loading settings")]
	[SerializeField] private GameSceneSO[] _locationsToLoad = default;
	[SerializeField] private bool _showLoadScreen = default;

	[Header("Broadcasting on")]
	[SerializeField] private LoadSceneEventChannelSO _locationExitLoadChannel = default;

	public void LoadScene()
	{
			_locationExitLoadChannel.RaiseEvent(_locationsToLoad, _showLoadScreen);
	}
}