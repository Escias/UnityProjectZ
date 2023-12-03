using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    GameObject gameOverPanel;
    PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel = GameObject.FindGameObjectWithTag("EndMenu");
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerHealth.GetStatus())
        {
            gameOverPanel.SetActive(true);
        }
        else
        {
            gameOverPanel.SetActive(false);
        }
    }

    public void Restart()
    {
        gameOverPanel.SetActive(false);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void ReturnToMainMenu()
    {
        gameOverPanel.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        gameOverPanel.SetActive(false);
        Application.Quit();
    }
}
