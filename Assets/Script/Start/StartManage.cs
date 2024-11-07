using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if !UNITY_EDITOR && UNITY_ANDROID
using( AndroidJavaClass ajc = new AndroidJavaClass( "com.yasirkula.unity.NativeGalleryMediaPickerFragment" ) )
	ajc.SetStatic<bool>( "GrantPersistableUriPermission", true );
#endif
using System.IO;

public class StartManage : MonoBehaviour
{
   [SerializeField] private ScrollRect creditsObj;
   [SerializeField] private GameObject parentObj;
   
   
   
   public void StartEvent(int idx)
   {
      switch (idx)
      {
         case 0: SceneManager.LoadScene("Main_Cam"); break;
         case 1:
         {
               ;
            //SceneManager.LoadScene("Main_Gallery");

         } break;
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
   
   
   #region Gallery

   void CheckPermission()
   {
      //
      NativeGallery.Permission permissions = new NativeGallery.Permission();
      if (permissions == NativeGallery.Permission.Granted)
         Debug.Log("Permission granted");
      //NativeGallery.Permission permission = 
   }

   void LoadFile()
   {
      NativeGallery.GetImageFromGallery(file =>
      {
         FileInfo fileInfo = new FileInfo(file);
         //용량 제한
         if (fileInfo.Length > 10) return;
         
      });
   }

   #endregion
}
