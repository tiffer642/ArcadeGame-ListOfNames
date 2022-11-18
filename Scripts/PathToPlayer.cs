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
        agent.speed = moveSpeed;
        agent.destination = currentTarget.transform.position;

        if(player.GetComponent<PlayerController>().isHiding == false)
        {
            currentTarget = player;
        }
    }

    
}
