using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float maxSpeed;
    public Rigidbody rb;

    public GameManager gm;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    
    void Update()
    {
        float verticalInput = Input.GetAxisRaw("Vertical");
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        
        if(verticalInput == 1)
        {
            rb.AddForce(Vector3.forward * moveSpeed, ForceMode.Force);
        }
        else if(verticalInput == -1)
        {
            rb.AddForce(Vector3.back * moveSpeed, ForceMode.Force);
        }

        if(horizontalInput == 1)
        {
            rb.AddForce(Vector3.right * moveSpeed, ForceMode.Force);
        }
        else if(horizontalInput == -1)
        {
            rb.AddForce(Vector3.left * moveSpeed, ForceMode.Force);
        }

        if(rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        }
            
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
