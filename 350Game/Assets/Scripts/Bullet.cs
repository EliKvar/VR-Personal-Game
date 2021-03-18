using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float timeToLive = 3;
    float time = 0;
    public GameObject impactEffect;
   

    void Update()
    {
        time += Time.deltaTime;
        if(time >= timeToLive)
        {
            Destroy(this.gameObject);
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.gameObject.name);
        //Instantiate(impactEffect, collision.gameObject.transform);
    }
}
