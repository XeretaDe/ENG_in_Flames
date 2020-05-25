using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MudarCena : MonoBehaviour
{
    GameObject LevelLoader;
    LevelLoader LVLScript;
    // Start is called before the first frame update
    void Start()
    {
        // Chamadas de cena

        LevelLoader = GameObject.Find("LevelLoader");
        LVLScript = LevelLoader.GetComponent<LevelLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            LVLScript.LoadNextLevel();
        }
    }
}
