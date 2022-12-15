using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public float shotDistance;
    public Transform target;
    public GameObject projectile;
    public float timeBetweenShots;
    private float nextShotTime;
    public AudioSource Enemyshoot;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            Enemyshoot.Play();
        }
 
    }
}
