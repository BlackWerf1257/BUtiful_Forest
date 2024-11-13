using System.Collections;
using System.IO;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GalleryMod : MonoBehaviour
{
    [SerializeField] RawImage rawImg;
    ResourceManage resourceManager;
    [SerializeField] AREffect arEffect;

    [Header("크기 정렬할 UI")]
    [SerializeField] RectTransform[] uiContents;



    // Start is called before the first frame update
    void Start()
    { 
        if (Application.isEditor)
        {
            foreach (var item in uiContents)
            {
                item.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 1920);
                item.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1080);
            }
        }
        else
        {
            foreach (var item in uiContents)
            {
                item.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.currentResolution.height);
                item.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.currentResolution.width);
            }
        }
        ;
        
        resourceManager = GameObject.FindObjectOfType<ResourceManage>();
        if (resourceManager != null)
            StartCoroutine(LoadImg(resourceManager.imgPath));
        else Debug.LogError("파일을 찾지못함");
    }


    #region Image Process
    IEnumerator LoadImg(string path)
    {
        yield return null;

        byte[] fileData = File.ReadAllBytes(path);
        string fileName = Path.GetFileName(path).Split('.')[0];
        //�ʱ� ���� ���� ���� �ҷ����� ��
        string savePath = Application.persistentDataPath + "/Image";


        if (!Directory.Exists(savePath))
            Directory.CreateDirectory(savePath);

        File.WriteAllBytes(savePath + fileName + ".png", fileData);

        var temp = File.ReadAllBytes(savePath + fileName + ".png");

        Texture2D texture = new(0, 0);
        texture.LoadImage(temp);

        rawImg.texture = texture;
        //rawImg.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.currentResolution.height);
        //rawImg.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.currentResolution.width);
        ImageSizeCalculate(rawImg, .3f);
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
        
        
        /*var imgSizeX = img.rectTransform.sizeDelta.x;
        var imgSizeY = img.rectTransform.sizeDelta.y;

        if (x / y > imgSizeX / imgSizeY) //���ΰ� �� �� ���
        {
            img.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, y); // imgY * y / imgY
            img.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, imgSizeX * (y / imgSizeY));
        }
        else
        {
            img.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, x);
            img.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, imgSizeY * (x / imgSizeX));
        }*/
    }
    #endregion
    
    #region 공용 이벤트
    //이벤트 버튼을 눌렀을때 내려갈 오브젝트
    [SerializeField] private Transform eventListObj;
    [Tooltip("캐릭터 테마 투명도 효과 각 이벤트 오브젝트")]
    [SerializeField] private RectTransform[] eventRect;

    private int movedObjIdx = 0;
    
    public void EnterEvent(int index)
    {
        movedObjIdx = index;
        eventListObj.DOLocalMoveY(-500, .5f).OnComplete(() => eventRect[index].DOLocalMoveY(0, .5f));
        ;
    }
    #endregion

    public void BackToMain(bool isMain)
    {
        if(isMain)
            SceneManager.LoadScene("Start");
        else
            eventRect[movedObjIdx].DOLocalMoveY(-500f, .5f).OnComplete(() => eventListObj.DOLocalMoveY(0, .5f));
    }
}
