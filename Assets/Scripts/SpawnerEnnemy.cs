using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnnemy : MonoBehaviour
{
    public GameObject Ennemy_1;
    public GameObject Ennemy_2;

      void Start()
      {
          SpawnEnnemy();
          Invoke("Boss", 10f);
      }

    // FAIS SPAWN LES ENNEMIS
    public void SpawnEnnemy()
      {
          for (int j = 2; j < 5; j++)
          {
              for (int i = -3; i < 3; i++)
              {
                    Instantiate(Ennemy_2, new Vector3(1 + 2f * i, 1+2f * j, 0), Quaternion.identity);
              }
          }
      }

    // FAIS SPAWN LE BOSS
    public void Boss()
    {
         Instantiate(Ennemy_1, new Vector3(0, 5, 0), Quaternion.identity);
    }
}
