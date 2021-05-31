using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; // Pega o Sistema de UI da unity
using UnityEngine.SceneManagement; // pega o sistema de cenas da unity
using UnityEngine.Analytics;
using UnityEngine;
using UnityEngine.Advertisements;

public class Player_HP : MonoBehaviour
{


    public static int HPInicial = 100; // Seta HP player
    public static int VidaAtual; // Dira qual a vida atual do player

    public Slider SliderHP; //Chama Slider de Hp criado na UI

    public Image FlashDano; // Chama a imagem q fara a tela ficar vermelha ao tomar dano
    public Color flashCor = new Color(1f, 0f, 0f, 0.1f); // define que a nova cor do flash eh vermelho com 0.1 de alfa

    public float FlashVel = 5f; // Define velocidade do flash

    public static bool isDead = false;
    bool TomouDano;

    protected InterstitialAdsScript interstitialAdsScript;

    Animator Anim; // declara anim
    PlayerController playerController;
    Player_ATK player_ATK;

    void Awake()
    {
        Anim = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
        player_ATK = GetComponent<Player_ATK>();
        VidaAtual = HPInicial;
        TomarDano(0);

    }




    // Start is called before the first frame update
    void Start()
    {

        interstitialAdsScript = FindObjectOfType<InterstitialAdsScript>();


        if (isDead)
        {
            VidaAtual = 100;
            TomarDano(0);
            isDead = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (TomouDano) // Se o player toma dano
        {

            FlashDano.color = flashCor; // A cor da imagem do flash fica igual a cor do flash
        }
        else
        {
            FlashDano.color = Color.Lerp(FlashDano.color, Color.clear, FlashVel * Time.deltaTime); // se não a cor vai clareando conforme o tempo

        }
        TomouDano = false; // Torna tomou dano falso
    }

    public void TomarDano(int Dano) // Informa que Tomar dano é um numero inteiro chamado dano (que pode ser chamado em outro script)
    {
        if(Dano > 0)
        {
            TomouDano = true; //define que tomou dano

        }
        VidaAtual -= Dano; //define que a vida atual é VidaAtual - Dano = VidaAtual
        HPInicial = VidaAtual;
        SliderHP.value = VidaAtual;// define que o slider de vida é igual a vida atual


        if (VidaAtual <= 0 && !isDead && Dano > 0) // se a vida atual for = ou menor que zero e não estiver morto
        {
            Death(); // morreu
        }
    }

    void Death() // morreu
    {

        isDead = true; // está morto é verdade
        Anim.SetTrigger("Morreu"); // seta animação de morte
        SceneManager.LoadScene("GameOver");
        interstitialAdsScript.ShowInterstitialAd();


        AnalyticsResult analyticsResult = Analytics.CustomEvent(
        "Derrota",
         new Dictionary<string, object> {
         {"Level de morte:", SceneManager.GetActiveScene().buildIndex },
         {"Setor onde morreu:", Mathf.RoundToInt(transform.position.x/20f)}
         }

         );
         Debug.Log("Resultado dos analytics" + analyticsResult);

    }




}
