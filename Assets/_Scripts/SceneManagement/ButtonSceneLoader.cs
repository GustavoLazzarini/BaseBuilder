using UnityEngine;
using UnityEngine.UI;
using System.Linq;

/// <summary>
/// This class contains the function to call when play button is pressed
/// </summary>

public class ButtonSceneLoader : MonoBehaviour
{
	[SerializeField] GameObject UIBlocker;
	public bool showLoadScreen;
	public LoadSceneEventChannelSO onPlayButtonPress;

	[Space(20)]
	public GameSceneSO[] locationsToLoad;




	private void Awake()
	{
		UIBlocker = Resources.FindObjectsOfTypeAll<GameObject>().FirstOrDefault(g => g.CompareTag("UIBlocker"));
	}


	public void OnButtonPress()
	{
		// Fix double click
		if (GetComponent<Button>() != null) { GetComponent<Button>().enabled = false; }
		if (UIBlocker != null) UIBlocker.SetActive(true);


		// Load Scene
		onPlayButtonPress.RaiseEvent(locationsToLoad, showLoadScreen);
		Time.timeScale = 1f;
	}
}
