using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Font : MonoBehaviour {

	private void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<GeneratedObject>())
		{
			Destroy(other.gameObject);

		}
	}
}
