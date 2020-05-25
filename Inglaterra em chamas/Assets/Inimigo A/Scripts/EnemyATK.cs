using UnityEngine;
using System.Collections;


public class EnemyATK : MonoBehaviour
{
    public float xSpeed;
    public float timeBetweenAttacks = 0.5f;     // Tempo que o inimigo leva entre ataques
    public int attackDamage = 10;               // Vida que tira por ataque

    GameObject enemy;
    Enemy Speed;

    Animator anim;                              // Chama animator
    GameObject player;                          // referencia ao player
    Player_HP playerHealth;                  // referencia ao script de vida do player
    bool playerInRange;                         // Player está dentro do trigger ou não
    float timer;                                // tempo pra contar o tempo


    void Awake()
    {
        // Chamando as referencias
        player = GameObject.FindGameObjectWithTag("Player"); // define player como a tag Player
        playerHealth = player.GetComponent<Player_HP>(); // define playerHealth como o script Player HP

        enemy = GameObject.FindGameObjectWithTag("Enemy");
        Speed = enemy.GetComponent<Enemy>();

        anim = GetComponent<Animator>(); // chama o animator


    }





    void OnCollisionEnter2D(Collision2D other) // Caso algum objeto entre na zona do collider
    {
        if (other.gameObject == player) //  se o objeto tiver a tag de player
        {
            playerInRange = true; // o player esta em range e pode ser atacado
            Speed.velocidadeInimigo = 0;

        }
    }

    void OnCollisionExit2D(Collision2D other) // se algo sai do collider
    {
        if (other.gameObject == player) // e for o player
        {
            playerInRange = false; // o player n esta em range e nao pode ser atacado.
            Speed.velocidadeInimigo = xSpeed;
        }

    }


    void Update()
    {
        // Adiciona o tempo que passou desde que a última vez que essa função foi chamada 
        timer += Time.deltaTime;

        // Se o tempo for maior que o tempo entre os ataques e o player poder ser atacado 
        if (timer >= timeBetweenAttacks && playerInRange)
        {
            // ataca
            anim.SetTrigger("Ataque");

        }

    }



}
