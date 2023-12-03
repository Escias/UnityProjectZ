using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private Camera m_Camera;
    [SerializeField]
    private GameObject m_Explosion;
    [SerializeField]
    private GameObject m_Heal;

    private Vector3 lookAt;
    Coroutine c_Explosion;
    Coroutine c_Heal;

    PlayerAnimations playerAnimations;
    PlayerMana playerMana;
    PlayerHealth playerHealth;

    //Spell Cooldown
    private bool spellExplosionCD;
    private bool spellHealCD;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimations = FindObjectOfType<PlayerAnimations>();
        playerMana = FindObjectOfType<PlayerMana>();
        playerHealth = FindObjectOfType<PlayerHealth>();
        spellExplosionCD = false;
        spellHealCD = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHealth.GetStatus())
        {
            Ray cameraRay = m_Camera.ScreenPointToRay(Input.mousePosition);
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            float rayLength;

            if (groundPlane.Raycast(cameraRay, out rayLength))
            {
                Vector3 pointToLook = cameraRay.GetPoint(rayLength);
                lookAt = new Vector3(pointToLook.x, pointToLook.y, pointToLook.z);
            }
            if (Input.GetMouseButtonDown(0) && !playerAnimations.GetSwordAttackStatus()) // Sword Attack
            {
                playerAnimations.SwordSlash();
            }
            if (Input.GetMouseButtonDown(1) && !spellExplosionCD && playerMana.GetManaRemain() >= 0.4f) // Explosion Spell
            {
                playerAnimations.LaunchSpell();
                c_Explosion = StartCoroutine(SpellExplosion());
            }
            if (Input.GetKeyDown("c") && !spellHealCD && playerMana.GetManaRemain() >= 0.20f) // Heal Spell
            {
                c_Heal = StartCoroutine(SpeelHeal());
            }
        }
    }

    IEnumerator SpellExplosion()
    {
        spellExplosionCD = true;
        yield return new WaitForSeconds(0.3f);
        GameObject explosion = Instantiate(m_Explosion, lookAt, Quaternion.Euler(new Vector3(0, 0, 0)));
        playerMana.UseMana(0.4f);
        yield return new WaitForSeconds(1.3f);
        Destroy(explosion);
        yield return new WaitForSeconds(1.2f);
        spellExplosionCD = false;
        StopCoroutine(c_Explosion);
    }

    IEnumerator SpeelHeal()
    {
        spellHealCD = true;
        yield return new WaitForSeconds(0.3f);
        GameObject heal = Instantiate(m_Heal, new Vector3(transform.position.x, transform.position.y + 0.77f, transform.position.z), Quaternion.Euler(new Vector3(0, 0, 0)));
        playerHealth.Heal(0.20f);
        heal.transform.parent = gameObject.transform;
        playerMana.UseMana(0.2f);
        yield return new WaitForSeconds(1.3f);
        Destroy(heal);
        yield return new WaitForSeconds(8.7f);
        spellHealCD = false;
        StopCoroutine(c_Heal);
    }
}
