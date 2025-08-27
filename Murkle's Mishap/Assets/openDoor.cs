using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openDoor : MonoBehaviour
{
    public GameObject DoorClosed;
    // Start is called before the first frame update
    void Start()
    {
        DoorClosed.SetActive(true);
    }

    // Update is called once per frame


    void OnTriggerEnter2D()
    {
        DoorClosed.SetActive(false);
    }
}
