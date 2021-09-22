using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CoinValue : MonoBehaviour
{
    MoneyCount scriptM;
    public int Addamount = 1;

    void Start()
    {
        scriptM = GameObject.FindWithTag("GameController").GetComponent<MoneyCount>();

    }

     void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            MoneyCount.gold += Addamount;
            Destroy(gameObject);
        }
    }
}
