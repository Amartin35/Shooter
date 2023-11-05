using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyBullet : MonoBehaviour
{
    public Rigidbody2D monRigidBody;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        monRigidBody.velocity = Vector3.down * speed;
    }



}
