using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    [SerializeField] private float bulletHoleDespawnTime;
    [SerializeField] private GameObject bulletHolePrefab;

    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public float impactForce = 30f;


    public Camera fpsCam;
    public ParticleSystem muzzleFlash;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }




    void Shoot()
    {

        //muzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name + ("has been hit!"));
            ///! = is not
            EnemyBehaviour target = hit.transform.GetComponent<EnemyBehaviour>();
            if (target != null)
            {
                target.ChangeHealth(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
        }
    }

    private void BulletHole(RaycastHit hit)
    {
        GameObject bulletHole = Instantiate(bulletHolePrefab, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(bulletHole, bulletHoleDespawnTime);
    }


}