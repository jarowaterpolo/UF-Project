using UnityEngine;

public class OpenGate : MonoBehaviour
{
    public GameObject InvisableGateBarrier;
    public GameObject[] GoldenBars;
    public Animator[] GolderBarAnimators;
    public GameObject[] ParticleWallPieces;
    public AudioSource GateUnlock;

    private bool GateOpend = false;
    private int IntOpenGate = 0;
    private bool InGateCollider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GateUnlock == null)
        {
            GameObject gateAudioObject = GameObject.FindGameObjectWithTag("GateAudio");
            GateUnlock = gateAudioObject.GetComponent<AudioSource>();
        }

        if (IntOpenGate == 5)
        {
            GateOpend = true;
        }

        if (GateOpend == true) 
        { 
            InvisableGateBarrier.SetActive(false);
        }
        else
        {
            InvisableGateBarrier.SetActive(true);
        }

        if (InGateCollider == true && Input.GetKeyDown(KeyCode.E))
        {
            OpenPartGate();
        }

    }

    private void OnTriggerStay(Collider other)
    {
        
        if (other.CompareTag("player") )
        {
            InGateCollider = true;  
        }
        else
        {
            InGateCollider = false;
        }
    }

    private void OpenPartGate()
    {
        if (GameManager.Stars > 0 && IntOpenGate < 5)
        {
            GameManager.Stars--;
            IntOpenGate++;
            //GoldenBars[IntOpenGate - 1].SetActive(false);
            GolderBarAnimators[IntOpenGate - 1].SetBool("Activated", true);
            ParticleWallPieces[IntOpenGate - 1].SetActive(false);
            GateUnlock.Play();
        }
    }
}
