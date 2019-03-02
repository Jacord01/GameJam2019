using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{

    bool shooting = false;

    GameObject player;

    public GameObject bullet;

    public float speed = 100.0f;

    Transform playerTransform;

    private void Update()
    {
        if (shooting) shoot();
    }

    void OnTriggerEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            shooting = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            shooting = false;
        }
    }

    void shoot()
    {
        Instantiate(bullet, transform.position, transform.rotation);

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
    }

}

