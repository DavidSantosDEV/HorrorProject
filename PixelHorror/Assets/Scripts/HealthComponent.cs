using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HealthComponent : MonoBehaviour
{
    [SerializeField][Range(1,300)]
    private int maxHealth=100;

    protected int currentHealth;
    protected bool isDead=false;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (isDead==false)
        {
            currentHealth = Mathf.Clamp(currentHealth - damage, 0, maxHealth);
            TookDamage();
            if (currentHealth == 0)
            {
                Die();
            }
        }
    }

    protected abstract void TookDamage();

    protected virtual void Die()
    {
        isDead = true;
    }
}
