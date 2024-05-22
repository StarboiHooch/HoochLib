using System;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onHit = new UnityEvent();

    public EventHandler<EventArgs> onHitCallback;

    [SerializeField]
    private UnityEvent onDeath = new UnityEvent();

    [SerializeField]
    private int maxHealth = 1;
    private int health = 0;

    private void Start()
    {
        health = maxHealth;
    }

    public void SetHealth(int newHealth)
    {
        if (newHealth <= maxHealth && newHealth >= 0)
        {
            health = newHealth;
            if (health == 0)
            {
                Die();
            }
        }
    }

    public void Die()
    {
        health = 0;
        onDeath?.Invoke();
    }

    public void TakeDamage(int damage)
    {
        if (damage >= 0)
        {
            onHitCallback?.Invoke(this, EventArgs.Empty);
            onHit.Invoke();
            health -= damage;
            if (health <= 0)
            {
                Die();
            }
        }
        else
        {
            Debug.LogError("Damage cannot be negative. Use Heal instead.");
        }
    }
    public void Heal(int healAmount)
    {
        if (healAmount > 0)
        {
            health = health + healAmount < maxHealth ? health + healAmount : maxHealth;
        }
        else
        {
            Debug.LogError("Heal cannot be negative. Use TakeDamage instead.");
        }
    }

    public void ResetHealth()
    {
        health = maxHealth;
    }

}
