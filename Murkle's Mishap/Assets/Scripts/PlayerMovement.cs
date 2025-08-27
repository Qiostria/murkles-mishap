using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement: MonoBehaviour
{
    public int playerSpeed = 10;
    public int playerJumpPower = 1250;
    private float moveX;
    public bool isGrounded;
    public float distanceToBottomOfPlayer = 0.9f;
    public PlayerScore FromPlayer;

    //Audio
    public AudioSource JumpSound;
    public AudioSource StompSound;

    void Update()
    {
        playerMove();
        playerRaycast();
        if (gameObject.transform.position.y < -7)
        {
            transform.position = new Vector2(0, 2.5f);
        }
    }


    void playerMove()
    {
        //control
        moveX = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && isGrounded == true){
            Jump();
        }
        //animations
        if (moveX != 0.0f)
        {
            GetComponent<Animator>().SetBool("isMoving", true);
        }
        else
            GetComponent<Animator>().SetBool("isMoving", false);
        //direction
        if (moveX < 0.0f)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (moveX > 0.0f)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        //physics
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);

    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce (Vector2.up * playerJumpPower);
        isGrounded = false;
        JumpSound.Play();
    }

    void OnCollisionEnter2D (Collision2D col)
    {
        //Debug.Log("Player has collided with" + col.collider.name);
        if (col.gameObject.tag == "ground")
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        if (col.gameObject.tag == "spike")
        {
            Debug.Log("Spike Hit!!!");
            transform.position = new Vector2(0, 2.5f);
        }
    }
    void playerRaycast()
    {

        RaycastHit2D rayDown = Physics2D.Raycast (transform.position, Vector2.down);
        if (rayDown && rayDown.distance < distanceToBottomOfPlayer && rayDown.collider.tag == "enemy")//
        {
            //Debug.Log("Touched thing");
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 700);
            rayDown.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 200);
            rayDown.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1000);
            rayDown.collider.gameObject.GetComponent<SpriteRenderer>().flipY = true;
            rayDown.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            rayDown.collider.gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            rayDown.collider.gameObject.GetComponent<EnemyMove>().enabled = false;
            StompSound.Play();
            isGrounded = true;
        }

            

    }

}
