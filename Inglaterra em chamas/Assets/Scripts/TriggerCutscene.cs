using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TriggerCutscene : MonoBehaviour
{
    GameObject Camera;
    GameObject player;
    GameObject Alfred;
    CameraFollow CameraAjuste;
    Alfredo AlfredoBoca;
    PlayerController playerController;
    Player_ATK player_ATK;
    Animator Anim;
    public AudioSource AudioSource;
    public AudioClip SomAlfredo;

    GameObject LevelLoader;
    LevelLoader LVLScript;


    // Start is called before the first frame update
    void Awake()
    {
        // Chamadas do player
        player = GameObject.FindGameObjectWithTag("Player"); // declara player, como player
        playerController = player.GetComponent<PlayerController>(); // chama o script de player pra dentro desse script
        player_ATK = player.GetComponent<Player_ATK>();// chama o script de player pra dentro desse script

        // chamadas da camera
        Camera = GameObject.FindGameObjectWithTag("MainCamera"); // declara camera como camera
        CameraAjuste = Camera.GetComponent<CameraFollow>(); // chama o script de camera para dentro desse script
        
        // Chamadas do boss
        Alfred = GameObject.FindGameObjectWithTag("Alfredo"); // declara alfredo como alfred
        AlfredoBoca = Alfred.GetComponent<Alfredo>(); // chama o script de alfredo para dentro desse script

        // chamadas de Animator
        Anim = GetComponent<Animator>(); 
         
        // chamadas de audio
        AudioSource.clip = SomAlfredo;

        // chamadas de cena

        LevelLoader = GameObject.Find("LevelLoader");
        LVLScript = LevelLoader.GetComponent<LevelLoader>();
        
        
    }


    // Update is called once per frame
    void Update()
    {


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
        CameraAjuste.OndeSeta = "Alfredo"; // caso entre no void trigger, o OndeSeta será a Tag Alfredo
        playerController.Velocidade = 0f;
        if(playerController.Velocidade == 0f)
            {
                playerController.Anim.SetTrigger("Parou");
                playerController.enabled = false; // Desativa movimento do player

            }
        player_ATK.enabled = false; // Desativa ataque do player
        AlfredoBoca.Anim.SetTrigger("Falando");// Seta trigger no alfredo, fazendo falar
            StartCoroutine(CenaMuda());
            AudioSource.Play(); // faz o audio dele falando dar play
            IEnumerator CenaMuda()
            {
                yield return new WaitForSeconds(21);
                LVLScript.LoadNextLevel();
            }



         




        }
    }



}
