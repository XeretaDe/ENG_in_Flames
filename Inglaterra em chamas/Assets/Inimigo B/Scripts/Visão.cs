using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visão : MonoBehaviour
{
    GameObject mage;                      // referencia ao mage
    MageATK mageATK;
    bool PraDireita = true;

    GameObject FogoMage;
    FogoDmg FogoDmg;

    GameObject Spawn;
    // Start is called before the first frame update
    void Start()
    {
        FogoMage = GameObject.Find("FogoMage");
        FogoDmg = GetComponent<FogoDmg>();
        Spawn = GameObject.FindGameObjectWithTag("Spawner"); // Define Spawner
        mage = GameObject.FindGameObjectWithTag("Mage"); // define Mage
        mageATK = mage.GetComponent<MageATK>(); // define MageATK como o script a ser chamado
        Timer();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            mageATK.Enxerga = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            mageATK.Enxerga = false;
            Timer();
        }
    }

    void Timer()
    {
        StartCoroutine(Virar());

        IEnumerator Virar()
        {
            yield return new WaitForSeconds(10);
            if (mageATK.Enxerga == false)
            {
                Flip();
            }
        }
    }

    void Flip()
    {
        mage.transform.Rotate(0f, 180f, 0f); // rotaciona em 180 graus o Mage

        /*  Vector3 Escala = mage.transform.localScale;
          Escala.x *= -1;
          mage.transform.localScale = Escala;

         if (PraDireita)
          {
              FogoDmg.speed = 10f;
              PraDireita = false;
          }
          else
          {
              FogoDmg.speed *= -1;
              PraDireita = true;
          }

        if (PraDireita)
          {
              Quaternion Escala2 = Spawn.transform.localRotation;
              Escala2.y -= 200;
              PraDireita = false;
              Escala2 = Spawn.transform.localRotation;
          }
          else
          {
              if (PraDireita == false)
              {
                  Quaternion Escala2 = Spawn.transform.localRotation;
                  Escala2.y += 200;
                  PraDireita = true;
                  Escala2 = Spawn.transform.localRotation;
              }

          } */

    }


}
