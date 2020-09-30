using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;


public class Fence : MonoBehaviour
{
    /// <summary>
    /// When the enemy gets destroyed, the ontriggerexit function does not get called. When destroyed the enemy, move them out of the trigger to trigger ontriggerexit and then destroy them.
    /// </summary>
    int regCount;
    int tankCount;
    int health = 2000;
    bool isBeingHit = false;
    private float currentTime;
    private float timeInterval = 0.2f;
    private int regDMG = 50;
    private int tankDMG = 100;
    Animation anim;
    ParticleSystem ps;
    private void Start()
    {
        anim = gameObject.GetComponent<Animation>();
        ps = gameObject.GetComponentInChildren<ParticleSystem>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "RegEnemy")
        {
            ps.Play();
            regCount++;
        }
        else if (other.gameObject.tag == "TankEnemy")
        {
            ps.Play();
            tankCount++;
        }
        isBeingHit = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "RegEnemy")
        {
            regCount--;
        }
        else if (other.gameObject.tag == "TankEnemy")
        {
            tankCount--;
        }
    }
    
   
    private void Update()
    {
        if (regCount == 0 && tankCount == 0)
        {
            isBeingHit = false;
        }
           
        if (health <= 0)
        {
            anim.Play();
            Destroy(this.gameObject, anim.clip.length);

        }

        if (isBeingHit == true)
        {
            if (Time.time >= currentTime)
            {
                currentTime = Time.time + timeInterval;
                health -= regDMG * regCount;
                health -= tankDMG * tankCount;
                UnityEngine.Debug.Log("Health: " + health + " Enemies: " + regCount + " " + tankCount + "timeInterval " + currentTime);
            }
        }

    }
}
