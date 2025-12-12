using UnityEngine;

public class DontDestroyOnLoadObjects : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
