using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FFS_CharacterStats : MonoBehaviour {

    public int maxHealth = 100;
    public int currentHealth { get; private set; }

    public FFS_Stat damage;
    public FFS_Stat armor;
    public FFS_Stat speed;
    public FFS_Stat bulletSpeed;
    public FFS_Stat fireRate;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        //Die
        Debug.Log(transform.name + " died.");
    }
}
