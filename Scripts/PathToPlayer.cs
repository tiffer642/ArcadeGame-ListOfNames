using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathToPlayer : MonoBehaviour
{
    [Header("MoveVariables")]
    public float moveSpeed = 1.0f;

    [Header("NavMeshVariables")]
    public NavMeshAgent agent;

    [Header("Target")]
    public GameObject player;
    public GameObject otherTarg;
    private GameObject currentTarget;


    void Start()
    {
        player = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
        if (player.GetComponent<PlayerController>().isHiding == false && player.GetComponent<PlayerController>().isDead == false)
        {
            currentTarget = player;
        }
        else if(player.GetComponent<PlayerController>().isHiding == true || player.GetComponent<PlayerController>().isDead == true)
        {
            currentTarget = otherTarg;
        }

        agent.speed = moveSpeed;
        agent.destination = currentTarget.transform.position;
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            player.GetComponent<PlayerController>().isDead = true;
        }
    }

}
