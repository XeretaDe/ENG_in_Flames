using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Magic : MonoBehaviour
{

    [SerializeField] public float Tempo_Atks; // Float do tempo entre os ataques
    private float Next_Atk; // float que declara quando o próximo ataque deverá ser dado

    // Instantiate
    public Transform MagicPoint;
    public GameObject FogoPrefab;

    public static bool TemMagia = false;

    protected Joybutton1 joybutton1;

    // Start is called before the first frame update
    void Start()
    {
        joybutton1 = FindObjectOfType<Joybutton1>();
    }

    // Update is called once per frame
    void Update()
    {
        // Condition para Instantiate

        if (joybutton1.Pressed && TemMagia && Time.time > Next_Atk) 
        {
            Magia();
        }
    }

    void Magia()
    {
        Instantiate(FogoPrefab, MagicPoint.position, MagicPoint.rotation);
        Next_Atk = Time.time + Tempo_Atks; // Define o tempo p o proximo ataque sendo o tempo do jogo + o tempo do ultimo ataque

        // O que e onde eh Instantiated

    }
}
