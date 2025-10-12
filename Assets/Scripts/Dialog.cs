using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : Interactable
{
    
    public GameObject dialogbox;
    public Text dialogText;
    public string dialog;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("interact") && PlayerinRange)
        {
            if (dialogbox.activeInHierarchy)
            {
                dialogbox.SetActive(false);
            }
            else
            {
                dialogbox.SetActive(true);
                dialogText.text = dialog;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            contextOff.Raise();
            PlayerinRange = false;
            dialogbox.SetActive(false);
        }
    }
}
