using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{


    GameObject player;
    Player_HP playerHealth;
    Animator Anim;
    // Start is called before the first frame update

    void Start()
    {
        Anim = GetComponent<Animator>();
    player = GameObject.FindGameObjectWithTag("Player"); // define player como a tag Player
    playerHealth = player.GetComponent<Player_HP>(); // define playerHealth como o script Player HP

    }

    // Update is called once per frame
    void Update()
    {
        
        


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Anim.SetTrigger("Trap");
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Anim.SetTrigger("TrapOff");
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject == player)

        {
            playerHealth.TomarDano(15);

        }
    }
}
