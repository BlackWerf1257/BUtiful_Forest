using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AREffect : MonoBehaviour
{
    #region AR 버튼
    [SerializeField] RectTransform EffectStartBtn;
    [SerializeField] RectTransform EffectSelectBtn;
    #endregion


    #region AR_Effect
    void EffectSelect()
    {
        EffectStartBtn.DOMoveY(-50, 2f);
        EffectSelectBtn.DOMoveY(50, 5f);
    }


    #region AR 오브젝트 배치
    List<GameObject> ARObj = new();
    List<Renderer> ARRendObj = new();

    [Header("스티커 모음")]
    [SerializeField] private GameObject[] characterArray = new GameObject[3];

    void CharacterEvent(int charcterIdx)
    {
        GameObject newCharacter = GameObject.Instantiate(characterArray[charcterIdx]);
        ARObj.Add(newCharacter);
        ARRendObj.Add(newCharacter.GetComponent<Renderer>());
    }
    #endregion

    #region 테마
    void ThemeEvent()
    {

    }
    #endregion

    #region 투명도
    [SerializeField] Slider visSlider;
    void VisibilityEvent()
    {
        Renderer rend = new();
        Color color = rend.material.color;
        color.a = visSlider.value;

        foreach (Renderer rendVar in ARRendObj)
            rendVar.material.color = color;
        foreach (Renderer rendVar in ParticleRendList)
            rendVar.material.color = color;
    }
    #endregion

    #region 효과
    [Header("효과")]
    [SerializeField] private GameObject[] ParticleArray = new GameObject[4];
    List<GameObject> ParticleList = new();
    List<Renderer> ParticleRendList = new();
    void EffectEvent(int particleIdx)
    {
        GameObject newEffect = GameObject.Instantiate(characterArray[particleIdx]);
        ParticleList.Add(newEffect);
        ParticleRendList.Add(newEffect.GetComponent<Renderer>());
    }
    #endregion
#endregion



    void BackEvent()
    {

    }

    void SaveEvent(int typeIdx)
    {
        switch (typeIdx)
        {
            case 0: { } break;
            case 1: ScreenCapture.CaptureScreenshot(DateTime.Now + "- BUtifulFlower.png"); break;
            case 2: { } break;
        }
    }
}
