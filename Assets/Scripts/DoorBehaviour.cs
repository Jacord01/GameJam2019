using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorBehaviour : MonoBehaviour {

	int numberOfEnemies = 0;

	TextMesh text;

	// Use this for initialization
	void Start()
	{
		text = GetComponentInChildren<TextMesh>();	
	}
	
	public void setEnemies(int enem)
	{
		gameObject.SetActive(true);

		numberOfEnemies = enem;

		text.text = numberOfEnemies.ToString();
	}

	public void eliminateEnemy()
	{
		numberOfEnemies--;
		text.text = numberOfEnemies.ToString();

		if (numberOfEnemies <= 0)
		{
			gameObject.SetActive(false);
		}
	}
}
