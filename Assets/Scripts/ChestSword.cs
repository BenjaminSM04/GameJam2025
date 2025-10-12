using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSword : TreasureChest

{
    public BoolSword bo;
    // Start is called before the first frame update
    public override void Openchest()
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
        bo.Swordobteind = true;


    }

}

