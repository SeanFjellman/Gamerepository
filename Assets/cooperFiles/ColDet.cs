using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColDet : MonoBehaviour
{
 public WeaponController wc;
 
 private void OnTriggerEnter(Collider other)
 {
    if (other.tag == "Enemy" && wc.IsAttacking)
    {
        //debug tells you if you hit an enemy or not
        Debug.Log(other.name);
        //add enemy hit animation here 
    }
 }



}
