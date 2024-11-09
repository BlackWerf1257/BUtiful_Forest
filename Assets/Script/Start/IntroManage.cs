using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Vuforia;
using Image = UnityEngine.UI.Image;

public class IntroManage : MonoBehaviour
{
    [SerializeField] private Image logoImg;
    [SerializeField] private TextMeshProUGUI prNameTxt;
    [SerializeField] Image background;



    // Start is called before the first frame update

    [SerializeField] private GameObject startCanvas;

    void Start()
    {
      
        ApplyFade();
    }
    private void Awake()
    {
        background.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.currentResolution.height);
        background.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.currentResolution.width);
    }

    private void ApplyFade()
    {
        logoImg.DOFade(0, 2.0f);
        prNameTxt.DOFade(0, 2.0f).OnComplete(StartCanvasOn);
    }

    void StartCanvasOn()
    {
        startCanvas.SetActive(true);
        gameObject.SetActive(false);
    }

}
