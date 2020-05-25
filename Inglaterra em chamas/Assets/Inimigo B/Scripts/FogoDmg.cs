using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogoDmg : MonoBehaviour
{
    public float speed = 15f;
    int FireDMG = 5;

    Rigidbody2D rb;

    GameObject player;
    Player_HP playerHealth;

    CircleCollider2D cc2D;

    Vector2 Direction;

    Animator anim;

    AudioSource audioS;

    // Start is called before the first frame update
    void Start()
    {
        cc2D= GetComponent<CircleCollider2D>();
        audioS = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();

        player = GameObject.FindGameObjectWithTag("Player"); // define player como a tag Player
        playerHealth = player.GetComponent<Player_HP>(); // define playerHealth como o script Player HP

        rb = GetComponent<Rigidbody2D>();
    }

   void Update()
    {
        rb.velocity = transform.right * speed;


    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerHealth.TomarDano(FireDMG);
            anim.SetTrigger("explodiu");
            audioS.Play();
            cc2D.enabled = false;
            speed = 0f;
            Destruir();
        }

    }

    void Destruir()
    {
        StartCoroutine(Esperar());
        IEnumerator Esperar()
        {
            yield return new WaitForSeconds(1);
            Destroy(gameObject);
        }
    }

}
