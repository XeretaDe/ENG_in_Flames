using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float KnockBack = 700;
    public float velocidadeInimigo;

    GameObject enemy;
    EnemyATK SpeedDir;
    

    bool PraDireita = false;
    bool NoChao = false;

    Transform CheckDeChao;

    Rigidbody2D rb2d;
    Animator Anim;



    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        SpeedDir = enemy.GetComponent<EnemyATK>();

        rb2d = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        CheckDeChao = transform.Find("CheckDeChao");
    }

    // Update is called once per frame
    void Update()
    {

        NoChao = Physics2D.Linecast(transform.position, CheckDeChao.position, 1 << LayerMask.NameToLayer("Chão"));

        if (!NoChao)
        {
            velocidadeInimigo *= -1;
            SpeedDir.xSpeed = velocidadeInimigo;
        }

    }

    void FixedUpdate()
    {
        rb2d.velocity = new Vector2(velocidadeInimigo, rb2d.velocity.y);

        if(velocidadeInimigo > 0 && !PraDireita)

        {
            Flip();
        }

        if(velocidadeInimigo < 0 && PraDireita)
        {
            Flip();
        }

    }

    void Flip()
    {
        PraDireita = !PraDireita;

        Vector3 Escala = transform.localScale;
        Escala.x *= -1;
        transform.localScale = Escala;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            BoxCollider2D[] boxes = gameObject.GetComponents<BoxCollider2D>();
            foreach(BoxCollider2D box in boxes)
            {
                box.enabled = false;
            }

            other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, KnockBack)); // Quando o player entra no Trigger acima da cabeca leva uma forca para cima

            velocidadeInimigo = 0;
            Anim.SetTrigger("Morte");
            Destroy(gameObject, 1);
        }
    }



}
