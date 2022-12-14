using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Other")]
    public bool isDead = false;

    [Header("Hiding Mechanics")]
    public GameObject hidingSpot;
    public GameObject hidingSpotExit;
    public bool isHiding = false;
    public bool hidingInRange = false;

    [Header("MovementVariables")]
    public float moveSpeed;
    public float maxSpeed;
    public float verticalInput;
    public float horizontalInput;
    public Vector3 movementDirection;

    private bool moving;

    [Header("Componants")]
    public Rigidbody rb;
    public Animator animator;
    public GameManager gm;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void Update()
    {
        verticalInput = Input.GetAxisRaw("Vertical");
        horizontalInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetButton("Hide") && hidingInRange == true)
        {
            isHiding = true;
            transform.position = hidingSpot.transform.position;
        }
        else if(Input.GetButtonUp("Hide") && isHiding == true)
        {
            isHiding = false;
            transform.position = hidingSpotExit.transform.position;
        }

        if(Input.GetButtonDown("Hide"))
        {
            gm.GetComponent<GameManager>().HasEBeenPressed = true;
        }
        else
        {
            gm.GetComponent<GameManager>().HasEBeenPressed = false;
        }

        if (isHiding == false)
        {
            rb.isKinematic = false;
            animator.SetFloat("MovementInput", Mathf.Abs(verticalInput) + Mathf.Abs(horizontalInput));
        }
        else
        {
            rb.isKinematic = true;
            animator.SetFloat("MovementInput", 0);
        }

        movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();

        if (movementDirection != Vector3.zero)
        {
            transform.forward = movementDirection;
        }

        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        }

        if(Mathf.Abs(verticalInput) > 0 || Mathf.Abs(horizontalInput) > 0)
        {
            moving = true;
        }
        else { moving = false; }

        if(isDead == true)
        {
            animator.SetBool("IsDead", true);
            gm.GameOver();
        }
    }

    void FixedUpdate()
    {
        if(moving == true)
        {
            rb.AddForce(transform.forward * moveSpeed, ForceMode.Force);
        }
        else if(moving == false) { rb.velocity = Vector3.zero; }
            
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Collectable"))
        {
            Destroy(other.gameObject);
            gm.AddToList(other.name);
            gm.UpdateList();
        }

        if(other.CompareTag("HidingSpot"))
        {
            hidingInRange = true;
            hidingSpot = other.gameObject;
        }

        if(other.CompareTag("Exit"))
        {
            hidingSpotExit = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("HidingSpot"))
        {
            hidingInRange = false;
            hidingSpot = null;
        }

        if (other.CompareTag("Exit"))
        {
            hidingSpotExit = null;
        }
    }
}
