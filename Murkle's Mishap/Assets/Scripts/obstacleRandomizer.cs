using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleRandomizer : MonoBehaviour
{
    public bool RandMap = false; //this is for debugging on Unity only
    public GameObject random1;
    public GameObject random2;
    public GameObject random3;
    public GameObject random4;


    void Start()
    {
        Randomize();
    }

    public void Randomize()
    {
        random1.SetActive(false);
        random2.SetActive(false);
        random3.SetActive(false);
        random4.SetActive(false);
        int rng = Random.Range(1, 4);
        if (rng == 1)
        {
            random1.SetActive(true);
        }
        else if (rng == 2)
        {
            random2.SetActive(true);
        }
        else if (rng == 3)
        {
            random3.SetActive(true);
        }
        else
        {
            random4.SetActive(true);
        }
    }


}

