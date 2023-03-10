using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// Event on which <c>AudioCue</c> components send a message to play SFX and music. <c>AudioManager</c> listens on these events, and actually plays the sound.
/// </summary>
[CreateAssetMenu(menuName = "Events/Audio Event Channel")]
public class AudioEventChannelSO : ScriptableObject
{
	public UnityAction<AudioSO, AudioConfigurationSO, Vector3> OnAudioCueRequested;

	public void RaiseEvent(AudioSO audioCue, AudioConfigurationSO audioConfiguration, Vector3 positionInSpace)
	{
		if (OnAudioCueRequested != null)
		{
			OnAudioCueRequested.Invoke(audioCue, audioConfiguration, positionInSpace);
		}
		else
		{
			Debug.LogWarning("An AudioCue was requested, but nobody picked it up. " +
				"Check why there is no AudioManager already loaded, " +
				"and make sure it's listening on this AudioCue Event channel.");
		}
	}
}