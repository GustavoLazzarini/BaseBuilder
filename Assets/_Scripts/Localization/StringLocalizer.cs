using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Components;

public class StringLocalizer : MonoBehaviour
{
	[SerializeField] LocalizeStringEvent localizationEvent = default;

	[SerializeField] LocalizeStringSO SO = default;

	private void Start()
	{
		localizationEvent.StringReference = SO.stringName;
	}
}
