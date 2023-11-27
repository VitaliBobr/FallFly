using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class CameraSaveableParams : MonoBehaviour
{
    public PixelPerfectCamera PixelCamera;
    static public bool isEnabled;
    private void Start()
    {
        PixelCamera = GetComponent<PixelPerfectCamera>();
        PixelCamera.enabled = isEnabled;
        PlayerPrefs.GetInt("pixelmode");
    }
}
