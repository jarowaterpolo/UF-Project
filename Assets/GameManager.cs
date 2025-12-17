using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    [SerializeField] private GameObject[] DevTPs;

    public static double Coins;
    public static double Stars;

    private int PlaceToTP = 0;

    public GameObject Player;
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);  // Prevent duplicates
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);  // Keep it across scenes
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CurrencyReset();
    }

    // Update is called once per frame
    void Update()
    {
        if (instance.DevTPs == null || instance.DevTPs.Any(a => !a))
        {
            instance.DevTPs = GameObject.FindGameObjectsWithTag("DevTP");
        }

        if (instance.Player == null)
        {
            instance.Player = GameObject.FindGameObjectWithTag("player");
        }

        if (Input.GetKeyDown(KeyCode.Tab) && SceneManager.GetActiveScene().buildIndex == 0) 
        {
            DevTP();
        }
        else if (Input.GetKeyDown(KeyCode.F12))
        {
            DevGainCurrency();
        }
    }
    void CurrencyReset()
    {
        Coins = 0;
        Stars = 0;
    }
    
    void DevTP()
    {
        PlaceToTP++;

        if (PlaceToTP >= DevTPs.Length) PlaceToTP = 0;

        Player.transform.position = DevTPs[PlaceToTP].transform.position; 
    }
    void DevGainCurrency()
    {
        GameManager.Stars = 99;
        GameManager.Coins = 99;
    }
}
