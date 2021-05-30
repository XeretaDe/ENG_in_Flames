using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public static bool IsPaused = false;

    public GameObject PauseMenuUI;

    public GameObject Player;
    

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
            {
                Resume();

            }
            else
            {
                Pause();
            }
        }   
    }

    public void Resume()
    {
        IsPaused = false;
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;

        MonoBehaviour[] scripts = Player.GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour script in scripts)
        {
            script.enabled = true;
        }


    }
    public void Pause()
    {
        IsPaused = true;
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;

        MonoBehaviour[] scripts = Player.GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour script in scripts)
        {
            script.enabled = false;
        }

    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
