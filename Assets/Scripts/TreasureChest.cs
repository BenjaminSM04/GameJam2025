using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TreasureChest : Interactable

{
    public Item contents;
    public bool isOpen;
    public Inventory playerInventory;
    public SignalSender raiseItem;
    public GameObject dialogBox;
    public Text dialogText;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetButtonDown("interact") && PlayerinRange)
        {
            if (!isOpen)
            {
                Openchest();
            }
            else
            {
                ChestAlreadyOpen();
            }
        }
       }
    public virtual void Openchest()
    {
        // Dialog window on
        dialogBox.SetActive(true);
        // dialog text = contains text
        dialogText.text = contents.itemDescription;
        // add contents to the inventory
        playerInventory.AddItem(contents);
        playerInventory.currentItem = contents;
        // Raise the signal to the player to animate correctly
        raiseItem.Raise();
        // raise the context clue so it turns off
        isOpen = true;
        contextOff.Raise();
        anim.SetBool("opened", true);
        // set the chest to opened
 
        
    }
    public void ChestAlreadyOpen()
    {


            dialogBox.SetActive(false);
            //playerInventory.currentItem = null;
            raiseItem.Raise();

        
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger && !isOpen)
        {
            contextOn.Raise();
            PlayerinRange = true;

        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger &&!isOpen)
        {
            contextOff.Raise();
            PlayerinRange = false;

        }
    }
}


