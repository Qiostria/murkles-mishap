using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class deathCount : MonoBehaviour 
{ 
    private static int deaths = 0;
    public float Deaths = deaths;
    public GameObject DeathCounterUI;

    void LateUpdate()
    {

        DeathCounterUI.gameObject.GetComponent<Text>().text = ("Deaths:" + Deaths);
        if (Deaths >= 10)
        {
            Debug.Log("Map Randomized");
            SceneManager.LoadScene("Level1");
        }       
    }

    void OnTriggerEnter2D (Collider2D trig)
    {
        Deaths += 0.5f;
    }
}
