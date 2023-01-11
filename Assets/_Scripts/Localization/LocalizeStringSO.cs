using UnityEngine;
using UnityEngine.Localization;
using TMPro;
/// <summary>
/// This class contains Settings specific to Locations only
/// </summary>
[RequireComponent(typeof(TextMeshProUGUI))]
[CreateAssetMenu(fileName = "NewLocationString", menuName = "Location Data/String")]
public class LocalizeStringSO : ScriptableObject
{
	[Header("Location specific")]
	public LocalizedString stringName;
}