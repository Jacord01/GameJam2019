using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    int health_;
    public Slider healthBar;

	// Use this for initialization
	void Start () {
        health_ = 100;
        healthBar.value = health_;
    }

    // Update is called once per frame
    void Update () {

        //Update health on Hud
        healthBar.value = health_;
    }

    public int GetHealth()
    {
        return health_;
    }

    public void SetHealth(int amount)
    {
        health_ = amount;
    }

    public void ReduceHealth (int amount)
    {
        health_ -= amount;
    }

    public void IncreaseHealth(int amount)
    {
        health_ += amount;
    }
}
