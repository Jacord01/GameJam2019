using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GeneratedObject : MonoBehaviour
{	
	bool playerInsideMe = false;

	bool alreadyInteracted = false;

	Transform ground;
    GameManagerComp gameManager_;

	private void Start()
	{
		Camera.main.GetComponent<GlitchEffect>().enabled = false;
		gameManager_ = GameObject.FindObjectOfType<GameManagerComp>();
		ground = GameObject.FindGameObjectWithTag("ground").transform;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player") && !alreadyInteracted)
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

			alreadyInteracted = true;

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

			Camera.main.GetComponent<GlitchEffect>().enabled = true;

			Invoke("disableGlitch", 1.5f);

            gameManager_.IncreaseScore(5);
		}
	}

	void disableGlitch()
	{
		Camera.main.GetComponent<GlitchEffect>().enabled = false;
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
