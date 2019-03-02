using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {

	bool setAvaliable = false;

	bool created = false;

	private void Start()
	{
		//gameObject.SetActive(true);
		setAvaliable = true;
	}

	// Update is called once per frame
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Q) && !created)
		{
			if (setAvaliable)
			{
				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

				if (Physics.Raycast(ray, out hit))
				{
					GameObject g = GameObject.FindGameObjectWithTag("floor");
					Transform t = g.transform;
					
					transform.position = new Vector3( hit.point.x, t.position.y + 1, hit.point.z);
					created = true;
				}
			}

			else gameObject.SetActive(false);
		}
	}

	public void set(bool s)
	{
		setAvaliable = s;

		if (s)
		{
			gameObject.SetActive(true);
			created = false;
		}

		else gameObject.SetActive(false);

	}
}
