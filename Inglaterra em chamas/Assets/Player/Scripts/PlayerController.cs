using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float PuloForce;// Float que indica altura do pulo APARECE NA UNITY
    [SerializeField] public float Velocidade; // Float que indica velocidade APARECE NA UNITY

    private bool PraDireita = true; // Indica desde o start que personagem esta para direita
    private bool Pulando = false; // Indica que no start o player n esta pulando
    private bool noChao = false; // Indica se o player esta tocando ou n o chao

    private Transform CheckDeChao; // Cria o transform do Collider de CheckDeChao para verificar se ta no chao
    private Rigidbody2D rb2d; // Declara RigidBody
    public Animator Anim; // Declara Animator

    protected Joystick joystick;
   // protected Joybutton joybutton;


    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
     //   joybutton = FindObjectOfType<Joybutton>();


        Anim = GetComponent<Animator>(); // Chamando Animator
        rb2d = GetComponent<Rigidbody2D>(); // Chamando Rigid
        CheckDeChao = gameObject.transform.Find("CheckDeChao"); // declara que o CheckDeChao tem que encontrar um objeto e transformar-se nele
    }

    // Update is called once per frame
    void Update()
    {


        // Declarando que para estar no chao o raio de fisica 2D tem que estar entre 1 e o groundcheck
        noChao = Physics2D.Linecast(transform.position, CheckDeChao.position, 1 << LayerMask.NameToLayer("Chão"));

        //Pulando
        if (joystick.Vertical > 0.3 && noChao) // Checa se o jogador aperta espaço, e se está no chão, se estiver segue.         
        {
            Pulando = true; //Declara que esta pulando
            Anim.SetTrigger("Pulou"); // Liga animacao de pulo

        }

    }

    void FixedUpdate()
    {
        // Andando        

        float h = joystick.Horizontal; // declara um float h que define a linha horizonta (negativa ou positiva) do player

        Anim.SetFloat("Velocidade", Mathf.Abs(h)); // Seta um Float como velocidade para andar, enquanto o Abs faz a funcao retornar sempre valor positivo.
        rb2d.velocity = new Vector2(h * Velocidade, rb2d.velocity.y); // adiciona velocidade em h, multiplicando pela velocidade, e mantem a velocidade no eixo y estavel

        if (h > 0 && !PraDireita) // se h for pra direita (eixo X > 0) e estar inverso a direita (logo esquerda)
        {
            Virar(); //Invoca void de virar o personagem
        }
        else if(h < 0 && PraDireita) // se h for para esquerda (eixo X < 0) e estar a direita
        {

            Virar(); // invoca void
        }

        //Pulando
        if (Pulando)
        {
            rb2d.AddForce(new Vector2(0, PuloForce)); // adiciona forca do pulo e nada no x
            Pulando = false;// declara que ja pulou

        }


    }

    void Virar()
    {
        PraDireita = !PraDireita; // Inverte o valor de Virado Pra Direita, acertando a declaração

        transform.Rotate(0f, 180f, 0f); // rotaciona em 180 graus o player

    }

}
