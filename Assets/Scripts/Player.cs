using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bullet;
    public Transform parent;

    bool onFire = false;
    bool noPowerUp = true;
    float nbrPowerUp = 0f;
    float startTime = 0.0f;
    public float shootDelay = 0.5f;

    public float horizontalSpeed = 2.0f;
    public float verticalSpeed = 2.0f;

    private bool isMouseLocked = false;


    void Start()
    {

    }

    void Update()
    {
        if (!isMouseLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            isMouseLocked = true;
        }

        //----------------------- ZONE POWER UP -----------------------
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

        //----------------------- ZONE DEPLACEMENT JOUEUR -----------------------
        var horizontalMouv = horizontalSpeed * Input.GetAxis("Mouse X");
        var verticalMouv = verticalSpeed * Input.GetAxis("Mouse Y");

        float newX = Mathf.Clamp(transform.position.x + horizontalMouv, -5.5f, 5.5f);
        float newY = Mathf.Clamp(transform.position.y + verticalMouv, -7f, 7f);

        transform.position = new Vector3(newX, newY, transform.position.z);

    }

    //----------------------- ZONE COLLISION JOUEUR -----------------------

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ennemy")
        {

            Destroy(collision.gameObject);
            Destroy(gameObject);
            var myUIScript = FindObjectOfType<UiScript>();
            myUIScript.SpawnLoseText();

        }
        if (collision.gameObject.tag == "Boss")
        {

            Destroy(gameObject);
            var myUIScript = FindObjectOfType<UiScript>();
            myUIScript.SpawnLoseText();

        }
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
        if (collision.gameObject.tag == "EnnemyBullet")
        {

            Destroy(collision.gameObject);
            Destroy(gameObject);
            var myUIScript = FindObjectOfType<UiScript>();
            myUIScript.SpawnLoseText();

        }
    }
}
