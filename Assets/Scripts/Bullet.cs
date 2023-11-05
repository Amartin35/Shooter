using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D monRigidBody;
    public float speed;
    public GameObject square;
    public Transform parent;
    public Drop monLoot;
    private ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        monRigidBody.velocity = Vector3.up * speed;

       
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ennemy")
        {
            Destroy(collision.gameObject);
            var dropChance = Random.Range(0, 10);
            if (dropChance == 3)
            {
                monLoot.monDrop();
            }
            Destroy(gameObject);

          
            scoreManager.IncrementScore(10); 
        }
    }
}
