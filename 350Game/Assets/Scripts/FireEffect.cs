using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEffect : MonoBehaviour
{
    float timeToLive = .5f;
    float time = 0;

    void Update()
    {
        time += Time.deltaTime;
        if (time >= timeToLive)
        {
            Destroy(this.gameObject);
        }

    }
}
