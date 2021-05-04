using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cub_HP : MonoBehaviour
{
    public int Max_Health = 4;
    public int currentHealth;
    void Start()
    {
        currentHealth = Max_Health;

    }
    public void TakeDamageAI(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }

        void Die()
        {
            Destroy(this.gameObject);
            Debug.Log("Cub is dead! ");
        }
    }
}
