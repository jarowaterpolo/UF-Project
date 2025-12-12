using TMPro;
using UnityEngine;

public class GoombaNPCText : MonoBehaviour
{
    public TMP_Text NPCText;
    public string SetNPCText;
    public GameObject NPC_Cloud;
    private bool NPC_CloudVisable = false;

    private void Awake()
    {
        NPC_Cloud.SetActive(false);
    }
    private void Update()
    {
        if (NPC_CloudVisable == true)
        {
            NPC_Cloud.SetActive(true);
        }
        else
        {
            NPC_Cloud.SetActive(false);
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "player")
        {
            Debug.Log(other.tag + other.name);
            Debug.Log("player found in trigger");
            NPC_CloudVisable = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
            NPCText.text = SetNPCText;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        NPC_CloudVisable = false;
    }
}
