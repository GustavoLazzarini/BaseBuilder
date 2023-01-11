using UnityEngine.Events;
using UnityEngine;

/// <summary>
/// This class is used for Events that have a bool argument.
/// Example: An event to toggle a UI interface
/// </summary>

[CreateAssetMenu(menuName = "Events/Float Float Event Channel")]
public class FloatFloatEventChannelSO: ScriptableObject
{
	public UnityAction<float, float> OnEventRaised;
	public void RaiseEvent(float intensity, float time)
	{
		if (OnEventRaised != null)
			OnEventRaised.Invoke(intensity, time);
	}
}