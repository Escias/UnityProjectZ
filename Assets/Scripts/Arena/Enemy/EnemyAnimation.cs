using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
    [SerializeField]
    private Animator animationController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack()
    {
        animationController.SetTrigger("attack");
    }

    public bool GetAttack()
    {
        return animationController.GetCurrentAnimatorStateInfo(0).IsName("Z_Attack");
    }
}
