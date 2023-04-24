using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField]
    Transform firePoint;

    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    float bulletLifeTime = 5.0F;

    [SerializeField]
    float fireTimesPerSecond = 3.0F;

    Animator animator;

    float currentTime = 0.0F;

    float nextFireTime = 0.0F;

    public AudioClip sonido1;

    public AudioSource AudioSource;


    void Awake()
    {
        animator = GetComponent<Animator>();
        AudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if (Input.GetButton("Fire1"))
        {
            if (currentTime > nextFireTime)
            {
                currentTime = 0.0F;
                nextFireTime = Time.deltaTime + (1.0F / fireTimesPerSecond);

                animator.SetTrigger("fire");
                AudioSource.PlayOneShot(sonido1, 0.35F);
            }
        }
    }

    public void OnFire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, transform.rotation);

        Destroy(bullet, bulletLifeTime);
    }
}
