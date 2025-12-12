using UnityEngine;
using System.Collections;
public class Player : MonoBehaviour
{
    private float xSpd;
    private float zSpd;

    public float MVSPD = 10f;
    public float SprintMult = 2f;
    public float JumpForce = 5f;

    private Rigidbody rb;
    private Animator animator;

    private bool Grounded;

    private bool RequestedJump;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        rb.freezeRotation = true;
        rb.transform.rotation = Quaternion.Euler(0, 90, 0);
    }

    // Update is called once per frame
    void Update()
    {
        CheckGrounded();

        if (Input.GetKey("space"))
        {
            RequestedJump = true;
        }
        else
        {
            RequestedJump = false;
        }

    }

    private void FixedUpdate()
    {
        xSpd = Input.GetAxis("Horizontal");
        zSpd = Input.GetAxis("Vertical");

        //Vector3 movement = new Vector3(xSpd, 0, zSpd) * MVSPD;
        //rb.AddForce(movement);
        if (xSpd > 0 || zSpd > 0)
        {
            Animate();
        }

        Vector3 movement;
        if (Input.GetKey(KeyCode.LeftShift)) 
        {
            movement = transform.forward * zSpd * MVSPD * SprintMult;
        }
        else
        {
            movement = transform.forward * zSpd * MVSPD;
        }

        //rb.AddForce(movement);

        rb.linearVelocity = movement;

        float rotationInput = Input.GetAxis("Horizontal");

        if (rotationInput != 0)
        {
            // Rotate around Y axis
            Quaternion deltaRotation = Quaternion.Euler(0f, rotationInput * 30 * Time.fixedDeltaTime, 0f);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }

        //jump
        if (RequestedJump && Grounded == true)
        {
            Vector3 Jump = (Vector3.up * JumpForce);
            //rb.AddForce(Jump);
            //rb.AddForce(Jump, ForceMode.Impulse);
            rb.linearVelocity = Vector3.up + Jump;
        }
        else
        {
            Vector3 Jump = (-Vector3.up * JumpForce);
            rb.AddForce(Jump / 32, ForceMode.Impulse);
            //rb.linearVelocity = transform.up + Jump / 8;
        }
    }

    void Animate()
    {
        animator.SetBool("Walking", true);
    }
    void CheckGrounded()
    {
        RaycastHit hit;
        //Physics.Raycast(transform.position, -transform.up, out hit, 2f);
        Grounded = Physics.Raycast(transform.position, -transform.up, out hit, .8f);
        Debug.DrawRay(transform.position, -transform.up, Color.blue, hit.distance);
    }
}
