using UnityEngine;
using UnityEngine.Audio;

public class Gun : MonoBehaviour {

    public float damage = 10.0f;
    public float range = 100.0f;

    public Camera fpsCam;

	bool shooting = false;
    //public ParticleSystem muzzleFlash;
    //public GameObject impactEffect;
    //public AudioSource shootSFX;

    void Start()
    {
        //shootSFX = GetComponent<AudioSource>();
    }

     void Update()
    {

        if (Input.GetMouseButton(0))
        {
            Shoot();
			shooting = true;
        }

		else if (Input.GetMouseButtonUp(0))
		{
			shooting = false;
			stopShooting();
		}
	}

    void Shoot()
    {
        //Debug.Log("Shoot!");
        //muzzleFlash.Play();
        //shootSFX.Play();

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
			FindObjectOfType<ShootingAnimation>().shoot();
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
                //GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            }			
		}
    }

	void stopShooting()
	{
		FindObjectOfType<ShootingAnimation>().Noshoot();
	}
}
