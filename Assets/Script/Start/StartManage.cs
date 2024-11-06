using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartManage : MonoBehaviour
{
   [SerializeField] private ScrollRect creditsObj;
   [SerializeField] private GameObject parentObj;
   
   public void StartEvent(int idx)
   {
      switch (idx)
      {
         case 0: SceneManager.LoadScene("Main_Cam"); break;
         case 1: SceneManager.LoadScene("Main_Gallery"); break;
      }
   }
   public void Quit() => Application.Quit();

   public void Credits(bool isOn)
   {
      if (isOn)
      {
         if (creditsObj is null) return;
         creditsObj.gameObject.SetActive(true);
         parentObj.SetActive(false);
      }
      else
      {
         parentObj.SetActive(true);
         creditsObj.gameObject.SetActive(false);   
      }
   }
}
