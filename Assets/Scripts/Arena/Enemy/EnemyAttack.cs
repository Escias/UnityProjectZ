using Pinwheel.Griffin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private GameObject player;
    bool attack;
    EnemyAnimations enemyAnimations;
    PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemyAnimations = FindObjectOfType<EnemyAnimations>();
        playerHealth = FindObjectOfType<PlayerHealth>();
        attack = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetDistance() <= 1.5f && !enemyAnimations.GetAttack())
        {
            attack = true;
            enemyAnimations.Attack();
        }
        
    }

    float GetDistance()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);
        return dist;
    }

    void OnTriggerEnter(Collider other)
    {
        if (attack && other.gameObject.CompareTag("Player"))
        {
            GameObject EntityHit = other.gameObject;
            playerHealth = EntityHit.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(0.05f);
            attack = false;
        }
    }
}
