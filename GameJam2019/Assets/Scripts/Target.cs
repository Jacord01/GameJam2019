using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    public float health = 30.0f;

    public void TakeDamage(float dmg)
    {
        health -= dmg;
    }
}
