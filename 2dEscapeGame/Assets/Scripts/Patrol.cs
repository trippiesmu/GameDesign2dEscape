using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{

    public float speed;
    private float waitTime;
    public float startWaitTime;
    public AudioSource EnemyMovement;

    public Transform[] patrolPoints;
    private int randomSpot;
    bool facingRight = true;
    
    Animator animator;
    string currentAnimState;
    const string ENEMY_IDLE = "Enemy_Idle";
    const string ENEMY_SHOOT = "Shoot_Front";
    

    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, patrolPoints.Length);
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, patrolPoints[randomSpot].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, patrolPoints[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, patrolPoints.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "patrolpoint")
        {
            Flip();
        }
        if (collision.tag == "Player")
        {
            ChangeAnimationState(ENEMY_SHOOT);
        }
    }
    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
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