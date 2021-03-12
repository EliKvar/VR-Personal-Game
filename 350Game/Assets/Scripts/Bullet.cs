using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float timeToLive = 3;
    float time = 0;
   

    void Update()
    {
        time += Time.deltaTime;
        if(time >= timeToLive)
        {
            Destroy(this.gameObject);
        }
        
    }
}
