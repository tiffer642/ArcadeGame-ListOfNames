using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeChaserSpawn : MonoBehaviour
{
    public GameObject[] spawns;
    public GameObject currentSpawn;
    public int spawnNumber = 5;
    public int num;

    private void Start()
    {
        ChangeSpawn(Random.Range(1, 5));
        Debug.Log("CHANGE SPAWN START");
    }

    public void ChangeSpawn(int num)
    {
        Debug.Log("CHANGED SPAWN TO: " + num);
        spawnNumber = num;

        switch(spawnNumber)
        {
            case 1:
                transform.position = spawns[spawnNumber].transform.position;
                currentSpawn = spawns[spawnNumber];
                break;
            case 2:
                transform.position = spawns[spawnNumber].transform.position;
                currentSpawn = spawns[spawnNumber];
                break;
            case 3:
                transform.position = spawns[spawnNumber].transform.position;
                currentSpawn = spawns[spawnNumber];
                break;
            case 4:
                transform.position = spawns[spawnNumber].transform.position;
                currentSpawn = spawns[spawnNumber];
                break;
            case 5:
                transform.position = spawns[spawnNumber].transform.position;
                currentSpawn = spawns[spawnNumber];
                break;
        }
    }
}
