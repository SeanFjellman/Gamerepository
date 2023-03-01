using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiderhealth : MonoBehaviour
{
    private UnitHealth _spiderHealth = new UnitHealth(100, 100);
    public WeaponController wc;

    private void OnTriggerEnter(Collider other)
    {
     if (other.tag == "Enemy" && wc.IsAttacking)
        {
            SpiderTakeDmg(10);
            Debug.Log(_spiderHealth.Health);
            Debug.Log("test");
        }
        else 
        {
            Debug.Log("eysath");
        }
    }

    private void SpiderTakeDmg(int dmg)
    {
        _spiderHealth.DmgUnit(dmg);
    }
}
