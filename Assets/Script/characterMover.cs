using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading;
using Cysharp.Threading.Tasks;

public class characterMover : MonoBehaviour
{
    private Transform baseTrans;
    // Start is called before the first frame update
    void Start()
    {
        baseTrans = this.GetComponent<Transform>();
        BaseRotate().Forget();
    }

    async UniTask BaseRotate()
    {
        while (true)
        {
            baseTrans.Rotate(0, 15, 0);
        }
    }
}
