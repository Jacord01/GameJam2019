using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletDamage : MonoBehaviour {

    public int damage_ = 1;

    GameObject player_;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player_ = collision.gameObject;
            player_.GetComponent<HealthScore>().ReduceHealth(damage_);
        }
    }
}
