using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ImageLoad : MonoBehaviour
{
    [SerializeField] RawImage rawImg;
    ResourceManage resourceManager;
    
    private void Start()
    {
        resourceManager = GameObject.FindObjectOfType<ResourceManage>();
        if (resourceManager != null)
            StartCoroutine(LoadImg(resourceManager.imgPath));
        else Debug.LogError("파일을 찾지못함");
    }

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

        // 화면의 3-40% 크기 비율 계산
        float targetHeight = screenHeight * percent;
        
        img.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, targetHeight);
        img.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, screenWidth);
    }
}
