using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Mainmenu : MonoBehaviour
{
    public BoolSword bo;
    public Inventory playerInventory;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Newgame()
    {
        bo.Swordobteind = false;
        playerInventory.numberOfKeys = 0;
        SceneManager.LoadScene("Casita");


    }
    public void quit() 
    {
        Application.Quit();
    }
}
