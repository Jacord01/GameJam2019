using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    public float health = 100.0f;

    public void TakeDamage(float dmg)
    {
        health -= dmg;

        if (health <= 0.0f)
        {
            Transform o = transform.parent;

            if (o != null) Destroy(o.gameObject);
            else Destroy(gameObject);
        }
    }
}
