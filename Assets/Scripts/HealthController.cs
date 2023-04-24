using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    float maximumHealth = 100.0F;

    float currentHealth = 0.0F;

    void Start()
    {
        currentHealth = maximumHealth;
    }

    public void TakeDamage(float value)
    {
        currentHealth -= Mathf.Abs(value);
        if (currentHealth < 0.0F)
        {
            if (this.gameObject.CompareTag("Player"))
            {
                this.gameObject.GetComponent<LivesController>().RestarLives();
            }
            else
            {
                Destroy(gameObject);
            }

        }
    }
}
