using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{

    public GameObject IceSword;
    public bool CanAttack = true;
    public float AttackCoolDown = 1.0f;

    //Making audio
    public AudioClip SwordAttackSound;
    public AudioClip Grunt;

    void Update() 
    {
        //Checks if leftClick is pressed down
        if (Input.GetMouseButtonDown(0)) 
        {
            if(CanAttack == true)
            {
                SwordAttack();
            }
        }
    }

    public void SwordAttack() 
    {
        CanAttack = false;
        Animator anim = IceSword.GetComponent<Animator>();
        anim.SetTrigger("Attack");

        //sound
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(SwordAttackSound);

        ac.PlayOneShot(Grunt);


        StartCoroutine(ResetAttackCooldown());
    }

    IEnumerator ResetAttackCooldown()
    {
        yield return new WaitForSeconds(AttackCoolDown);
        CanAttack = true;
    }
}
