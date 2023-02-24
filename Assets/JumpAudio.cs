using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAudio : MonoBehaviour
{
    // Start is called before the first frame update
    public bool CanJump = true;
    public float JumpCoolDown = 1.0f;

    public AudioClip Jump;

    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Space) && CanJump == true)
        {
           Jumping();
        }
    }


    public void Jumping() 
    {
        CanJump = false;
        AudioSource jp = GetComponent<AudioSource>();
        jp.PlayOneShot(Jump);

        StartCoroutine(ResetJumpCooldown());
    }


    IEnumerator ResetJumpCooldown() 
    {
        yield return new WaitForSeconds(JumpCoolDown);
        CanJump = true;
    }
}
