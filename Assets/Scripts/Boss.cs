using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject EnnemyBullet;
    public Transform parent;
    private float moveSpeed;
    private bool moveRight;
    private int bossHitCount = 0;
    public int bossHitThreshold = 250;
    public float timeBetweenShots = 0.01f;
    private float timeSinceLastShot = 0.0f; 

    void Start()
    {
        moveSpeed = 3f;
        moveRight = true;
    }

    void Update()
    {
        //----------------------- ZONE TIR BOSS -----------------------
        timeSinceLastShot += Time.deltaTime;

        if (timeSinceLastShot >= timeBetweenShots)
        {
            Instantiate(EnnemyBullet, parent.position, parent.rotation);
            timeSinceLastShot = 0.0f;
        }

        //----------------------- ZONE DEPLACEMENT BOSS -----------------------

        if (transform.position.x > 4f)
        {
            moveRight = false;
        }
        else if (transform.position.x < -4f)
        {
            moveRight = true;
        }

        if (moveRight)
        {
            transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
        }
    }

    //----------------------- ZONE COLLISION BOSS -----------------------
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            bossHitCount++;
            Destroy(collision.gameObject);

            if (bossHitCount >= bossHitThreshold)
            {
                Destroy(gameObject);
            }
        }
    }
}
