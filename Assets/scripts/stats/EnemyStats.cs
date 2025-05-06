using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] private float maxHealth = 3f;
    [SerializeField] private float health;


    private void Start() {
        health = maxHealth;
    }

    public void TakeDamage (float damage)
    {
        health -= damage;

        if(health <=0)
        {
            Destroy(gameObject);
        }
    }

}
