using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnnemy : MonoBehaviour
{
    public GameObject Ennemy_1;
    public GameObject Ennemy_2;
    public float yOffset = 1.0f;
    public float downForce = 1.0f;
    public float initialDelay = 2.0f;
    public float repeatDelay = 5.0f;
    public float gravityMultiplier = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnnemy", initialDelay, repeatDelay);
    }


    public void SpawnEnnemy()
    {
        Physics2D.gravity = new Vector2(0, -10 * gravityMultiplier);

        for (int j = 2; j < 5; j++)
        {
            for (int i = -3; i < 3; i++)
            {
                if(i%2 == 0)
                {
                    Instantiate(Ennemy_2, new Vector3(1 + 2f * i, 1+2f * j, 0), Quaternion.identity);
                }
                else 
                {
                    Instantiate(Ennemy_1, new Vector3(1 + 2f * i, 1 + 2f * j, 0), Quaternion.identity);
                }
            }

        }
        gravityMultiplier += 0.8f;

    }
}
