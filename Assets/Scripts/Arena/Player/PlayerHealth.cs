using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image health;
    public float healthRemain = 1;
    PlayerAnimations playerAnimations;
    bool playerAlive;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimations = FindObjectOfType<PlayerAnimations>();
        playerAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        health.fillAmount = healthRemain;
    }

    public void TakeDamage(float damage)
    {
        if (healthRemain <= 1)
        {
            healthRemain -= damage;
            if (healthRemain <= 0)
            {
                healthRemain = 0;
                playerAlive = false;
                playerAnimations.Death();
            }
        }
    }

    public void Heal(float heal)
    {
        if (healthRemain < 1)
        {
            healthRemain += heal;
            if (healthRemain >= 1)
            {
                healthRemain = 1;
            }
        }
    }

    public bool GetStatus() { return playerAlive; }
}
