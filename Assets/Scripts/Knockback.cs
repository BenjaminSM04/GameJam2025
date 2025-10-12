using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float thrust;
    public float Knocktime;
    public float damage;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("breakable")&& this.gameObject.CompareTag("Player"))
        {
            other.GetComponent<Pot>().Smash();
        }
        if (other.gameObject.CompareTag("enemy") || other.gameObject.CompareTag("Player"))
        {
            Rigidbody2D hit = other.GetComponent<Rigidbody2D>();
            if (hit != null)
            {
                Vector2 difference = hit.transform.position - transform.position;
                difference = difference.normalized * thrust;
                hit.AddForce(difference, ForceMode2D.Impulse);
                if (other.gameObject.CompareTag("enemy"))
                {
                    hit.GetComponent<Enemy>().currentState = EnemyState.stragger;
                    other.GetComponent<Enemy>().Knock(hit, Knocktime,damage);
                }
                if(other.gameObject.CompareTag("Player"))
                {
                    if(other.GetComponent<NewBehaviourScript>().currentState != PlayerState.stagger) { 
                   
                    hit.GetComponent<NewBehaviourScript>().currentState = PlayerState.stagger;
                    other.GetComponent<NewBehaviourScript>().Knock(Knocktime, damage);
                    }
                }                
            }
        }
    }

        


}
