using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public int attackDamage = 5;               // Vida que tira por ataque

    public float speed = 10f; // velocidade
    public Rigidbody2D rb; //referencia ao rigid body

    private bool _followArc;
    private bool _firstFrame;

    private Transform _arrow;

    GameObject player;                          // referencia ao player
    Player_HP playerHealth;                  // referencia ao script de vida do player

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player"); // define player como a tag Player
        playerHealth = player.GetComponent<Player_HP>(); // define playerHealth como o script Player HP

    }

    void Start()
    {
      rb.velocity = transform.right * speed; // velocidade do rb é transformada para direita com X velocidade

     _firstFrame = true;
     _followArc = true;
    }

    private void FixedUpdate()
    {
        if (_followArc && !_firstFrame)
        {
            transform.right = rb.velocity; // this line makes the arrow follow the parabolic arc
        }
        _firstFrame = false;

        if (transform.position.y < -5.25f)
        {
            Destroy(gameObject);
        }

     }

        void Update()
    {
        if (transform.position.y < -5.25f) // se o transform no eixo y for menor que -5.25f 
        {
            Destroy(gameObject); //destroi objeto (fora da tela)
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        _followArc = false;
        if (collision.CompareTag("Player")) // se for player
        {
           playerHealth.TomarDano(attackDamage); // chama player HP e dá dano
           Destroy(this.gameObject); // Destroi objeto
        }
        
    }
}