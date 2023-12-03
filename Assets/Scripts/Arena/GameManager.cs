using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text m_WaveCountText;

    [SerializeField]
    private TMP_Text m_EnemyCountText;

    [SerializeField]
    private TMP_Text m_CountDownText;

    public GameObject gameOverPanel;

    Coroutine c_CountdownNextWave;

    Spawner spawner;

    // Start is called before the first frame update
    void Start()
    {
        spawner = FindObjectOfType<Spawner>();
        gameOverPanel = GameObject.FindGameObjectWithTag("EndMenu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateCurrentWaveText(float currentWave)
    {
        m_WaveCountText.text = "Wave: " + currentWave.ToString();
    }

    public void UpdateEnemyToKillText(float enemyToKill)
    {
        m_EnemyCountText.text = "Enemies: " + enemyToKill.ToString();
    }

    public void StartCoroutineCoundown()
    {
        c_CountdownNextWave = StartCoroutine(StartCountdownNextWave());
    }

    IEnumerator StartCountdownNextWave()
    {
        int countdownValue = 5;

        while (countdownValue > 0)
        {
            m_CountDownText.text = "Next wave in " + countdownValue.ToString();
            yield return new WaitForSeconds(1f);

            countdownValue--;
        }
        m_CountDownText.text = "GO!";
        yield return new WaitForSeconds(1f);
        m_CountDownText.text = "";
        spawner.StartNextWave();
        StopCoroutine(c_CountdownNextWave);
    }

    public void SetGameOverPanelActive()
    {
        gameOverPanel.SetActive(true);
    }
}
