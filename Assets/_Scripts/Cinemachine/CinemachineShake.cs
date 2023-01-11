using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineShake : MonoBehaviour
{
    private CinemachineVirtualCamera cinemachineVirtualCamera;
    private float shakeTimer;
    [SerializeField] FloatFloatEventChannelSO cameraShakeEventChannel;

    private void OnEnable()
    {
        cameraShakeEventChannel.OnEventRaised += Shake;
    }

    private void OnDisable()
    {
        cameraShakeEventChannel.OnEventRaised -= Shake;
    }

    private void Awake()
    {
         cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    public void Shake(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
            cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
        shakeTimer = time;
    }

    private void Update()
    {
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            if (shakeTimer <= 0)
            {
                CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
                   cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;
            }
        }
    }
}
