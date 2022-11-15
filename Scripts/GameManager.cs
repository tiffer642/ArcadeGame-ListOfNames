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

    List<string> collecables = new List<string>();


    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToList(string collectedName)
    {
        collecables.Add(collectedName);
        sanityDisplay.value += 0.1f;
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
