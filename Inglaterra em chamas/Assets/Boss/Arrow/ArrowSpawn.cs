using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawn : MonoBehaviour
{
    // Timer
    public float timeBetweenAttacks = 0.5f;     
    float timer;

    // Animator
    Animator animator;

    // Instantiate
    public Transform ArrowPoint;
    public GameObject ArrowPrefab;

    // Referencias ao boss
    BossScript BossStage;
    GameObject Boss;


    // Start is called before the first frame update
    void Start()
    {
        Boss = GameObject.FindGameObjectWithTag("Boss");
        BossStage = Boss.GetComponent<BossScript>();
    }

    // Update is called once per frame
    void Update()
    {
        // timer += time. To - Ta (Tempo inicial - Tempo Atual)
        timer += Time.deltaTime;


    }

    public void Flecha()
    {   // Timer >= Tempo dos ataques

        if (timer >= timeBetweenAttacks)
        {
            BossStage.GetComponent<Animator>().SetTrigger("Chamou"); // Trigger de chamou   
            BossStage.CallAudio();

            StartCoroutine(Espere2());
                IEnumerator Espere2()
                {
                yield return new WaitForSeconds(1);
                Instantiate(ArrowPrefab, ArrowPoint.position, ArrowPoint.rotation); // Cria um -> prefab de arrow, na posicao do Ponto, e na rotacao do ponto
                }

            StartCoroutine(Espere());
            IEnumerator Espere()
            {
                yield return new WaitForSeconds(BossStage.GetComponent<AudioSource>().clip.length);
                BossStage.GetComponent<Animator>().SetBool("PodeAtacar", true);
            }
        }
    }
    
}
