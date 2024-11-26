using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ImageManager : MonoBehaviour
{
    [SerializeField] RawImage rawImg;
    ResourceManage resourceManager;
    
    [SerializeField] private int rendCamIdx = 2;
    [SerializeField] private Camera rendCam;
    [SerializeField] private Canvas canvas;
    [SerializeField] Mask mask;

    [SerializeField] private RawImage img;
    private Vector2 originImgSize;
    
    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Main_Gallery")
        {
            resourceManager = GameObject.FindObjectOfType<ResourceManage>();
            if (resourceManager != null)
                StartCoroutine(LoadImg(resourceManager.imgPath));
            else Debug.LogError("파일을 찾지못함");
            
            
            originImgSize = img.rectTransform.sizeDelta;
        }
        else this.enabled = false;
    }

    #region 로드
    IEnumerator LoadImg(string path)
    {
        yield return null;

        if (path != null)
        {
            byte[] fileData = File.ReadAllBytes(path);
            string fileName = Path.GetFileName(path).Split('.')[0];
            string savePath = Application.persistentDataPath + "/Image";


            if (!Directory.Exists(savePath))
                Directory.CreateDirectory(savePath);

            File.WriteAllBytes(savePath + fileName + ".png", fileData);

            var temp = File.ReadAllBytes(savePath + fileName + ".png");

            Texture2D texture = new(0, 0);
            texture.LoadImage(temp);

            rawImg.texture = texture;
            ImageSizeCalculate(rawImg, .3f);
        }
    }

    void ImageSizeCalculate(RawImage img, float percent)
    {
        // 화면의 크기 구하기 (예: 화면 크기: 1920 x 1080)
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        float targetHeight = screenHeight * percent;

        img.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, screenWidth);
        img.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, targetHeight);
    }
    #endregion


    #region 저장
    public void SaveEvent(int typeIdx)
    {
        switch (typeIdx)
        {
            case 0: { } break; //GIF
            case 1:  break; //PNG
            case 2: { } break; //QR
        }
    }

    void RenderCamera(bool isStartRend)
    {
        mask.enabled = isStartRend;
        
        if (isStartRend)
        {
            canvas.worldCamera = rendCam;
            
        }
        else
        {
            img.rectTransform.sizeDelta = originImgSize;
            canvas.worldCamera = Camera.main;
        }
    }

    void StartSave(bool isStart)
    {
        if (isStart)
        {
            rendCam.gameObject.SetActive(true);
            StartCoroutine(TakeScreenshotAndSave());
        }
        else
        {
            RenderCamera(false);
        }
    }
    
    private IEnumerator TakeScreenshotAndSave()
    {
        yield return new WaitForEndOfFrame();

        Texture2D ss = new Texture2D( Screen.width, Screen.height, TextureFormat.RGB24, false );
        ss.ReadPixels( new Rect( 0, 0, Screen.width, Screen.height ), 0, 0 );
        ss.Apply();

        // Save the screenshot to Gallery/Photos
        NativeGallery.Permission permission = NativeGallery.SaveImageToGallery( ss, DateTime.Today + " BUtiful Forest", "BUtiful Forest", ( success, path ) => Debug.Log( "Media save result: " + success + " " + path ) );

        Debug.Log( "Permission result: " + permission );
        RenderCamera(Camera.main);
        // To avoid memory leaks
        Destroy( ss );
    }
    #endregion
}
