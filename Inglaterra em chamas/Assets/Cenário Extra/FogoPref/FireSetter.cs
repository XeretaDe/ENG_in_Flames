using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSetter : MonoBehaviour
{

  /* 
   * TUDO TORNA-SE DESNECESSÁRIO POR CONTA DA FALTA NECESSIDADE DE REFERÊNCIAS A VARIAVEL STATIC
   * GameObject player;                          // referencia ao player
    Player_Magic P_Magic;                  // referencia ao script de Magia do player

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); // define player como a tag Player
        P_Magic = player.GetComponent<Player_Magic>(); // define playerHealth como o script Magia
    }

    // Update is called once per frame
    void Update()
    {
        
    } */

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //   P_Magic.TemMagia -> ANTES DA ALTERAÇÃO */
            Player_Magic.TemMagia = true;
            Destroy(gameObject);
        }
    }

}
