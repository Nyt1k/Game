using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartScript : MonoBehaviour
{
    int MaxHealth = 1;
    int currentHealth;

    
    void Start()
    {
        currentHealth = MaxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Hurt();
        }
    }

    public void Hurt()
    {
        Destroy(gameObject);
    }
}
