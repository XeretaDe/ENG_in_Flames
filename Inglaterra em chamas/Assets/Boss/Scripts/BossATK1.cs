using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossATK1 : MonoBehaviour
{

    public int attackDamage = 5;               // Vida que tira por ataque

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

    void OnTriggerEnter2D(Collider2D other) // Caso algum objeto entre na zona do collider
    {
        if (other.gameObject == player) //  se o objeto tiver a tag de player
        {

            playerHealth.TomarDano(attackDamage);

        }
    }
}
