using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    public Transform plane;

    [SerializeField]
    public GameObject m_Enemy;

    [SerializeField]
    private TMP_Text m_EnemyText;

    [SerializeField]
    private TMP_Text m_WaveText;

    // Wave properties
    float currentWave = 1;
    public float maxEnemySpawn;
    float currentEnemy;
    float enemyToKill;
    bool startWave;
    bool endWave;
    Coroutine c_Spawn;

    GameManager gameManager;
    SceneChanger sceneChanger;

    // Plane Properties
    float x_dim;
    float z_dim;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        sceneChanger = FindObjectOfType<SceneChanger>();
        startWave = true;
        endWave = false;
        currentEnemy = 0;
        x_dim = plane.GetComponent<MeshRenderer>().bounds.size.x;
        z_dim = plane.GetComponent<MeshRenderer>().bounds.size.z;
        x_dim /= 2;
        z_dim /= 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentEnemy <= 0 && startWave)
        {
            enemyToKill = maxEnemySpawn;
            currentEnemy = 0;
            gameManager.UpdateCurrentWaveText(currentWave);
            gameManager.UpdateEnemyToKillText(enemyToKill);
            StartWave();
        }
        if (!startWave && endWave && Input.GetKeyDown(KeyCode.E))
        {
            sceneChanger.ChangeScene("VillageScene");
        }
    }

    void StartWave()
    {
        startWave=false;
        c_Spawn = StartCoroutine(BeginWave());
    }

    IEnumerator BeginWave()
    {
        while (currentEnemy != maxEnemySpawn)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.2f);
        }
        StopCoroutine(c_Spawn);
    }

    void SpawnEnemy()
    {
        var enemy = Instantiate(m_Enemy, new Vector3(Random.Range(plane.position.x - x_dim, plane.position.x + x_dim), 0, Random.Range(plane.position.z - z_dim, plane.position.z + z_dim)), Quaternion.identity);
        enemy.transform.parent = gameObject.transform;
        currentEnemy++;
    }

    public void EnemyDecrease()
    {
        enemyToKill--;
        gameManager.UpdateEnemyToKillText(enemyToKill);
        if (enemyToKill <= 0)
        {
            currentEnemy = 0;
            EndWave();
        }
    }

    void EndWave()
    {
        endWave = true;
        gameManager.StartCoroutineCoundown();
    }

    public void StartNextWave()
    {
        endWave = false;
        startWave = true;
        currentWave++;
        maxEnemySpawn = Mathf.FloorToInt(maxEnemySpawn * (1f + ((currentWave - 1) / 10)));
    }
}
