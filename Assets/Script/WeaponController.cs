using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{

    public GameObject IceSword;
    public bool CanAttack = true;
    public bool CanBlock = true;
    public float BlockCoolDown = 1.0f;
    public float AttackCoolDown = 1.0f;
    public bool RightClickPressed = false;
    public bool BlockRelease = false;
    public bool IsAttacking = false;

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

        if (Input.GetMouseButtonDown(1)) 
        {
            RightClickPressed = true;
            if (CanBlock == true) 
            {
                SwordBlock();
                RightClickPressed = false;
                 

            }
        }

        if (Input.GetMouseButtonUp(1))
        {
            Animator anim = IceSword.GetComponent<Animator>();
            anim.SetTrigger("RightCickReleased");
        }
    }

    public void SwordAttack() 
    {
        IsAttacking = true;
        CanAttack = false;
        Animator anim = IceSword.GetComponent<Animator>();
        anim.SetTrigger("Attack");

        //sound
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(SwordAttackSound);

        ac.PlayOneShot(Grunt);


        StartCoroutine(ResetAttackCooldown());
    }

    public void SwordBlock() 
    {
        CanBlock = false;
        Animator anim = IceSword.GetComponent<Animator>();
        anim.SetTrigger("Block");

        StartCoroutine(ResetAttackCooldown());
    }

    IEnumerator ResetAttackCooldown()
    {
        StartCoroutine(ResetAttackBool());
        yield return new WaitForSeconds(AttackCoolDown);
        CanAttack = true;
        CanBlock = true;
    }

    IEnumerator ResetAttackBool()
    {
        yield return new WaitForSeconds(1.0f);
        IsAttacking = false;
    }
}
