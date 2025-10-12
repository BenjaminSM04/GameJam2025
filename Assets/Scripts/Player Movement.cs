using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public enum PlayerState
{
    walk,
    attack,
    interact,
    stagger,
    idle
}

public class NewBehaviourScript : MonoBehaviour
{
    public PlayerState currentState;
    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;
    public Floatvalue currentHealth;
    public SignalSender playerHealthSignal;
    public VectorValue startingPosition;
    public Inventory playerInventory;
    public SpriteRenderer receivedItemSprite;
    public BoolSword bo;
    public Boolean Sword;

    // Start is called before the first frame update
    void Start()
    {
        currentState= PlayerState.walk;
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        animator.SetFloat("MoveX", 0);
        animator.SetFloat("MoveY", -1);
        transform.position = startingPosition.initialValue;
    }

    // Update is called once per frame
    void Update()
    {
        Sword = bo.Swordobteind;
        if (currentState == PlayerState.interact) {
            return;
        }

        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("attack") && currentState != PlayerState.attack && currentState != PlayerState.stagger && Sword!=false)
        {
            StartCoroutine(AttackCo());
        }
        else if (currentState == PlayerState.walk || currentState == PlayerState.idle)
            {
                UpdateAnimationAndMove();
            } 
            

    }
    private IEnumerator AttackCo()
    {
        animator.SetBool("Attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("Attacking", false);
        yield return new WaitForSeconds(.3f);
        if(currentState != PlayerState.interact) {
            currentState = PlayerState.walk;
        }
       
    }
    public void RaiseItem()
    {
        if (playerInventory.currentItem!=null) {
        

            if(currentState != PlayerState.interact) 
            {
            
            animator.SetBool("receive item", true);
            currentState = PlayerState.interact;
            receivedItemSprite.sprite = playerInventory.currentItem.itemSprite;
        }
  
            else
            {
            animator.SetBool("receive item", false);
                currentState = PlayerState.idle;
            receivedItemSprite.sprite = null;
           playerInventory.currentItem = null;
            }
        }
    }

    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("MoveX", change.x);
            animator.SetFloat("MoveY", change.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }
    void MoveCharacter()
    {
        change.Normalize();
        myRigidbody.MovePosition(
            transform.position + change * speed * Time.deltaTime
            );
    }
    public void Knock(float KnockTime, float damage)
    {
       
        currentHealth.RuntimeValue -= damage;
        playerHealthSignal.Raise();
        if (currentHealth.RuntimeValue > 0)
        {

            StartCoroutine(KnockCo(KnockTime));
        }else
        {
            SceneManager.LoadScene("Gameover");
        }
    }
    private IEnumerator KnockCo( float knocktime)
    {
        if (myRigidbody != null)
        {
            yield return new WaitForSeconds(knocktime);
            myRigidbody.velocity = Vector2.zero;
            currentState = PlayerState.idle;
            myRigidbody.velocity-= Vector2.zero;    
        }
    }

}

