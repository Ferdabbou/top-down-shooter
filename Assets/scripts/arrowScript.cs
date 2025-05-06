using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowScript : MonoBehaviour
{
    public float damage = 50f;
    //public GameObject hitEffect;
    void OnCollisionEnter(Collision other) {
       // GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
       // Destroy(effect, 5f);
      
        if(other.gameObject.TryGetComponent<EnemyStats>(out EnemyStats enemyComponent)){
            enemyComponent.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
