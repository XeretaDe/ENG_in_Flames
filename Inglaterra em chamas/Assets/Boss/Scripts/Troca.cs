using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troca : StateMachineBehaviour
{
    //Randomizers
    private int rand;
    private int rand2;
    private int rand3;
    private int rand4;
    private int rand5;

    //Timer
    public float timer;
    public float minTime;
    public float MaxTime;

    // Objetos
    GameObject ArrowSpawner;
    GameObject Boss;
    GameObject Trap;
    GameObject Trap3;

    // Scripts
    ArrowSpawn SpawnFlecha;
    BossScript BossStage;
    Trap2 TrapScript;
    Trap3 TrapScript2;


    // Void Start
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Chamando definições
        Trap = GameObject.FindGameObjectWithTag("Trap");
        TrapScript = Trap.GetComponent<Trap2>();

        Trap3 = GameObject.FindGameObjectWithTag("Trap2");  
        TrapScript2 = Trap3.GetComponent<Trap3>();

        ArrowSpawner = GameObject.FindGameObjectWithTag("ArrowSpawner");
        SpawnFlecha = ArrowSpawner.GetComponent<ArrowSpawn>();

        Boss = GameObject.FindGameObjectWithTag("Boss");
        BossStage = Boss.GetComponent<BossScript>();

        timer = Random.Range(minTime, MaxTime);   
        
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        // Pega o estado "Quebrou" do BossScript
        if (BossStage.Quebrou)
        {
            animator.SetBool("PodeAtacar", true); // Define que o Boss pode atacar
        }

        if (timer <= 0 && animator.GetBool("PodeAtacar") == true) // Se o tempo for menor que zero e pode atacar
        {
            rand = Random.Range(0, 4); // randomiza entre 0 e 3


            // ATAQUE BASTAO
            if (rand == 0) // se for zero
            {
                BossStage.AtkAudio();
                animator.SetTrigger("Atacou"); //ataque corpo a corpo
                animator.SetBool("PodeAtacar", false); // N pode atacar
                BossStage.TimerATK(); // Chama BossScript e ativar o timer para pode atacar dnv
                



            }

            // DEFESA
            if (rand == 1) // se o numero for 1
            {
                if (BossStage.SetFase == 2 && animator.GetBool("PodeDefender") == true) // e a fase for 2
                {
                    BossStage.DefAudio();   
                    animator.SetTrigger("Defendeu"); // Seta animação de defesa
                    animator.SetBool("PodeDefender", false); // Diz que não pode + defender
                    animator.SetBool("Defende", true); // Mostra que está defendendo
                    animator.SetBool("PodeAtacar", false); // Não pode atacar



                }
                else
                {
                    if (BossStage.SetFase == 3 && animator.GetBool("PodeDefender") == true)
                    {
                        BossStage.DefAudio();              
                        animator.SetTrigger("Defendeu"); // Seta animação de defesa
                        animator.SetBool("PodeDefender", false); // define que o player n pode defender +
                        animator.SetBool("Defende", true); // Mostra que está defendendo
                        animator.SetBool("PodeAtacar", false); // Nao pode atacar

                        animator.SetBool("PodeSpawnar", true); // Pode Spawnar o Mage


                    }
                    else
                    {
                        animator.SetTrigger("Parou"); // Se n tiver na fase certa para
                        animator.SetBool("PodeAtacar", true); // e pode atacar
                    }
                }

            }

            // CALL
            if (rand == 2) // se for 2
            {
                animator.SetBool("PodeAtacar", false); // N pode atacar
                SpawnFlecha.Flecha(); // spawna a flecha


            }
            if (rand == 3) // se for 3
            {
                animator.SetTrigger("Parou"); // vai pra idle
                animator.SetBool("PodeAtacar", true); // Pode atacar

            }
        }
        else
        {
            timer -= Time.deltaTime; // se o timer n for <= 0 diminui a diferenca do tempo 
        }


        if (animator.GetBool("Defende") == true) // Se o Boss esta defendendo
        {
            if (BossStage.SetFase == 2) // Se a fase do boss for 2
            {
                TrapScript.TrapOn = true; // A trap da esquerda liga
                TrapScript2.TrapOn = true; // A trap da direita liga  
            }
            else // se a fase for 3
            {
                if (animator.GetBool("PodeSpawnar") == true)  // E pode spawnar
                {
                    BossStage.Spawna(); // Chama o spawn do Boss
                }
            }
        }


    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }



        /*            do // Atue em
                {
                    rand2 = Random.Range(0, 10); // randomizar entre 0 e 10
                } while (rand2 != 3); // ate que o numero seja igual a 3


                if (rand2 == 3) // se o numero for 3
                {
                    PodeAtacar = true; // pode atacar

                }

    */
}
