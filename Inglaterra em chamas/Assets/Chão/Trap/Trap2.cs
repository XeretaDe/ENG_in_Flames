using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap2 : MonoBehaviour
{
    // Liga e Desliga da trap
    public bool TrapOn = false;
    public bool TrapOff = true;
    //Definições
    GameObject player;
    Player_HP playerHealth;
    Animator Anim;
    private int rand;
    private int rand2;

    // Start is called before the first frame update

    void Start()
    {       
        // Chamadas
        Anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player"); // define player como a tag Player
        playerHealth = player.GetComponent<Player_HP>(); // define playerHealth como o script Player HP

    }

    // Update is called once per frame
    void Update()
    {

        if (TrapOn)
        {

             Anim.SetTrigger("Trap"); // Liga trap

        }
    
    }

    //Dar dano no player
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject == player)

        {
            playerHealth.TomarDano(15);

        }
    }
}
