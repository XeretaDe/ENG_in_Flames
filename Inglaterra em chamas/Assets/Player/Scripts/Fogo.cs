using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Fogo : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;
    public CircleCollider2D cc2D;

    AudioSource AudioS;

    public Animator Anim;

    public float ForceHorizontal = 7;
    public float ForceVertical = 5;
    public float TempoMorte = 1;
    GameObject boss;
    BossScript bossScript;
    // Start is called before the first frame update

    void Awake()
    {

        cc2D = GetComponent<CircleCollider2D>();

        speed = 10f;
        AudioS = GetComponent<AudioSource>();

        if (SceneManager.GetSceneByName("Boss").isLoaded)
        {
            boss = GameObject.FindGameObjectWithTag("Boss"); // define player como a tag Player
            bossScript = boss.GetComponent<BossScript>();
        }
        
    }

    void Start()
    {
        Anim = GetComponent<Animator>();
        
    }

    void Update()
    {
        rb.velocity = transform.right * speed;
        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Boss"))
        {
            bossScript.TomarDano(5);
            Anim.SetTrigger("explodiu");
            speed = 0f;
            cc2D.enabled = false;
            AudioS.Play();
            Destruir();
        }
        else
        {
            if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Mage")) // Se refere a Tag dos inimigos dentro da unity
            {
                if (other.gameObject.CompareTag("Enemy"))
                {
                    other.gameObject.GetComponent<Enemy>().enabled = false; // chamando o script do inimigo
                    other.gameObject.GetComponent<Animator>().SetTrigger("Morte");
                }

                else
                {
                    other.gameObject.GetComponentInChildren<MageMov>().enabled = false;
                    other.gameObject.GetComponent<Animator>().SetTrigger("Morte");


                }

                BoxCollider2D[] Colliders = other.gameObject.GetComponents<BoxCollider2D>(); // Chamando todos componentes do box collider do inimigo

            foreach (BoxCollider2D Colisor in Colliders) // para cada "colisor" dentro dos colliders (chamados acima)
            {
                Colisor.enabled = false; // desative-os
            }

            Destroy(other.gameObject, TempoMorte);
                Anim.SetTrigger("explodiu");
                speed = 0f;
                cc2D.enabled = false;
                AudioS.Play();
                Destruir();




            }
            else
            {
                Anim.SetTrigger("explodiu");
                AudioS.Play();
                cc2D.enabled = false;
                speed = 0f;
                Destruir();
            }
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
