using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GeneratedObject : MonoBehaviour
{	
	bool playerInsideMe = false;

	Transform ground;

	private void Start()
	{
		ground = GameObject.FindGameObjectWithTag("ground").transform;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			FindObjectOfType<ActivateTextPush>().showText();

			playerInsideMe = true;
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.E) && playerInsideMe)
		{
			FindObjectOfType<ActivateTextPush>().hideText();

			gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);

			if (gameObject.CompareTag("bench"))
			{
				gameObject.transform.rotation = Quaternion.Euler(-90, 0, 0);

				transform.position = new Vector3(transform.position.x, ground.transform.position.y - 1.8f, transform.position.z);
			}

			else
			{
				gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);

				transform.position = new Vector3(transform.position.x, ground.transform.position.y, transform.position.z);
			}

			

			//Destroy(gameObject);
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
