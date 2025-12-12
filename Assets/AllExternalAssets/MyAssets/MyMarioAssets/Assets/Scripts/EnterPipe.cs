using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterPipe : MonoBehaviour
{
    //static int AreaNumber;
    public int TargetAreaTP;
    public AudioSource PipeEnterSound;

    private void Start()
    {
        //AreaNumber = SceneManager.GetActiveScene().buildIndex;

        if (PipeEnterSound == null)
        {
            GameObject PipeAudio = GameObject.FindGameObjectWithTag("PipeAudio");
            PipeEnterSound = PipeAudio.GetComponent<AudioSource>();
        }
    }

    //old
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (AreaNumber > 1)
    //    {
    //        AreaNumber = 0;
    //    }

    //    if (collision.gameObject.tag == "player")
    //    {
    //        AreaNumber += 1;
    //        SceneManager.LoadScene(AreaNumber);
    //    }

    //}

    //new
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "player" && Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (PipeEnterSound != null) 
            {
                PipeEnterSound.Play();
            }
            SceneManager.LoadScene(TargetAreaTP);
        }
    }
}
