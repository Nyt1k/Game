using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    Animator animator;

    private Rigidbody2D m_Rigidbody2D;

    [HideInInspector]
    public Collider2D[] myColls;


    public  int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;
    public UpgradeMenu upgradeMenu;

    

    public  float invincbleTimeAfterHurt = 2;
    public   float healthRegenRate = 1f;
    public float ExtraDamage;

    void Start()
    {
        myColls = this.GetComponents<Collider2D>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        InvokeRepeating("RegenHealth", healthRegenRate, healthRegenRate);

    }

    void RegenHealth()
    {
        currentHealth += 1;
        healthBar.SetHealth(currentHealth);
    }

    [System.Obsolete]
    void Update()
    {


        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        if (currentHealth <= 0)
        {
            Death();
        }


    }



    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "spike")
        {
            TakeDamage(20);
        }

        if(collision.tag == "Bat")
        {
            TakeDamage(25);
        }

        if(collision.tag == "enemys")
        {
            TakeDamage(20);
        }

        
        if(collision.tag == "Heart")
        {
            Healing(30);
        }
    }

    public void TakeDamageTrigger(float hurtTime)
    {
        StartCoroutine(HurtBlinker(hurtTime));
    }

    void Healing(int heal)
    {
        currentHealth += heal;

        healthBar.SetHealth(currentHealth);
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        TakeDamageTrigger(invincbleTimeAfterHurt);

        healthBar.SetHealth(currentHealth);
    }

    IEnumerator HurtBlinker(float hurtTime)
    {
        int enemyLayer = LayerMask.NameToLayer("Enemis");
        int PlayerLayer = LayerMask.NameToLayer("Player");
        Physics2D.IgnoreLayerCollision(enemyLayer, PlayerLayer);
        foreach (Collider2D collider in myColls)
        {
            collider.enabled = false;
            collider.enabled = true;
        }
        
        yield return new WaitForSeconds(hurtTime);


        Physics2D.IgnoreLayerCollision(enemyLayer, PlayerLayer, false);
        

    }



    [System.Obsolete]
    void Death()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
