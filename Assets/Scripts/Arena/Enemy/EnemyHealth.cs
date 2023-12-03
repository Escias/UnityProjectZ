using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    float healthRemain = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        if (healthRemain > 0)
        {
            healthRemain -= damage;
            if (healthRemain <= 0 )
            {
                Destroy(gameObject);
            }
        }
    }

    public float getEnemyHealth()
    {
        return healthRemain;
    }
}
