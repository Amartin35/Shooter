using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnnemy : MonoBehaviour
{
    public GameObject Ennemy_1;
    public GameObject Ennemy_2;



    // Start is called before the first frame update
    void Start()
    {
        SpawnEnnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnEnnemy()
    {
        for (int j = 2; j < 5; j++)
        {
            for (int i = -8; i < 6; i++)
            {
                if(i%2 == 0)
                {
                    Instantiate(Ennemy_2, new Vector3(2 + 1.2f * i, j, 0), Quaternion.identity);
                }
                else 
                {
                    Instantiate(Ennemy_1, new Vector3(2 + 1.2f * i, j, 0), Quaternion.identity);
                }
            }
        }
    }
}
