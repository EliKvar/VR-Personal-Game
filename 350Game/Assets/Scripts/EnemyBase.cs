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
    GameObject temp;

    //Use calling enemies position => determine all gameobjects with target => find and return closest vector3
    public virtual GameObject GetTarget(Vector3 enemy)
    {
        float minDist = Mathf.Infinity;
        
        targets = GameObject.FindGameObjectsWithTag("Target");
        foreach (GameObject t in targets)
        {
           float dist =  Vector3.Distance(t.transform.position, enemy);
            if(dist < minDist)
            {
                temp = t;
                minDist = dist;
            }

        }
        return temp;
    }
}
