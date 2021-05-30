using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTimer : MonoBehaviour
{
    public static float ScoreMax = 1000;
    public float Score;
    public float LessScore;



    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }



    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        LessScore = Time.time;

        Score = ScoreMax - LessScore;
    }

    public void Destruir()
    {
        Destroy(gameObject);

    }

}
