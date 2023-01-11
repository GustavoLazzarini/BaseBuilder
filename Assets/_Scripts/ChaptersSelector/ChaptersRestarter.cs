using UnityEngine;
using Core;

public class ChaptersRestarter : MonoBehaviour
{
    public void RestartChapters()
    {
        Save.Set(SaveConstants.Level, 1);
    }
}
