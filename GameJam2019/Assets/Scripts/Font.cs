using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Font : MonoBehaviour {

    private bool dash_, shield_, lifeSteal_;
    private int currentPower_;
    private float timeLeft_;
    private bool wait_;
    public int entitiesMargin_ = 0;
    GameManagerComp gameManager_;

    void Start()
    {
        gameManager_ = GameObject.FindObjectOfType<GameManagerComp>();
        dash_ = false;
        shield_ = false;
        lifeSteal_ = false;

        if (entitiesMargin_ == 0)
            entitiesMargin_ = 3;

        //Cooldown 
        timeLeft_ = 0.0f;
        wait_ = false;  
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

    int CheckMostCommon()
    {
        int mostCommon = currentPower_;
        int fly = 0, slime = 0, robot = 0;

        fly = gameManager_.flyEnemies_.Count;
        slime = gameManager_.slimeEnemies_.Count;
        robot = gameManager_.robotEnemies_.Count;

        int x = max(fly, slime);
        if (max(x, robot) == x)
            if ((x - robot) >= entitiesMargin_)
                mostCommon = x;
            else;

        else if ((robot - x) >= entitiesMargin_)
            mostCommon = robot;

            return mostCommon;
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
        currentPower_ = CheckMostCommon();

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

    //Auxiliar
    int max(int first, int second)
    {
        if (first > second)
            return first;
        else
            return second;
    }//Returns the max between 2 integers,if both are the same, it returns the second one

}
