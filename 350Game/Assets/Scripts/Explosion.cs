using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject FireExplosion;
    public GameObject Particles;
    GameObject particle;
    GameObject explosion;
    private bool isShrinking = false;
    void Start()
    {
    }

    void OnCollisionEnter(Collision coll)
    {
        
            Explode();
         
    }

    void Explode()
    {
        isShrinking = true;
         Instantiate(FireExplosion, gameObject.transform);
        Instantiate(Particles, gameObject.transform);
        //FireExplosion.transform.position = gameObject.transform.position;
        gameObject.GetComponent<Rigidbody>().detectCollisions = false;

       
        Destroy(gameObject, 2f);
        //Destroy(gameObject);
       // Debug.Log("transform: " + this.transform.position + " FireExplosion " + FireExplosion.transform.position);

    }

    void Update()
    {
        if(isShrinking == true)
        {
            gameObject.transform.localScale *= .99f;

        }

    }

}
