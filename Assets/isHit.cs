using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isHit : MonoBehaviour
{

    public Health PlayerHealth;
    public bool isItHit = false;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if (isItHit = true)
        {
            PlayerHealth.EnemyTakeDamge(PlayerHealth.EnemyDamge);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            isItHit = true;
        }
    }
}
