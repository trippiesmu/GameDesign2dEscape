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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void update()
    {
        if(Vector2.Distance(transform.position, target.position)<shotDistance)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            nextShotTime = Time.time + timeBetweenShots;
        }
    }
}
