using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Bubbles : MonoBehaviour
{
    [SerializeField] VoidEventChannelSO winChannel;
    [SerializeField] TilemapRenderer holeTilemap;
    [SerializeField] TilemapRenderer bubblesTilemap;

    private void OnEnable()
    {
        winChannel.OnEventRaised += Win;
    }

    private void OnDisable()
    {
        winChannel.OnEventRaised -= Win;
    }

    private void Win()
    {
        holeTilemap.enabled = true;
        bubblesTilemap.enabled = true ;
    }
}
