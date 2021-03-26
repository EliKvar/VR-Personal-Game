using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegEnemy : EnemyBase
{
    UnityEngine.AI.NavMeshAgent agent;
    public GameObject target;
    private int health = 500;
    public GameObject bloodSplatter;

    void Start()
    {
        //Get initial target when spawned
        agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
        target = GetTarget(this.transform.position);
        agent.SetDestination(target.transform.position);
        
    }
    
    void Update()
    {
        //Debug.Log(target);
        //Constantly check if target has been destroyed => if target had been destroyed => SetDestination(GetTarget())
        if (!target)
        {
            target = GetTarget(this.transform.position);
            agent.SetDestination(target.transform.position);
        }
        if(health <= 0)
        {
            GameManager.Instance.AddKill();
            Destroy(this.gameObject);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            Instantiate(bloodSplatter, other.transform.position, other.transform.rotation);
            //Debug.Log(this.gameObject.name + "got hit.");
            health -= 50;
        }
    }

}
