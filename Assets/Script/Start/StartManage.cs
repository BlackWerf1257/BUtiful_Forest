using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartManage : MonoBehaviour
{
    [SerializeField] private ScrollRect creditsObj;
    [SerializeField] private GameObject parentObj;
    [SerializeField] ResourceManage ResourceManage;


    public void StartEvent(int idx)
    {
        switch (idx)
        {
            case 0: SceneManager.LoadScene("Main_Cam"); break;
            case 1: LoadFile(); break;
        }
    }
    public void Quit() => Application.Quit();

    public void Credits(bool isOn)
    {
        if (isOn)
        {
            if (creditsObj == null) return;
            creditsObj.gameObject.SetActive(true);
            parentObj.SetActive(false);
        }
        else
        {
            parentObj.SetActive(true);
            creditsObj.gameObject.SetActive(false);

        }
    }


    #region Gallery
    void LoadFile()
    {
        NativeGallery.GetImageFromGallery(file =>
        {
            if (string.IsNullOrEmpty(file))
            {                                                                        
                Debug.LogWarning("파일을 선택하지 않았습니다.");
                return;
            }

            FileInfo fileInfo = new(file);
            //용량 제한 10mb
            if (fileInfo.Length > 10000000) return;

            if (!string.IsNullOrEmpty(file))
            {
                Debug.LogWarning("경로: " + file);
                ResourceManage.imgPath = file;
                SceneManager.LoadScene("Main_Gallery");
            }
            else
            {
                Debug.LogWarning("10mb 이하 사진으로 선택해주세요");
            }
        });
        
        DontDestroyOnLoad(ResourceManage.gameObject);
    }
    #endregion
}
