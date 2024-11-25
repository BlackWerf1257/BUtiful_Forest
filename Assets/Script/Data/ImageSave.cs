using System;
using System.IO;
using UnityEngine;


public class ImageSave : MonoBehaviour
{
    [SerializeField] private int rendCamIdx = 2;
    [SerializeField] private Camera rendCam;
    [SerializeField] private Canvas canvas;
    
    
    public void SaveEvent(int typeIdx)
    {
        switch (typeIdx)
        {
            case 0: { } break;
            case 1: ScreenCapture.CaptureScreenshot(DateTime.Now + "- BUtifulFlower.png"); break;
            case 2: { } break;
        }
    }

    void RenderCamera()
    {
        
    }

    public void CancelRend()
    {
       canvas.worldCamera = Camera.main;
       
    }
}
