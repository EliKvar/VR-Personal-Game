using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("SetBoxCollidersActive");
        if (collision.gameObject.tag == "Meteor")
        {


            var collidersObj = gameObject.GetComponentsInChildren<Collider>();
            for (var index = 0; index < collidersObj.Length; index++)
            {
                var colliderItem = collidersObj[index];
                colliderItem.enabled = false;
            }
        }
        //TEST IF OBJECT PASSES THROUGH ANOTHER, CHANGE ALL CHILDREN COLLIDERS TO TRUE, maybe needs a rigidbody?

    }
}
