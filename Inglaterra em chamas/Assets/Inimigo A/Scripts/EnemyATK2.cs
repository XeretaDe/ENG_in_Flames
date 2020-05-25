using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyATK2 : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;     // Tempo que o inimigo leva entre ataques
    public int attackDamage = 10;               // Vida que tira por ataque



    GameObject player;                          // referencia ao player
    Player_HP playerHealth;                  // referencia ao script de vida do player




    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); // define player como a tag Player
        playerHealth = player.GetComponent<Player_HP>(); // define playerHealth como o script Player HP


    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
            // ataca
            Attack();

    }


    void Attack()
    {
        // Reseta o timer

        // se o player tem vida para perder
        // playerHealth.VidaAtual > 0 -> ALTERADO POR VIDA ATUAL TORNOU-SE STATIC
        if (Player_HP.VidaAtual > 0)
        {
            // dano no player
            playerHealth.TomarDano(attackDamage);
        }
    }


}

