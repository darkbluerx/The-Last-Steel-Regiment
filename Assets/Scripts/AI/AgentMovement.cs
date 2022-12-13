using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))] //kiinnitt‰‰ t‰h‰n navmeshagentin eli t‰m‰ on valmiina inspectorissa

public class AgentMovement : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform target;
    //Vector3 target;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;     
    }

    void Update()
    {
        agent.SetDestination(target.position);

       //SetTargetosition();
       //SetAgentPosition();
    }

    //void SetTargetosition()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    }
    //}

    //void SetAgentPosition()
    //{
    //    agent.SetDestination(new Vector3 (target.x, target.y, transform.position.z));
    //}
}
