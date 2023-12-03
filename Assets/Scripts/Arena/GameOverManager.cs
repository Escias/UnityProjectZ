using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    GameObject gameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel = GameObject.FindGameObjectWithTag("EndMenu");
    }

    // Update is called once per frame
    void Update()
    {
        
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
