using UnityEngine;

public class ResourceManage : MonoBehaviour
{
    // Start is called before the first frame update
    public string imgPath { get; set; }
    void Start() => DontDestroyOnLoad(gameObject);
}
