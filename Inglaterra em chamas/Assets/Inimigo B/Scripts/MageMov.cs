using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageMov : MonoBehaviour
{
    public float KnockBack = 700;

    // GameObject player;                       -> RETIRADO POIS BOOL NECESSÁRIA TORNOU-SE STATIC
    // Player_Magic P_Magic;                  -> RETIRADO POIS BOOL NECESSÁRIA TORNOU-SE STATIC

    public Transform MagicSpawn;
    public GameObject MagicPrefab;

    Rigidbody2D rb2d;
    Animator Anim;
    GameObject Mage;


    // Start is called before the first frame update
    void Start()
    {

      /*  player = GameObject.FindGameObjectWithTag("Player"); // define player como a tag Player
        P_Magic = player.GetComponent<Player_Magic>(); // define playerHealth como o script Magia  */ 

        Mage = GameObject.FindGameObjectWithTag("Mage");
        rb2d = GetComponent<Rigidbody2D>();
        
        Anim = Mage.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    void FixedUpdate()
    {


    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            /*P_Magic.TemMagia == false -> ANTES DA ALTERAÇÃO */
            if ( Player_Magic.TemMagia == false)
            {
                Spawn();
            }

            BoxCollider2D[] boxes = gameObject.GetComponents<BoxCollider2D>();
            foreach (BoxCollider2D box in boxes)
            {
                box.enabled = false;
            }

            other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, KnockBack)); // Quando o player entra no Trigger acima da cabeca leva uma forca para cima

            Anim.SetTrigger("Morte");
            Destroy(Mage, 1);



        }
    }


    public void Spawn()
    {
        Instantiate(MagicPrefab, MagicSpawn.position, MagicSpawn.rotation);
    }


}
