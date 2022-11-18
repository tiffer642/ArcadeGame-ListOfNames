using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI listDisplay;
    public Slider sanityDisplay;

    public GameObject player;
    public GameObject chaser;
    public float chaserSpeed;

    List<string> collecables = new List<string>();


    void Start()
    {
        player = GameObject.Find("Player");
        chaser = GameObject.Find("Chaser");
    }

    // Update is called once per frame
    void Update()
    {
        chaser.GetComponent<PathToPlayer>().moveSpeed = chaserSpeed;
    }

    public void AddToList(string collectedName)
    {
        collecables.Add(collectedName);
        sanityDisplay.value += 0.1f;
        chaserSpeed = sanityDisplay.value * 5;
    }

    public void UpdateList()
    {
        listDisplay.text = "List\n";

        foreach (string collectables in collecables)
        {
            listDisplay.text += collectables + "\n";
        }
    }
}
