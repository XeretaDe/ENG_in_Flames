using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Ataques : MonoBehaviour
{
    public float ForceHorizontal = 7;
    public float ForceVertical = 5;
    public float TempoMorte = 1;
    GameObject boss;

    float PrimeiraForcaHorizontal;
    BossScript bossScript;



    void Awake()
    {

        if (SceneManager.GetSceneByName("Boss").isLoaded)
        {
            boss = GameObject.FindGameObjectWithTag("Boss"); // define player como a tag Player
            bossScript = boss.GetComponent<BossScript>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {


        PrimeiraForcaHorizontal = ForceHorizontal;



    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other) // Em uma colisao de Trigger
    {

        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Mage")) // Se refere a Tag dos inimigos dentro da unity
        {

            if (other.gameObject.CompareTag("Enemy"))
            {
                other.gameObject.GetComponent<Enemy>().enabled = false; // chamando o script do inimigo
                other.gameObject.GetComponent<Animator>().SetTrigger("Morte");
                other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(ForceHorizontal, ForceVertical), ForceMode2D.Impulse);


            }
            else
            { // transform.parent.GetComponentInParent<Player_Magic>().TemMagia== false -> ALTERADO POIS TORNOU-SE STATIC
                if (Player_Magic.TemMagia == false)
                {
                    other.gameObject.GetComponentInChildren<MageMov>().Spawn();
                }


                other.gameObject.GetComponentInChildren<MageMov>().enabled = false;
                other.gameObject.GetComponent<Animator>().SetTrigger("Morte");

            }
            BoxCollider2D[] Colliders = other.gameObject.GetComponents<BoxCollider2D>(); // Chamando todos componentes do box collider do inimigo

            foreach (BoxCollider2D Colisor in Colliders) // para cada "colisor" dentro dos colliders (chamados acima)
            {
                Colisor.enabled = false; // desative-os
            }

            if(other.transform.position.x < transform.position.x) // Se a posicao do Inimigo (other) em X for menor (logo a esquerda) do que a do player 
            {
                ForceHorizontal *= -1;  // define que a forca a ser feita deve ser para a esquerda
            }


            Destroy(other.gameObject, TempoMorte);
            ForceHorizontal = PrimeiraForcaHorizontal;

        }
        else
        {
            if (other.gameObject.CompareTag("Boss"))
            {
                bossScript.TomarDano(10);
            }
        }


    }
}
