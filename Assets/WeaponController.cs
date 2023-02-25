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
                /*while(RightClickPressed == true) 
                {
                    SwordBlock();
                    RightClickPressed = Input.GetMouseButtonDown(1);
                }
                */
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

    public void SwordBlock() 
    {
        CanBlock = false;
        Animator anim = IceSword.GetComponent<Animator>();
        anim.SetTrigger("Block");

        StartCoroutine(ResetAttackCooldown());
    }

    IEnumerator ResetAttackCooldown()
    {
        yield return new WaitForSeconds(AttackCoolDown);
        CanAttack = true;
        CanBlock = true;
    }
}
