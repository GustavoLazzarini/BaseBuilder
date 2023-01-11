using UnityEngine.Events;
using UnityEngine;

/// <summary>
/// This class is used for Events that have a bool argument.
/// Example: An event to toggle a UI interface
/// </summary>

[CreateAssetMenu(menuName = "Events/Float Event Channel")]
public class FloatEventChannelSO: ScriptableObject
{
	public UnityAction<float> OnEventRaised;
	public void RaiseEvent(float force)
	{
		if (OnEventRaised != null)
			OnEventRaised.Invoke(force);
	}
}