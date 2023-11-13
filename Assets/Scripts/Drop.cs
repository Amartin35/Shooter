using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public GameObject bonus;
    public Transform parent;

    void Start()
    {
        
    }

    // FAIS SPAWN LE DROP
    public void monDrop()
    {
        Instantiate(bonus, parent.position, parent.rotation);
    }
}
