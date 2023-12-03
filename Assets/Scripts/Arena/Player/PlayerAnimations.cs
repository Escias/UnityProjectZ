using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerAnimations : MonoBehaviour
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

    public void RunForward()
    {
        animationController.SetBool("runForward", true);
    }
    public void RunForwardCancel()
    {
        animationController.SetBool("runForward", false);
    }

    public void SwordSlash()
    {
        animationController.SetTrigger("slash");
    }

    public void LaunchSpell()
    {
        animationController.SetTrigger("spell");
    }

    public bool GetSwordAttackStatus()
    {
        return animationController.GetCurrentAnimatorStateInfo(0).IsName("Great Sword Slash");
    }

    public bool GetSpellAnimationStatus()
    {
        return animationController.GetCurrentAnimatorStateInfo(0).IsName("Spell Cast");
    }

    public void Death()
    {
        animationController.enabled = false;
        animationController.enabled = true;
        animationController.SetBool("death", true);
    }
}
