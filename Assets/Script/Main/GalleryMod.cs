using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GalleryMod : MonoBehaviour
{
    [SerializeField] RawImage rawImg;
    ResourceManage resourceManager;

    // Start is called before the first frame update
    void Start()
    {
        resourceManager = GameObject.FindObjectOfType<ResourceManage>();
        if (resourceManager != null)
        {
            Debug.LogWarning("경로 : " + resourceManager.imgPath);
            StartCoroutine(LoadImg(resourceManager.imgPath));

        }
        else Debug.LogError("리소스 오브젝트를 찾기 못함");

    }


    #region Image Process
    IEnumerator LoadImg(string path)
    {
        yield return null;

        byte[] fileData = File.ReadAllBytes(path);
        string fileName = Path.GetFileName(path).Split('.')[0];
        //초기 지정 이후 추후 불러오는 용
        string savePath = Application.persistentDataPath + "/Image";


        if (!Directory.Exists(savePath))
            Directory.CreateDirectory(savePath);

        File.WriteAllBytes(savePath + fileName + ".png", fileData);

        var temp = File.ReadAllBytes(savePath + fileName + ".png");

        Texture2D texture = new Texture2D(0, 0);
        texture.LoadImage(temp);

        rawImg.texture = texture;
        rawImg.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.currentResolution.height);
        rawImg.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.currentResolution.width);
        //ImageSize(rawImg, 100, 100);
    }

    void ImageSize(RawImage img, float x, float y)
    {
        var imgSizeX = img.rectTransform.sizeDelta.x;
        var imgSizeY = img.rectTransform.sizeDelta.y;

        if (x / y > imgSizeX / imgSizeY) //세로가 더 길 경우
        {
            img.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, y); // imgY * y / imgY
            img.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, imgSizeX * (y / imgSizeY));
        }
        else
        {
            img.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, x);
            img.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, imgSizeY * (x / imgSizeX));
        }
    }
    #endregion
}
