using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health
{
    private float maxHealth;
    private float currentHealth;

    private bool isDead = false;

    public bool isHit;

    public Health(float maxHealth)
    {
        this.maxHealth = maxHealth;
        currentHealth = maxHealth;
    }

    public float GetHealthPercent()
    {
        return Mathf.Clamp01(currentHealth / maxHealth);
    }

    public void ChangeHealth(float amount)
    {
        currentHealth += amount;

        if (amount < 0) isHit = true;

        if (currentHealth > maxHealth) currentHealth = maxHealth;

        if (currentHealth <= 0) isDead = true;
    }

    public bool GetIsDead()
    {
        return isDead;
    }
}
