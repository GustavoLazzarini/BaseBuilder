using UnityEngine;

public class ReturnToPool : MonoBehaviour
{
    public void Return()
    {
        gameObject.SetActive(false);
    }
}
