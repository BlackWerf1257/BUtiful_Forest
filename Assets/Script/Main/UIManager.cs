using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] AREffect arEffect;

    [Header("크기 정렬할 UI")]
    [SerializeField] RectTransform[] uiContents;
    [SerializeField] CanvasScaler canvasScaler;



    // Start is called before the first frame update
    void Start()
    { 
        canvasScaler.referenceResolution = new Vector2(Screen.width, Screen.height);
        
        /*if (Application.isEditor)
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
        }*/
    }


   
    
    #region 공용 이벤트
    //이벤트 버튼을 눌렀을때 내려갈 오브젝트
    [SerializeField] private RectTransform startEventBtn;
    [SerializeField] private RectTransform eventListObj;
    [Tooltip("캐릭터 테마 투명도 효과 각 이벤트 오브젝트")]
    [SerializeField] private RectTransform[] eventRect;

    private int movedObjIdx = 0;

    public void EventMenu(bool isMain)
    {
        if(isMain)
            startEventBtn.DOLocalMoveY(-500, .5f).OnComplete(() => eventListObj.DOLocalMoveY(0, .5f));
        else
            eventListObj.DOLocalMoveY(-500, .5f).OnComplete(() => startEventBtn.DOLocalMoveY(0, .5f));
    }
    
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
