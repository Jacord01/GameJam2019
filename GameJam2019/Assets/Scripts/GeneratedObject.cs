using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GeneratedObject : MonoBehaviour
{
	bool canIBeDestroyed = false;
	
	bool playerInsideMe = false;

	

	private void Start()
	{
		int rnd = Random.Range(0,4);

		if(rnd == 0)
		{
			canIBeDestroyed = true;
		}

	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player") && canIBeDestroyed)
		{
			FindObjectOfType<ActivateTextPush>().showText();

			playerInsideMe = true;
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.E) && playerInsideMe && canIBeDestroyed)
		{
			FindObjectOfType<ActivateTextPush>().hideText();

			Destroy(gameObject);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			FindObjectOfType<ActivateTextPush>().hideText();

			playerInsideMe = false;

		}
	}

}
