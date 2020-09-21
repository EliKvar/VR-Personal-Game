using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    REGULAR, TANK
}
public class EnemyBase : MonoBehaviour
{
    //public float 
    public float maxSpeed;
    GameObject[] targets;
    

    //do stuff with fields
    void Start()
    {
    }

    void FixedUpdate()
    {
       
    }
    public virtual void SetTarget()
    {

    }

    public virtual Vector3 GetTarget(Vector3 enemy)
    {
        float minDist = Mathf.Infinity;
        Vector3 temp = new Vector3();
        targets = GameObject.FindGameObjectsWithTag("Target");
        foreach (GameObject t in targets)
        {
           float dist =  Vector3.Distance(t.transform.position, enemy);
            if(dist < minDist)
            {
                temp = t.transform.position;
                minDist = dist;
            }

        }
        return temp;

    }

    

 
   

}
