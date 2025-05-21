using UnityEngine;

public class MagicProjectile : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 5f;
    public float damage = 1f;

    public GameObject hitEffect; // Assign your magic impact particle here
    public AudioClip sphereHitSFX;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        // Spawn hit effect
        if (hitEffect != null)
        {
            PlayHitSFX();
            Instantiate(hitEffect, transform.position, Quaternion.identity);
        }

        // Deal damage to player if applicable
        if (other.CompareTag("Player"))
        {
            Debug.Log("Hit Player!");

            if (other.TryGetComponent<PlayerStats>(out PlayerStats playerStats))
            {
                playerStats.TakeDamage(damage);
            }
        }

        Destroy(gameObject); // Always destroy after impact
    }

    void PlayHitSFX()
{
    if (sphereHitSFX != null)
        AudioSource.PlayClipAtPoint(sphereHitSFX, transform.position);
}
}
