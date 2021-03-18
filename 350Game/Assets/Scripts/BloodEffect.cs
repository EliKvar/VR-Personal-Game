using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodEffect : MonoBehaviour
{
    float timeToLive = 2.18f;
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
