using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float TransitionTimer = 1f;

    GameObject Player;

    // Update is called once per frame
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(TransitionTimer);

        SceneManager.LoadScene(levelIndex);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;

        MonoBehaviour[] scripts = Player.GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour script in scripts)
        {
            script.enabled = true;
        }
    }

}
