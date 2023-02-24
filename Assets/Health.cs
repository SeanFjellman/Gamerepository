using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount = 100f;
    public float Damage = 20f;
    public float HealingPoints = 10f;


    public Image EnemyHealthBar;
    public float EnemyHealthAmount = 100f;
    public float EnemyDamge = 20f;
    public float EnemyHeals = 10f;

    public GameObject Spider;

    //Audio
    public AudioClip OhYeahhh;
    public AudioClip Scream;

    public float AudioCoolDown = 5.0f;

    private void Update() 
    {
        //loads game if character dies
        if (healthAmount <= 0)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
        //healing man character
        if(Input.GetKeyDown(KeyCode.E))
        {
            Healing(HealingPoints);
        }
        //Damages Character
        if(Input.GetKeyDown(KeyCode.R)) 
        {
            TakeDamage(Damage);
        }

        //Damages Enemy
        if (Input.GetMouseButtonDown(0)) 
        {
            EnemyTakeDamge(EnemyDamge);
        }
        if (Input.GetKeyDown(KeyCode.F)) 
        {
            EnemyHealing(EnemyHeals);
        }
        //Destroying Spider
        if(EnemyHealthAmount <= 0) 
        {
            Destroy(Spider);
            AudioSource ac = GetComponent<AudioSource>();
            ac.PlayOneShot(Scream);
            ResetAudio();
            ac.PlayOneShot(OhYeahhh);
            EnemyHealthAmount = EnemyHealthAmount + 100;
        }
    }

    public void TakeDamage(float Damage) 
    {
        healthAmount = healthAmount - Damage;
        healthBar.fillAmount = healthAmount / 100;
    }

    public void Healing(float healPoints) 
    {
        healthAmount = healthAmount + healPoints;
        healthAmount = Mathf.Clamp(healthAmount, 0, healthAmount);

        healthBar.fillAmount = healthAmount / 100;
    }

    public void EnemyTakeDamge(float EDamagePoints) 
    {
        EnemyHealthAmount = EnemyHealthAmount - EnemyDamge;
        EnemyHealthBar.fillAmount = EnemyHealthAmount / 100;
    }

    public void EnemyHealing(float EHealingPoints) 
    {
        EnemyHealthAmount = EnemyHealthAmount + EHealingPoints;
        EnemyHealthAmount = Mathf.Clamp(EnemyHealthAmount, 0, EnemyHealthAmount);

        EnemyHealthBar.fillAmount = EnemyHealthAmount / 100;
    }
    IEnumerator ResetAudio()
    {
        yield return new WaitForSeconds(AudioCoolDown);
    }
}