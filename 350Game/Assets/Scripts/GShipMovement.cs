using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GShipMovement : MonoBehaviour
{
    public GameObject Base;
    void Start()
    {
        
    }

    void Update()
    {
        transform.RotateAround(Base.transform.position, Vector3.up, 2f * Time.deltaTime);
    }
}
