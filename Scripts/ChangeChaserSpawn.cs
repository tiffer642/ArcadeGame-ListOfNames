using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeChaserSpawn : MonoBehaviour
{
    public ArrayList listOfSpawns;
    public int spawnNumber;
    public GameObject currentSpawn;

    private void Start()
    {
        listOfSpawns.Add(GameObject.FindGameObjectsWithTag("Spawn"));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            spawnNumber = Random.Range(1, 5);
        }
    }

    private void RandomSpawn()
    {
        switch(spawnNumber)
        {
            case 1:
                currentSpawn = (GameObject)listOfSpawns[1];
                break;
            case 2:
                currentSpawn = (GameObject)listOfSpawns[2];
                break;
            case 3:
                currentSpawn = (GameObject)listOfSpawns[3];
                break;
            case 4:
                currentSpawn = (GameObject)listOfSpawns[4];
                break;
            case 5:
                currentSpawn = (GameObject)listOfSpawns[5];
                break;
        }
    }
}
