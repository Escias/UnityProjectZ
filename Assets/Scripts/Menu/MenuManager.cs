using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    GameObject settingPanel;
    GameObject informationPanel;

    // Start is called before the first frame update
    void Start()
    {
        settingPanel = GameObject.FindGameObjectWithTag("ControlPanel");
        informationPanel = GameObject.FindGameObjectWithTag("VersionPanel");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame()
    {
        SceneManager.LoadScene("ArenaScene");
    }

    public void ShowSettings()
    {
        informationPanel.SetActive(false);
        settingPanel.SetActive(true);
    }

    public void CloseSetting()
    {
        settingPanel.SetActive(false);
    }

    public void CloseInformation()
    {
        informationPanel.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
