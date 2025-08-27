using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class signScript : MonoBehaviour
{
    public GameObject ShowText;

    void OnTriggerEnter2D (Collider2D trig)
    {
        if (trig.gameObject.tag == "Player")
        {
            Debug.Log("Activate sign");
            ShowText.SetActive(true);
            Invoke("Deactivate", 3);
        }
    }

    public void Deactivate()
    {
        ShowText.SetActive(false);
        Debug.Log("Deactivate sign");
    }
}
