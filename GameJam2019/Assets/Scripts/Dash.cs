using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour {

	public Rigidbody rb;
	public float boost = 10.0f;
	bool boosting = false;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate () 
	{
        if(!boosting && Input.GetKey(KeyCode.LeftShift))
        {
        	Debug.Log("Dashing!");
        	rb.AddForce(rb.velocity.normalized * boost, ForceMode.Impulse);
        	boosting = true;
        	Invoke("ResetBoost", 2.0f);
        }
		
	}

	private void ResetBoost ()
	{
		boosting = false;
	}
}
