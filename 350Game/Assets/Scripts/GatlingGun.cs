﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatlingGun : MonoBehaviour
{
    float coneSize = 4;
    float shootForce = 30000;
    public GameObject bulletPrefab;
    public GameObject firePoint;
    public GameObject fireEffect;
    public static GatlingGun instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    public void Fire()
    {
        var bullet = Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation);
        Instantiate(fireEffect, firePoint.transform.position, firePoint.transform.rotation);
        float width = Random.Range(-1f, 1f) * coneSize;
        float height = Random.Range(-1f, 1f) * coneSize;

        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * shootForce + transform.right * width + transform.up * height);
    }
    
}
