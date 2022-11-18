using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("UI display")]
    public TextMeshProUGUI listDisplay;
    public Slider sanityDisplay;

    [Header("CharacterVariables")]
    public GameObject player;
    public GameObject chaser;
    public float chaserSpeed;

    [Header("GameManagement")]
    public bool isGameActive;
    public Button restartButton;
    public GameObject titleScreen;
    public TextMeshProUGUI gameOverText;

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

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        titleScreen.gameObject.SetActive(false);
        isGameActive = true;
    }
}
