using Pinwheel.Griffin;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    PlayerAnimations playerAnimations;
    EnemyHealth enemyHealth;
    Spawner spawner;


    // Start is called before the first frame update
    void Start()
    {
        spawner = FindObjectOfType<Spawner>();
        playerAnimations = FindObjectOfType<PlayerAnimations>();
        enemyHealth = FindObjectOfType<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (playerAnimations.GetSwordAttackStatus() && other.gameObject.tag == "Enemy")
        {
            GameObject EntityHit = other.gameObject;
            enemyHealth = EntityHit.GetComponent<EnemyHealth>();
            enemyHealth.TakeDamage(0.35f);
            if (enemyHealth.getEnemyHealth() <= 0)
            {
                Destroy(EntityHit);
                spawner.EnemyDecrease();
            }
        }
    }
}
