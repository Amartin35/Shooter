using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyBullet : MonoBehaviour
{
    public Rigidbody2D monRigidBody;
    public float speed;
    public Transform parent;

    private float timer;
    private float timer2;
    private int sens =1;

    void Start()
    {
        // GERE LA VITESSE DE LA BALLE
        monRigidBody.velocity = Vector3.down * speed;
    }
    private void Update()
    {
        timer += Time.deltaTime;
        timer2 += Time.deltaTime;
        if (timer>=1)
        {
            monRigidBody.velocity = (Vector2.down+ Vector2.right * sens) * speed ;
            timer = 0;
            sens *= -1;
        }
        if(timer2>=3)
        {
            Destroy(gameObject);
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag =="Mur")
        {
            monRigidBody.velocity *= -Vector2.right;
        }
    }
}
