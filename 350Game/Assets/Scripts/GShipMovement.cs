using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GShipMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Base;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(Base.transform.position, Vector3.up, 10 * Time.deltaTime);
    }
}
