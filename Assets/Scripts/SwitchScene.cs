using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public int SceneNumberChange;
    public void DoSwitchScene()
    {
        SceneManager.LoadScene(SceneNumberChange);
    }
}
