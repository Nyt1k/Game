
using UnityEngine;
using UnityEngine.UI;



public class LoreDialoge : MonoBehaviour
{
    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    public bool PlayerInRange;



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && PlayerInRange)
        {
            if(dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
            }else
            {
                dialogBox.SetActive(true);
                dialogText.text = dialog;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag ==  "Player")
        {
            PlayerInRange = true;
        }

        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {        
            PlayerInRange = false;
            dialogBox.SetActive(false);
        }
    }
}
