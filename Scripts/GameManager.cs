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
    public TextMeshProUGUI gameWonText;
    public bool HasEBeenPressed = false;
    public int numberOfItems = 0;

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
        if (HasEBeenPressed == true)
        {
            chaser.GetComponent<PathToPlayer>().spawn.gameObject.GetComponent<ChangeChaserSpawn>().ChangeSpawn(Random.Range(1, 5));
        }

        if (Input.GetButtonDown("Start"))
        {
            StartGame();
        }

        if (Input.GetButtonDown("Reset"))
        {
            RestartGame();
        }

        if (numberOfItems >= 6)
        {
            GameWon();
        }
    }
    public void AddToList(string collectedName)
    {
        collecables.Add(collectedName);
        sanityDisplay.value += 0.1f;
        chaserSpeed = sanityDisplay.value * 5;
        numberOfItems++;
    }

    public void UpdateList()
    {
        listDisplay.text = "List " + numberOfItems + "/6\n";

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

    public void GameWon()
    {
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
        gameWonText.gameObject.SetActive(true);
    }
}
