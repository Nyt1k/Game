using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public int health = 100;

    public GameObject deathEffect;

    public HealthBar healthBar;
    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;

    void Start()
    {
        healthBar.SetMaxHealth(health);
    }
    // анімація багнута 
    // public bool isInvulnerable = false;

    public void TakeDmage(int damage)
    {
        //if (isInvulnerable)
        //    return;

        health -= damage;
        healthBar.SetHealth(health);

        if (health <= 1300)
        {
            GetComponent<Animator>().SetBool("InRage", true);
        }

        if(health <= 0)
        {
            Die();
            dialogBox.SetActive(true);
            dialogText.text = dialog;
        }
    }

    void Die()
    {


        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
