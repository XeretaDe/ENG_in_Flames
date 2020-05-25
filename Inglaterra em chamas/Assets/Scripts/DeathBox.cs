using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBox : MonoBehaviour
{
    GameObject player;
    Player_HP playerHP;
    int Dano = 100;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); // declara player, como player
        playerHP = player.GetComponent<Player_HP>(); // chama o script de player pra dentro desse script

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject == player)
        {

            playerHP.TomarDano(Dano);

        }
    }
}
