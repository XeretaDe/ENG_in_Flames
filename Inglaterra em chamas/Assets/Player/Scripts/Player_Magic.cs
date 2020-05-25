using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Magic : MonoBehaviour
{
    // Instantiate
    public Transform MagicPoint;
    public GameObject FogoPrefab;

    public static bool TemMagia = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Condition para Instantiate

        if (Input.GetButtonDown("Fire2") && TemMagia ) 
        {
            Magia();
        }
    }

    void Magia()
    {
        Instantiate(FogoPrefab, MagicPoint.position, MagicPoint.rotation);
        // O que e onde eh Instantiated

    }
}
