using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public GameObject bonus;
    public float dropRate = 0.25f;
    public Transform parent;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void monDrop()
    {
        Instantiate(bonus, parent.position, parent.rotation);
    }

}
