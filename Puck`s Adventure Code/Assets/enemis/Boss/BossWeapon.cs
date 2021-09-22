using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{
    public int attackDamage = 20;
    public int inRageattackDamage = 35;

    public Vector3 attackOffSet;
    public float attackRange = 1f;
    public LayerMask attackMask;


    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffSet.x;
        pos += transform.up * attackOffSet.y;


        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if(colInfo != null)
        {
            colInfo.GetComponent<Player>().TakeDamage(attackDamage);
        }
    }


    public void inRageAttack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffSet.x;
        pos += transform.up * attackOffSet.y;


        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (colInfo != null)
        {
            colInfo.GetComponent<Player>().TakeDamage(inRageattackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffSet.x;
        pos += transform.up * attackOffSet.y;

        Gizmos.DrawWireSphere(pos, attackRange);
    }
}
