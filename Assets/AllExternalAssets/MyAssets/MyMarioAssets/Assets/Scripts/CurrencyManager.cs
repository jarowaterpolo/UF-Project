using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CurrencyManager : MonoBehaviour
{
    public AudioSource[] CoinAudio;
    private GameObject[] CoinAudioObjects;
    public TMP_Text CoinText;

    public AudioSource StarAudio;

    public TMP_Text StarsText;

    public GameObject Star;
    public void Start()
    {
        GetAudio();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
            if (GameManager.Coins < 99)
            {
                GameManager.Coins += 1;
            }
            CoinAudio[Random.Range(0,CoinAudio.Length)].Play();
        }

        if (collision.gameObject.tag == "Trader")
        {
            if (GameManager.Coins > 20) 
            {
                GameManager.Coins -= 20;
                Vector3 pos = gameObject.transform.position;
                Quaternion rot = gameObject.transform.rotation;

                Vector3 SpawnPos = pos + transform.forward * 3 + transform.up * 10; 
                Instantiate(Star, SpawnPos, rot);
            }
            UpdateText();
        }

        if (collision.gameObject.tag == "Star")
        {
            Destroy(collision.gameObject);
            if (GameManager.Stars < 99)
            {
                GameManager.Stars += 1;
            }
            StarAudio.Play();
        }
    }

    private void Update()
    {
        UpdateText();
        int i = 0;
        if (i != SceneManager.GetActiveScene().buildIndex)
        {
            ForceGetAudio();
        }

        i = SceneManager.GetActiveScene().buildIndex;
    }

    void UpdateText()
    {
        CoinText.text = GameManager.Coins + "";
        StarsText.text = GameManager.Stars + "";
    }

    void GetAudio()
    {
        if (CoinAudio == null)
        {
            CoinAudioObjects = GameObject.FindGameObjectsWithTag("CoinAudio");
            int i = 0;
            foreach (GameObject gameObject in CoinAudioObjects)
            {
                CoinAudio[i] = CoinAudioObjects[i].GetComponent<AudioSource>();
                i++;
            }
        }

        if (StarAudio == null) 
        {
            GameObject StarAudioSourceGameObject = GameObject.FindGameObjectWithTag("StarAudio");
            StarAudio = StarAudioSourceGameObject.GetComponent<AudioSource>();
        }

    }

    void ForceGetAudio()
    {
        CoinAudioObjects = GameObject.FindGameObjectsWithTag("CoinAudio");
        int i = 0;
        foreach (GameObject gameObject in CoinAudioObjects)
        {
            CoinAudio[i] = CoinAudioObjects[i].GetComponent<AudioSource>();
            i++;
        }

        GameObject StarAudioSourceGameObject = GameObject.FindGameObjectWithTag("StarAudio");
        StarAudio = StarAudioSourceGameObject.GetComponent<AudioSource>();
    }
}
