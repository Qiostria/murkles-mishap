using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public int EnemySpeed;
    public int xMoveDirection;

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(xMoveDirection, 0));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(xMoveDirection, 0) * EnemySpeed;
        if (hit.distance < 0.3f)
        {
            Flip();
            if (hit.collider.tag == "Player")
            {
                hit.collider.gameObject.transform.position = new Vector2(0, 2.5f);
            }
        }
    }
    void Flip()
    {
        if (xMoveDirection > 0)
        {
            xMoveDirection = -1;
        } 
        else
        {
            xMoveDirection = 1;
        }
    }

}
