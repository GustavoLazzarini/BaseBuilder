using UnityEngine;
/// <summary>
/// Simple implementation of a MonoBehaviour that is able to request a sound being played by the <c>AudioManager</c>.
/// It fires an event on an <c>AudioCueEventSO</c> which acts as a channel, that the <c>AudioManager</c> will pick up and play.
/// </summary>
public class AudioCue : MonoBehaviour
{
	[Header("Sound definition")]
	public AudioSO _audioCue = default;
	[SerializeField] private bool _playOnStart = false;

	[Header("Configuration")]
	[SerializeField] private AudioEventChannelSO _audioCueEventChannel = default;
	[SerializeField] private AudioConfigurationSO _audioConfiguration = default;

	private void Start()
	{
		if (_playOnStart)
			PlayAudioCue();
	}

	public void PlayAudioCue()
	{
		//mudar/escrever solução para position não ser Vector3.zero
		_audioCueEventChannel.RaiseEvent(_audioCue, _audioConfiguration, Vector3.zero);
	}
}
