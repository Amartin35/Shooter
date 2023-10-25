using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bullet;
    public Transform parent;
    public Transform limitL;
    public Transform limitR;
    public Transform limitT;
    public Transform limitD;

    bool onFire = false;
    bool noPowerUp = true;
    float nbrPowerUp = 0f;
    float startTime = 0.0f;
    public float shootDelay = 0.5f;

    public float horizontalSpeed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        if (noPowerUp)
        {
            if (Input.GetMouseButton(0) && onFire == false)
            {

                Instantiate(bullet, parent.position, parent.rotation);
                onFire = true;
                startTime = Time.time;
            }
            if (onFire)
            {
                if (startTime + shootDelay < Time.time)
                {
                    onFire = false;
                }
            }
        }

        if (!noPowerUp)
        {
            if (Input.GetMouseButton(0) && onFire == false)
            {

                Instantiate(bullet, parent.position, parent.rotation);
                onFire = true;
                startTime = Time.time;
            }
            if (onFire)
            {
                if (startTime + shootDelay / nbrPowerUp < Time.time)
                {
                    onFire = false;
                }
            }
        }
 

        if (transform.position.x < limitL.position.x)
         {
             transform.position = new Vector3(limitR.position.x, transform.position.y, transform.position.z);
         }
         if (transform.position.x > limitR.position.x)
         {
             transform.position = new Vector3(limitL.position.x, transform.position.y, transform.position.z);
         }




        var h = horizontalSpeed * Input.GetAxis("Mouse X");
        transform.Translate(h, 0, 0);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bonus")
        {
            Destroy(collision.gameObject);
            noPowerUp = false;
            nbrPowerUp += 1;
            print("power up");
            print(nbrPowerUp);
        }
    }
}
