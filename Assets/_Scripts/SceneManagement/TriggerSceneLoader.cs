using UnityEngine;
using System.Collections;
/// <summary>
/// This class contains the function to call when play button is pressed
/// </summary>

public class TriggerSceneLoader : MonoBehaviour
{
	public LoadSceneEventChannelSO onPlayButtonPress;
	public GameSceneSO[] locationsToLoad;
	public bool showLoadScreen;
	public bool triggered;


	public void OnButtonPress()
	{
		onPlayButtonPress.RaiseEvent(locationsToLoad, showLoadScreen);
	}


    private void OnTriggerEnter2D(Collider2D collision)
    {
		if (!triggered)
		{
			triggered = true;
			StartCoroutine(TriggerCO());
		}
    }
	IEnumerator TriggerCO()
    {
		yield return new WaitForSeconds(2f);
		OnButtonPress();
    }
}
