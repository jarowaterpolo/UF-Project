using UnityEngine;

public class ObjectActiveSetter : MonoBehaviour
{
    public void GameObjectActivate()
    {
        gameObject.SetActive(true);
    }

    public void GameObjectDeactivate()
    {
        gameObject.SetActive(false);
    }
}
