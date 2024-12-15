using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

public class characterMover : MonoBehaviour
{
    private Transform baseTrans;
    // Start is called before the first frame update
    void Start()
    {
        baseTrans = this.GetComponent<Transform>();
        BaseRotate().Forget();
        
        if(SceneManager.GetActiveScene().name == "Main_Cam")
            transform.parent = GameObject.Find("VideoBackground").transform;
    }

    async UniTask BaseRotate()
    {
        while (true)
        {
            baseTrans.Rotate(0, 3f, 0);
            await UniTask.WaitForSeconds(.1f);
        }
    }
}
