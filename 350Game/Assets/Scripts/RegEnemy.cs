using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegEnemy : EnemyBase
{
    UnityEngine.AI.NavMeshAgent agent;
    public GameObject target;
    BuildingController bc = new BuildingController();
    public int damage = 1;

    void Start()
    {
        //Get initial target when spawned
        agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
        target = GetTarget(this.transform.position);
        agent.SetDestination(target.transform.position);
        
    }
    
    void Update()
    {
        Debug.Log(target);
        //Constantly check if target has been destroyed => if target had been destroyed => SetDestination(GetTarget())
        if (!target)
        {
            target = GetTarget(this.transform.position);
            agent.SetDestination(target.transform.position);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //bc.SetPair();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other)
        {
           
            //bc.HitBuilding(target, damage);
        }
    }
    


}
