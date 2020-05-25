using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TriggerCutscene2 : MonoBehaviour
{
    //Alteraçoes camera
    CameraFollow CameraAjuste;
    //Player
    GameObject Camera;
    GameObject player;
    PlayerController playerController;
    Player_ATK player_ATK;
    Player_Magic player_Magic;
    //Boss Scripts
    GameObject Rollo;
    BossScript RolloScript;
    Animator BossAnim;
    //Animator
    Animator Anim;
    // Som
    public AudioSource AudioSource;
    public AudioClip BossVoice;


    // Start is called before the first frame update
    void Awake()
    {
        // Chamadas do player
        player = GameObject.FindGameObjectWithTag("Player"); // declara player, como player
        playerController = player.GetComponent<PlayerController>(); // chama o script de playerController pra dentro desse script
        player_ATK = player.GetComponent<Player_ATK>();// chama o script de player pra dentro desse script
        player_Magic = player.GetComponent<Player_Magic>(); // chama o script de player pra dentro desse script


        // chamadas da camera
        Camera = GameObject.FindGameObjectWithTag("MainCamera"); // declara camera como camera
        CameraAjuste = Camera.GetComponent<CameraFollow>(); // chama o script de camera para dentro desse script

        // Chamadas do boss
        Rollo = GameObject.FindGameObjectWithTag("Boss");
        RolloScript = Rollo.GetComponent<BossScript>();
        BossAnim = RolloScript.GetComponent<Animator>();


        // chamadas de Animator
        Anim = GetComponent<Animator>();

        // chamadas de audio
        AudioSource.clip = BossVoice;



    }


    // Update is called once per frame
    void Update()
    {


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CameraAjuste.OndeSeta = "Boss"; // caso entre no void trigger, o OndeSeta será a Tag Alfredo
            playerController.Velocidade = 0f;
            if (playerController.Velocidade == 0f)
            {
                // Desativa Player
                playerController.Anim.SetTrigger("Parou");
                playerController.enabled = false;

                // Desativa ataques Boss
                BossAnim.SetBool("PodeAtacar", false);

            }
            player_ATK.enabled = false; // Desativa ataque do player
            player_Magic.enabled = false;

            StartCoroutine(Cutscene());
            IEnumerator Cutscene()
            {
                AudioSource.Play(); // faz o audio dele falando dar play
                yield return new WaitForSeconds(12);

                CameraAjuste.OndeSeta = "Player";

                // Ativa player
                playerController.Anim.SetTrigger("PodeAndar");
                playerController.enabled = true;
                player_Magic.enabled = true;
                player_ATK.enabled = true;
                playerController.Velocidade = 15f;

                // Ativa Boss
                BossAnim.SetTrigger("FimVoz");
                BossAnim.SetBool("PodeAtacar", true);

                Destroy(gameObject);



            }





        }
    }



}