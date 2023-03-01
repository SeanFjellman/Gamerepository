using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHealth
{
   //Feilds
   int _currentHealth;
   int _currentMaxHealth;

   //Properties
   public int Health
   {
        get 
        {
            return _currentHealth;
        }
        set 
        {
            _currentHealth = value;
        }
   }

      public int MaxHealth
   {
        get 
        {
            return _currentMaxHealth;
        }
        set 
        {
            _currentMaxHealth = value;
        }
   }

   // Constructor
    public UnitHealth(int Health, int maxHealth)
    {
        _currentHealth = Health;
        _currentMaxHealth = maxHealth;
    }

    // Methods
    public void DmgUnit(int DmgAmount)
    {
        if (_currentHealth > 0)
        {
            _currentHealth = _currentHealth - DmgAmount;
        }
    }
    public void HealUnit(int HealAmount)
    {
        if (_currentHealth < _currentMaxHealth)
        {
            _currentHealth += HealAmount;
        }
        if (_currentHealth > _currentMaxHealth)
        {
            _currentHealth = _currentMaxHealth;
        }
    }
}
