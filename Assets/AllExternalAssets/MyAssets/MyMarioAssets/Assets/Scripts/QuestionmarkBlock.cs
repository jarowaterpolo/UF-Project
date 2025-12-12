using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class QuestionmarkBlock : MonoBehaviour
{
    public GameObject UsedQBlock;
    public GameObject Coin;
    private Vector3 QBlock;
    private int CoinCount;
    private void Start()
    {
        CoinCount = 0;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnCollisionEnter(Collision collision)
    {
        QBlock = gameObject.transform.position;
        if (CoinCount < 10)
        {
            SpawnCoin();
            CoinCount++;
        }
        else
        {
            QBlockChange();
        }
        
    }

    private void QBlockChange()
    {
        Quaternion Spawnrot = gameObject.transform.rotation;
        Destroy(gameObject);
        Instantiate(UsedQBlock, QBlock, Spawnrot);
    }

    private void SpawnCoin()
    {
        Vector3 CoinPos = QBlock + new Vector3(0, 1, 0);
        Instantiate(Coin, CoinPos, Quaternion.identity);
    }
}
