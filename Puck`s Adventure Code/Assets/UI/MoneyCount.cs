using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyCount : MonoBehaviour
{
    public static int gold= 0;

    GameObject currencyUI;
    

    void Awake()
    {

        currencyUI = GameObject.Find("MoneyCount");
    }

    // Update is called once per frame
    public void Update()
    {
        currencyUI.GetComponent<Text>().text = "MONEY:" + gold.ToString();
        if(gold <0)
        {
            gold = 0;
        }
    }
}
