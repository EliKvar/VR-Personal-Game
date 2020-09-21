using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegEnemy : EnemyBase
{
    UnityEngine.AI.NavMeshAgent agent;
    


    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.SetDestination(GetTarget(this.transform.position));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
