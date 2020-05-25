using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossScript : MonoBehaviour
{
    // Start is called before the first frame update

    // Som
    public AudioClip SomBastão;
    public AudioClip SomCall;
    public AudioClip SomDefesa;
    private AudioSource audioS;

    // Cor do boss
    SpriteRenderer SprRen;
    Color32 RedFase2;
    Color32 RedFase3;

    //Instantiate
    public Transform MageSpawn;
    public GameObject MagePrefab;

    //Ints de Vida
    public int VidaInicial;
    public int VidaAtual;
    //Bool de vida
    bool isDead = false;

    //Timer
    public float minTime = 1f;
    public float MaxTime = 3f;
    float timer;                                // tempo pra contar o tempo

    //Refs do Player
    GameObject player;                          // referencia ao player
    Player_HP playerHealth;                  // referencia ao script de vida do player

    // Ataques
    public float timeBetweenAttacks = 0.35f;     // Tempo que o inimigo leva entre ataques
    public int attackDamage = 10;               // Vida que tira por ataque
    public float tempoATK; // Tempo de ataques do Bastao

    // Defesas
    public int SetFase = 1;  // Fase inicial do Boss eh 1
    public int VidaEscudo = 3; // Vida do escudo eh 3
    public bool Quebrou = false;

    //Fases
    public bool ChamouFase2 = false;
    public bool ChamouFase3 = false;

    //Refs de objetos do boss
    GameObject ArrowSpawner; 
    GameObject Trap;
    Trap2 TrapScript;
    GameObject Trap3;
    Trap3 TrapScript2;
    ArrowSpawn VelocidadeATK;
    Animator Anim; // declara anim

    // Refs do level loader
    GameObject LevelLoader;
    LevelLoader LVLScript;


    public Slider BossSlider;

    void Start()
    {
        //Chamar referencias
        Trap = GameObject.FindGameObjectWithTag("Trap");
        TrapScript = Trap.GetComponent<Trap2>();

        Trap3 = GameObject.FindGameObjectWithTag("Trap2");
        TrapScript2 = Trap3.GetComponent<Trap3>();

        ArrowSpawner = GameObject.FindGameObjectWithTag("ArrowSpawner"); // Define ArrowSpawner como o objeto
        VelocidadeATK = ArrowSpawner.GetComponent<ArrowSpawn>();

        player = GameObject.FindGameObjectWithTag("Player"); // define player como a tag Player
        playerHealth = player.GetComponent<Player_HP>(); // define playerHealth como o script Player HP
        Anim = GetComponent<Animator>();

        LevelLoader = GameObject.Find("LevelLoader");
        LVLScript = LevelLoader.GetComponent<LevelLoader>();

        audioS = gameObject.GetComponent<AudioSource>();

        // cor do boss
        SprRen = GetComponent<SpriteRenderer>();

        // Define vida
        VidaInicial = 230;
        VidaAtual = VidaInicial;
        BossSlider.value = VidaInicial;

        // Tempo dos ataques
        tempoATK = Random.Range(minTime, MaxTime); // define que o tempo sera um random entre o minimo e max

    }

    // Update is called once per frame
    void Update()
    {
        // Atualização da vida c/ Slider
        BossSlider.value = VidaAtual;
        //Atualização do timer
        timer += Time.deltaTime;

        if (VidaEscudo == 0) // Se escudo sem vida
        {
            EscudoQuebra(); // Chama escudo quebra

        }

        if (VidaAtual <= 155 && ChamouFase2 is false) // Se a vida for 66 ou menos e ainda n chamou a fase
        {
            ChamouFase2 = true;

            RedFase2 = new Color32(243, 130, 130, 255);
            SprRen.color = RedFase2;

            SetFase = 2;
            Anim.SetBool("PodeDefender", true); 
            Anim.SetBool("SegundaFase", true);
            VelocidadeATK.timeBetweenAttacks = 0.2f;
        }

        if (VidaAtual <= 77 && ChamouFase3 is false) // Se a vida for 33 ou menos e ainda n chamou a fase
        {
            ChamouFase3 = true;

            RedFase3 = new Color32(243, 68, 68, 255);
            SprRen.color = RedFase3;

            SetFase = 3;
        }



    }
    // Escudo quebra e reseta
    public void EscudoQuebra() 
    {
        Quebrou = true;
        VidaEscudo = 3;
        Anim.SetTrigger("DefesaBaixa");
        Anim.SetBool("Defende", false);
        Anim.SetBool("PodeAtacar", true);
        // se a fase for 2 desligue as traps
        if (SetFase == 2)
        {
            TrapScript.TrapOn = false; // A trap da esquerda liga
            TrapScript2.TrapOn = false; // A trap da direita liga
        }
        // Chama a corotina
        StartCoroutine(DefendeTimer());
        //Faz esperar para ligar dnv a defesa
        IEnumerator DefendeTimer()
        {
            yield return new WaitForSeconds(15);
            Anim.SetBool("PodeDefender", true);
            //Se for fase 3 espera 15 para pode spawnar
            if (SetFase == 3)
            {
                Anim.SetBool("PodeSpawnar", true);
            }

        }

    }
    // Dano no boss
    public void TomarDano(int Dano) // Informa que Tomar dano é um numero inteiro chamado dano (que pode ser chamado em outro script)
    {

        VidaAtual -= Dano; //define que a vida atual é VidaAtual - Dano = VidaAtual
        BossSlider.value = VidaAtual;// define que o slider de vida é igual a vida atual

        if (VidaAtual <= 0 && !isDead) // se a vida atual for = ou menor que zero e não estiver morto
        {
            Death(); // morreu
        }
    }
        // Colisão do boss -> escudo
    public void OnTriggerEnter2D(Collider2D collision)  // void de colisao
    {
        if (collision.CompareTag("Espada") && Anim.GetBool("Defende") == true) // se a tag c q colidiu for espada, e o boss tiver defendendo
        {

         VidaEscudo = VidaEscudo - 1; // perde 1 na vida do escudo
         TomarDano(-10);
        }
        else
        {
            if (collision.CompareTag("Fogo") && Anim.GetBool("Defende") == true)
            {
                TomarDano(-5);
            }
        }
    }


    // Morte do boss
    void Death() // morreu
    {

        isDead = true; // está morto
        Anim.SetTrigger("Morreu"); // seta animação de morte

        StartCoroutine(Esperar());
        IEnumerator Esperar()
        {
            yield return new WaitForSeconds(1.5f);
            LVLScript.LoadNextLevel();
        }



        //  playerController.enabled = false; // não pode mais controlar player
        //  player_ATK.enabled = false; // não pode mais atacar
        //  SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    // Tempo para atacar
    public void TimerATK()
    {
        StartCoroutine(ATKtime());

        IEnumerator ATKtime()
        {
            yield return new WaitForSeconds(tempoATK);
            Anim.SetBool("PodeAtacar", true);

        }
    }
    // Spawnar mage
    public void Spawna()
    {
        Anim.SetBool("PodeSpawnar", false);
        Instantiate(MagePrefab, MageSpawn.position, MageSpawn.rotation);
        
    }

    public void CallAudio()
    {
        if (audioS.clip != null)
        {
            StartCoroutine(SomTimer0());
            IEnumerator SomTimer0()
            {
                yield return new WaitForSeconds(audioS.clip.length);
                if (audioS.clip = SomCall)
                {
                    audioS.Play();
                }
                else
                {
                    audioS.clip = SomCall;
                    audioS.Play();
                }
            }
        }
        else
        {
            audioS.clip = SomCall;
            audioS.Play();
        }


    }

    public void DefAudio()
    {
        if (audioS.clip != null)
        {
            StartCoroutine(SomTimer());
            IEnumerator SomTimer()
            {
                yield return new WaitForSeconds(audioS.clip.length);

                if (audioS.clip = SomDefesa)
                {
                    audioS.Play();
                }
                else
                {
                    audioS.clip = SomDefesa;
                    audioS.Play();
                }
            }
        }
        else
        {
            audioS.clip = SomDefesa;
            audioS.Play();
        }

        
    }

    public void AtkAudio()
    {
        if (audioS.clip != null)
        {
            StartCoroutine(SomTimer2());
            IEnumerator SomTimer2()
            {
                yield return new WaitForSeconds(audioS.clip.length);
                if (audioS.clip = SomBastão)
                {
                    audioS.Play();
                }
                else
                {
                    audioS.clip = SomBastão;
                    audioS.Play();
                }
            }
        }
        else
        {
            audioS.clip = SomBastão;
            audioS.Play();
        }

    }

}

