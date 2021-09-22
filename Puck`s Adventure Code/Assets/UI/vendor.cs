using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vendor : MonoBehaviour
{
    MoneyCount scriptM;


    public GameObject vendorUI;

    public bool PlayerInRange;

    public int cost;

    public GameObject objectToCreate;
    public Transform posToCreate;

    void Start()
    {
        scriptM = GameObject.FindGameObjectWithTag("GameController").GetComponent<MoneyCount>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {  
            PlayerInRange = true;
            vendorUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {   
            PlayerInRange = false;
            vendorUI.SetActive(false);
        }
    }



    public void BuyItems()
    {
        if(MoneyCount.gold >= cost)
        {
            MoneyCount.gold -=cost;
            
            Instantiate(objectToCreate, posToCreate.position, posToCreate.rotation); 
        }
    }
}
