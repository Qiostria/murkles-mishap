using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fakeBlock : MonoBehaviour
{
    void OnCollisionEnter2D (Collision2D trig)
    {
        if (trig.collider.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
