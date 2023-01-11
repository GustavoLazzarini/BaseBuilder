using UnityEngine;
using UnityEngine.UI;

public class SpitIconEnableDisable : MonoBehaviour
{

    [SerializeField] VoidEventChannelSO spitIconEnableChannel;
    [SerializeField] VoidEventChannelSO spitIconDisableChannel;
    [SerializeField] Image spitImage;

    private void OnEnable()
    {
        spitIconEnableChannel.OnEventRaised += EnableEvent;
        spitIconDisableChannel.OnEventRaised += DisableEvent;
    }

    private void OnDisable()
    {
        spitIconEnableChannel.OnEventRaised += EnableEvent;
        spitIconDisableChannel.OnEventRaised += DisableEvent;
    }

    private void EnableEvent()
    {
        spitImage.enabled = true;
    }

    private void DisableEvent()
    {
        spitImage.enabled = false;
    }
}
