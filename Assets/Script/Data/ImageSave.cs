using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageSave : MonoBehaviour
{
    public void SaveEvent(int typeIdx)
    {
        switch (typeIdx)
        {
            case 0: { } break;
            case 1: ScreenCapture.CaptureScreenshot(DateTime.Now + "- BUtifulFlower.png"); break;
            case 2: { } break;
        }
    }
}
