using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spike : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.tag == "Player")
        {
            Debug.Log("Spike Hit!");
            hit.gameObject.transform.position = new Vector2(0, 2);
        }
    }
}
