using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Font : MonoBehaviour {

    private bool dash_, shield_, lifeSteal_;
    private int currentPower_;
    private float timeLeft_;
    private bool wait_;

    void Start()
    {      
        dash_ = false;
        shield_ = false;
        lifeSteal_ = false;

        //Cooldown 
        timeLeft_ = 30.0f;
        wait_ = true;  

        int rnd = Random.Range(1, 4);
        currentPower_ = rnd;

        if (rnd == 1)
            dash_ = true;
        else if (rnd == 2)
            shield_ = true;
        else if (rnd == 3)
            lifeSteal_ = true;
    }

    void Update()
    {
        if (!wait_)
        {
            timeLeft_ -= Time.deltaTime;           
            if (timeLeft_ < 0)
            {
                wait_ = true;
                timeLeft_ = 30.0f;
            }
        }
    }

     void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<GeneratedObject>())
		{
			Destroy(other.gameObject);

		}

        //Habilidades
        if (other.gameObject.CompareTag("Player"))
        {
            if (wait_)
            {
                NextPower();
            }
        }
	}

    void OnTriggerStay (Collider other)
    {
        //Habilidades
        if (other.gameObject.CompareTag("Player"))
        {
            if (wait_)
            {
                NextPower();
            }
        }
    }

    public void NextPower()
    {
        currentPower_ = (currentPower_ + 1) % 4;
        if (currentPower_ == 0)
            currentPower_++;

        switch (currentPower_)
        {
            case 1:
                dash_ = true;
                shield_ = false;
                lifeSteal_ = false;
                break;
            case 2:
                dash_ = false;
                shield_ = true;
                lifeSteal_ = false;
                break;
            case 3:
                dash_ = false;
                shield_ = false;
                lifeSteal_ = true;
                break;
        }
        wait_ = false;
    }


}
