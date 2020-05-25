using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_ATK : MonoBehaviour
{
    
    [SerializeField] public float Tempo_Atks; // Float do tempo entre os ataques
    private float Next_Atk; // float que declara quando o próximo ataque deverá ser dado

    public AudioClip SomEspada;
    private AudioSource audioS;

    Animator Anim; // chamando Animator


    // Start is called before the first frame update
    void Start()
    {
        audioS = gameObject.GetComponent<AudioSource>();
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > Next_Atk) // Time.time Verifica o tempo desde o inicio do start do jogo
        {

            Atacando(); // chama void de ataque

        }
    }

    void Atacando()
    {
        audioS.clip = SomEspada;
        audioS.Play();
        Anim.SetTrigger("Atacou"); // Seta animation de ataque
        Next_Atk = Time.time + Tempo_Atks; // Define o tempo p o proximo ataque sendo o tempo do jogo + o tempo do ultimo ataque

    }


}
