using UnityEngine.Events;
using UnityEngine;

/// <summary>
/// This class is used for Events that have a bool argument.
/// Example: An event to toggle a UI interface
/// </summary>

[CreateAssetMenu(menuName = "Events/DeathRespawn Event Channel")]
public class DeathRespawnEventChannelSO : ScriptableObject
{
	public UnityAction<Vector3, Vector3, float> OnEventRaised;
	public void RaiseEvent(Vector3 deathPosition, Vector3 respawnPosition, float fadeType)
	{
		if (OnEventRaised != null)
			OnEventRaised.Invoke(deathPosition, respawnPosition, fadeType);
	}
}