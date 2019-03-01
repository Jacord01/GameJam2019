using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FloatingEnemyMovement : MonoBehaviour {

	GameObject target = null;
	public float distance = 50f;
	public float time = 2;
	public NavMeshAgent agent;

	bool canMove = false;

	private void Start()
	{
		target = GameObject.FindGameObjectWithTag("Player").gameObject;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			canMove = true;
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.1f / distance * Mathf.Sin(Time.time * time)
		 , this.transform.position.z);

		if (canMove)
		{
			agent.SetDestination(target.transform.position);
		}
	}
}
