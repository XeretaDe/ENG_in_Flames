using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musica : MonoBehaviour
{
    private static Musica mp;
    // Start is called before the first frame update
    void Awake()
    {
        if (mp == null)
        {
            mp = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(mp.gameObject);
            mp = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
