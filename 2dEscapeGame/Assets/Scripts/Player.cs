using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;

    float inputHorizontal;
    float inputVertical;

    public float speed = 10f;
    bool facingLeft = true;

    Animator animator;
    string currentAnimState;
    const string PLAYER_IDLE = "Player_Idle";
    const string PLAYER_WALK_LEFT = "Walk_Left";
    const string PLAYER_WALK_RIGHT = "Walk_Right";
    const string PLAYER_WALK_UP = "Walk_Front";
    const string PLAYER_WALK_DOWN = "Walk_Back";

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");

        {
            Vector3 pos = transform.position;

            if (Input.GetKey("w"))
            {
                pos.y += speed * Time.deltaTime;
            }
            if (Input.GetKey("s"))
            {
                pos.y -= speed * Time.deltaTime;
            }
            if (Input.GetKey("d"))
            {
                pos.x += speed * Time.deltaTime;
            }
            if (Input.GetKey("a"))
            {
                pos.x -= speed * Time.deltaTime;
            }
            if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
            {
                ChangeAnimationState("Player_Idle");
            }
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                ChangeAnimationState(PLAYER_WALK_RIGHT);
            }
            else if (Input.GetAxisRaw("Horizontal") < 0)
            {
                ChangeAnimationState(PLAYER_WALK_LEFT);
            }
            else if (Input.GetAxisRaw("Vertical") > 0)
            {
                ChangeAnimationState(PLAYER_WALK_DOWN);
            }
            else if (Input.GetAxisRaw("Vertical") < 0)
            {
                ChangeAnimationState(PLAYER_WALK_UP);
            }

            transform.position = pos;
        }

    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingLeft = !facingLeft;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "bullet")
        {
            SceneManager.LoadScene("Game Over");
        }
    }
    void ChangeAnimationState(string newState)
    {
        //stop animation from interrupting itself
        if (currentAnimState == newState)
        {
            return;
        }

        //Play new anitmation
        animator.Play(newState);

        currentAnimState = newState;

    }
}
