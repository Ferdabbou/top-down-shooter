using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
     [SerializeField] float health, maxHealth = 3f;

    private void Start() {
        health = maxHealth;
    }

    public void TakeDamage (float damage)
    {
        HUDManager.instance.UpdateHealth(health, maxHealth);
        health -= damage;

        if(health <=0)
        {
            Destroy(gameObject);
        }
    }

}
