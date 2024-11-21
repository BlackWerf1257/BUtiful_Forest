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

    //private void Start() => color = rend.material.color;

    public void CharacterEvent(int charcterIdx)
    {
        GameObject newCharacter = GameObject.Instantiate(characterArray?[charcterIdx]);
        if (newCharacter != null)
        {
            newCharacter.transform.SetParent(chracterParentObj);
            ARObj.Add(newCharacter);
            ARRendObj.Add(newCharacter.GetComponent<Renderer>());
            
            newCharacter.transform.rotation = Quaternion.Euler(0, -90, 0);

            switch (charcterIdx)
            {
                case 0:
                {
                    newCharacter.transform.localScale = Vector3.one * 12000;
                    newCharacter.transform.localPosition = new Vector3(800, -300, 2000);
                }  break;
                case 1:
                {
                    newCharacter.transform.localScale = Vector3.one * 400;
                    newCharacter.transform.localPosition = new Vector3(800, 400, 2000);
                    
                } break;
            }
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
        foreach (var rendVar in ARRendObj)
        {
            Color characterColor = rendVar.material.color;
            characterColor.a = visSlider.value;
            rendVar.material.color = characterColor;
        }

        foreach (Renderer rendVar in ParticleRendList)
        {
            Color particleColor = rendVar.material.color;
            particleColor.a = visSlider.value;
            rendVar.material.color = particleColor;
        }
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
