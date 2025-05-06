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
        
        health -= damage;
        HUDManager.instance.UpdateHealth(health, maxHealth);

        if(health <=0)
        {
            HUDManager.instance.HideHUD(); // Hide the HUD
            Destroy(gameObject);
            GameOverManager.instance.ShowGameOver(HUDManager.instance.currentScore);
        }
    }

}
