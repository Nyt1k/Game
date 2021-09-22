using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DefaultEnemy : MonoBehaviour
{
    public LayerMask enemyMask;
    public float speed = 20;

    public GameObject deathEffect;

    public int MaxHealth = 100;
    public int currentHealth;

    Rigidbody2D myBody;
    Transform myTrans;
    float myWidth;
    float myHeight;

    void Start()
    {
        currentHealth = MaxHealth;
        myTrans = this.transform;
        myBody = this.GetComponent< Rigidbody2D>();
        SpriteRenderer mySprite = this.GetComponent<SpriteRenderer>();
        myWidth = mySprite.bounds.extents.x;
        myHeight = mySprite.bounds.extents.y;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            TakeDamage(100);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            DeathEffect(); 
            this.gameObject.SetActive(false);
        }
    }

    private void DeathEffect()
    {
        if(deathEffect != null)
        {
            GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1f);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 lineCastPos = myTrans.position.ToVector2() - myTrans.right.ToVector2() * myWidth + Vector2.up * myHeight;
        Debug.DrawLine(lineCastPos, lineCastPos + Vector2.down);
        bool isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.down, enemyMask);
        Debug.DrawLine(lineCastPos, lineCastPos - myTrans.right.ToVector2() * .05f);
        bool isBlocked = Physics2D.Linecast(lineCastPos, lineCastPos - myTrans.right.ToVector2() * .05f, enemyMask);


        if (!isGrounded || isBlocked)
        {   
            Vector3 currentRotetion = myTrans.eulerAngles;   
            currentRotetion.y += 180;
            myTrans.eulerAngles = currentRotetion;
        }


        Vector2 myVel = myBody.velocity;
        myVel.x = myTrans.right.x * -speed;
        myBody.velocity = myVel;
    }


    public void Hurt()
    {
        Destroy(this.gameObject);
    }
}
