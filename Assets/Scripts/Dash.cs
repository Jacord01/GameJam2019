using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.PostProcessing;
using UnityStandardAssets.Characters.FirstPerson;

public class Dash : MonoBehaviour {

	public Rigidbody rb;
	public float boost = 10.0f;
	bool boosting = false;

	public PostProcessingProfile ppProfile;

	void Start ()
	{
		ppProfile.chromaticAberration.enabled = false;
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate () 
	{
        if(!boosting && Input.GetKey(KeyCode.LeftShift) && GetComponent<RigidbodyFirstPersonController>().getjump())
        {
			ppProfile.chromaticAberration.enabled = true;


			rb.AddForce(rb.velocity.normalized * boost, ForceMode.Impulse);
        	boosting = true;
			Invoke("resetChromatic", 1f);
        	Invoke("ResetBoost", 2.0f);
        }
	}

	private void resetChromatic()
	{
		ppProfile.chromaticAberration.enabled = false;
	}

	private void ResetBoost ()
	{
		boosting = false;
	
	}
}
