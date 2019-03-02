using UnityEngine;
using UnityEngine.Audio;

public class Gun : MonoBehaviour {

    public float damage = 10.0f;
    public float range = 100.0f;
    public Camera fpsCam;
    public GameObject impactEffect;
    //public AudioSource shootSFX;
    public float fireRate = 0.1f;
    private float nextFire;

    void Start()
    {
        //shootSFX = GetComponent<AudioSource>();
    }

     void Update()
    {
        if (Input.GetMouseButton(0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Shoot();
        }

        if (Input.GetMouseButtonUp(0))
        {
            stopShooting();
        }
	}

    void Shoot()
    {
        //shootSFX.Play();

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
			FindObjectOfType<ShootingAnimation>().shoot();
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            GameObject impact = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impact, 2.0f);
        }
    }

	void stopShooting()
	{
		FindObjectOfType<ShootingAnimation>().Noshoot();
	}
}
