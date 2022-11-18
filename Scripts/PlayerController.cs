using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Other")]
    public bool isHiding = false;

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
        animator.SetFloat("MovementInput", Mathf.Abs(verticalInput) + Mathf.Abs(horizontalInput));

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
    }
}
