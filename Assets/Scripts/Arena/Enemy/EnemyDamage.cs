using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private Collider[] spellExplosionCollider;
    public float health;
    private bool d_Explosion;
    private Spawner spawner;

    // Start is called before the first frame update
    void Start()
    {
        spawner = FindObjectOfType<Spawner>();
        d_Explosion = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        spellExplosionCollider = Physics.OverlapSphere(transform.position, 0f);
        foreach (Collider hitCollider in spellExplosionCollider)
        {
            if (hitCollider.gameObject.tag == "SpellExplosion")
            {
                //Change script when HP is active
                spawner.EnemyDecrease();
                Destroy(gameObject);
                break;
            }
        }
    }
}
