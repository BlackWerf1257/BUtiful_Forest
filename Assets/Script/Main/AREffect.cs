using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AREffect : MonoBehaviour
{
    #region AR_Effect
    #region AR 오브젝트 배치
    List<GameObject> ARObj = new();
    List<Renderer> ARRendObj = new();
    [SerializeField] private Transform chracterParentObj;

    [Header("스티커 모음")]
    [SerializeField] private GameObject[] characterArray = new GameObject[3];

    [SerializeField] private Renderer rend;
    private Color color;

    private void Start() => color = rend.material.color;

    public void CharacterEvent(int charcterIdx)
    {
        GameObject newCharacter = GameObject.Instantiate(characterArray?[charcterIdx]);
        if (newCharacter != null)
        {
            newCharacter.transform.localPosition = new Vector3(0, 0, 0);
            newCharacter.transform.localRotation = new Quaternion(0, 90, 0,90);
            newCharacter.transform.localScale = Vector3.one * 2000;
            newCharacter.transform.SetParent(chracterParentObj);
            ARObj.Add(newCharacter);
            ARRendObj.Add(newCharacter.GetComponent<Renderer>());
        }
        else Debug.LogError("캐릭터가 존재하지않습니다");
    }
    #endregion

    #region 테마
    void ThemeEvent()
    {

    }
    #endregion

    #region 투명도
    [SerializeField] Slider visSlider;
    public void VisibilityEvent()
    {
        //color.a = visSlider.value;

        foreach (Renderer rendVar in ARRendObj)
        {
            Color c = rendVar.material.color;
            c.a = visSlider.value;
            rendVar.material.color = color;
        }

        foreach (Renderer rendVar in ParticleRendList)
            rendVar.material.color = color;
    }
    #endregion

    #region 효과
    [Header("효과")]
    [SerializeField] private GameObject[] ParticleArray = new GameObject[4];
    List<GameObject> ParticleList = new();
    List<Renderer> ParticleRendList = new();
    public void EffectEvent(int particleIdx)
    {
        GameObject newEffect = GameObject.Instantiate(ParticleArray?[particleIdx]);
        if (newEffect != null)
        {
            ParticleList.Add(newEffect);
            ParticleRendList.Add(newEffect.GetComponent<Renderer>());
        }
        else Debug.LogError("캐릭터가 존재하지않습니다");
    }
    #endregion
#endregion
}
