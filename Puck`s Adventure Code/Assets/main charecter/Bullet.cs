using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float Speed = 20f;

    public int damage = 35;

    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * Speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        DefaultEnemy enemy = hitInfo.GetComponent<DefaultEnemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);

        BossHealth boss = hitInfo.GetComponent<BossHealth>();
        if(boss != null)
        {
            boss.TakeDmage(damage);
        }

    }

}
