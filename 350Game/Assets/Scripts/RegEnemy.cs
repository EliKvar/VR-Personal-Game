using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegEnemy : EnemyBase
{
    UnityEngine.AI.NavMeshAgent agent;
    GameObject target;
    BuildingController bc;
    private int damage = 20;

    void Start()
    {
        //Get initial target when spawned
        agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
        target = GetTarget(this.transform.position);
        agent.SetDestination(target.transform.position);
        
    }
    
    void Update()
    {
        //bc.HitBuilding(target, damage);
        //Constantly check if target has been destroyed => if target had been destroyed => SetDestination(GetTarget())
        if (!target)
        {
            target = GetTarget(this.transform.position);
            agent.SetDestination(target.transform.position);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //HERE
        bc.HitBuilding()

    }

}
