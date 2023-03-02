using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiderhealth : MonoBehaviour
{
    public Transform SpideSpawner;
    public GameObject Spider;
    private UnitHealth _spiderHealth = new UnitHealth(100, 100);
    public WeaponController wc;
    private SpiderSpawner spiderspawner = new SpiderSpawner();
    public GameObject steve;
    //Vector3 location = new Vector3(GameObject.Find("SpideSpawner").transform.position);
    void Start()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && wc.IsAttacking)
        {
            SpiderTakeDmg(10);
            Debug.Log(_spiderHealth.Health);
            Debug.Log("test");
        }
    }
    
    public void Update()
    {
        if(_spiderHealth.Health <= 0)
        {
            Instantiate(GameObject.FindGameObjectWithTag("Enemy"), SpideSpawner.position, SpideSpawner.rotation);
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
            SpiderHeal(100);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SpiderTakeDmg(20);
            Debug.Log(_spiderHealth.Health);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            SpiderHeal(10);
            Debug.Log(_spiderHealth.Health);
        }
    }
    private void SpiderTakeDmg(int dmg)
    {
        _spiderHealth.DmgUnit(dmg);
    }

    private void SpiderHeal(int healing)
    {
        _spiderHealth.HealUnit(healing);
    }
}
