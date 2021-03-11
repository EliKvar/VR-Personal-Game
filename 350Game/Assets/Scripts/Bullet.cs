using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float timeToLive = 3;
    float time;
   

    void Update()
    {
        time += Time.deltaTime;
        Debug.Log(time);
        if(time >= timeToLive)
        {
            Destroy(this);
        }
        
    }
}
