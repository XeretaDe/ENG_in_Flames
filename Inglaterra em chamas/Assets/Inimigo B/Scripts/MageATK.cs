using UnityEngine;
using System.Collections;


public class MageATK : MonoBehaviour
{
    // Visao
    public bool Enxerga = false;

    //Referencias Fogo
    public Transform MagicPoint;
    public float timeBetweenAttacks = 10f;     // Tempo que o inimigo leva entre ataques
    public int attackDamage = 10; // Vida que tira por ataque
    public GameObject Fogo;

    // Referencias gerais
    Animator anim;                              // Chama animator
    GameObject player;                          // referencia ao player
    Player_HP playerHealth;                  // referencia ao script de vida do player
    float timer;                                // tempo pra contar o tempo


    void Awake()
    {
        // Chamando as referencias
        player = GameObject.FindGameObjectWithTag("Player"); // define player como a tag Player
        playerHealth = player.GetComponent<Player_HP>(); // define playerHealth como o script Player HP
        anim = GetComponent<Animator>(); // chama o animator
    }




    void Update()
    {

        // Adiciona o tempo que passou desde que a última vez que essa função foi chamada 
        timer += Time.deltaTime;


        // Se o tempo for maior que o tempo entre os ataques e o player poder ser atacado 
        if (timer >= timeBetweenAttacks && Enxerga) 
        {
            // ataca
            Attack();
        }

        //Visao sendo setada



    }


    void Attack()
    {
        // Reseta o timer
        timer = 0f;
        Instantiate(Fogo, MagicPoint.position, MagicPoint.rotation);

    }

}
