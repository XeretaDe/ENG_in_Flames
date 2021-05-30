using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CallScore : MonoBehaviour
{
    public bool Venceu;

    protected ScoreTimer scoreTimer;
    protected TextMeshProUGUI Score;

    // Start is called before the first frame update
    void Start()
    {
        Venceu = true;
        scoreTimer = FindObjectOfType<ScoreTimer>();
        Score = gameObject.GetComponent<TextMeshProUGUI>();
        Score.text = "Pontuação: " + scoreTimer.Score;

        
    }

    // Update is called once per frame


}
