using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
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

        AnalyticsResult analyticsResult = Analytics.CustomEvent(
            "Vitória",
            new Dictionary<string, object> {
                {"Level ganho: ", SceneManager.GetActiveScene().buildIndex }

            }

            );
        Debug.Log("Resultado dos analytics" + analyticsResult);


        AnalyticsResult analyticsScore = Analytics.CustomEvent(
        "Pontos do player",
        new Dictionary<string, object>
        {
            {"Pontos: ", scoreTimer.Score}
        }
        );
        Debug.Log("Resultado dos analytics" + analyticsScore);
    }

    // Update is called once per frame


}
