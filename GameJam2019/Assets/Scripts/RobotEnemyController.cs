using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotEnemyController : MonoBehaviour {


    public float radius;
    public int damage_ = 1;
    bool shooting;
    GameObject player;

	// Use this for initialization
	void Start () {
        radius = GetComponent<SphereCollider>().radius;
	}
	
	// Update is called once per frame
	void Update () {
        if (shooting) shoot();
    }

    void OnTriggerEnter(Collider other)
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
        if (!player.GetComponent<HealthScore>().shield_)
        {
            player.GetComponent<HealthScore>().ReduceHealth(damage_);
        }
    }
}
