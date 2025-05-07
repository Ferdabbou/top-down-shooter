using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowScript : MonoBehaviour
{
    public float damage = 50f;
    public GameObject bloodEffect;      // Assign blood particle prefab
    public GameObject impactEffect;     // Assign wood/dust particle prefab
    public AudioClip bloodHitSFX;

    private void OnCollisionEnter(Collision other)
    {
        ContactPoint contact = other.contacts[0];
        PlayBloodSFX();

        // 1. Check if we hit an enemy
        if (other.gameObject.TryGetComponent<EnemyStats>(out EnemyStats enemyComponent))
        {
            enemyComponent.TakeDamage(damage);

            // Spawn blood effect
            if (bloodEffect != null)
            {
                Instantiate(bloodEffect, contact.point, Quaternion.LookRotation(contact.normal));
            }
        }
        else
        {
            // 2. Otherwise assume it's environment (tree, ground, etc.)
            if (impactEffect != null)
            {
                Instantiate(impactEffect, contact.point, Quaternion.LookRotation(contact.normal));
            }
        }

        Destroy(gameObject); // Destroy the arrow after impact
    }

    void PlayBloodSFX()
    {
        if (bloodHitSFX != null)
            AudioSource.PlayClipAtPoint(bloodHitSFX, transform.position);
    }   
}
