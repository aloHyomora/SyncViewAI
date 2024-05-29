using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WebcamManager : MonoBehaviour
{
    public RawImage display;
    WebCamTexture camTexture;
    private int currentIndex = 0;
    void Start()
    {
        GetDeviceName();
        StartGetWebcamTexture();
    }

    private void GetDeviceName()
    {
        // 웹캠 연결을 확인하는 기능
        WebCamDevice[] devices = WebCamTexture.devices;
        for (int i = 0; i < devices.Length; i++)
        {
            Debug.Log("[Webcam] " + devices[i].name);
        }
    }

    private void StartGetWebcamTexture()
    {
        if (camTexture != null)
        {
            display.texture = null;
            camTexture.Stop();
            camTexture = null;
        }  
        WebCamDevice device = WebCamTexture.devices[currentIndex];
        camTexture = new WebCamTexture(device.name);
        display.texture = camTexture;
        camTexture.Play();
    }
}
