using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.AI;

public class ChaseNode : Node
{
    private Transform target;
    private NavMeshAgent agent;
    private EnemyAI enemmy;
    private float chaseTimer;

    public ChaseNode(Transform _target, NavMeshAgent _agent, EnemyAI _enemy)
    {
        this.target = _target;
        this.agent = _agent;
        this.enemmy = _enemy;
        chaseTimer = 0f;
    }
    public override NodeState Evaluate()
    {
        enemmy.SetColor(Color.red);
        
        var _distance = Vector3.Distance(target.position, agent.transform.position);

        if (_distance > 0.1f)
        {
            agent.isStopped = false;
            agent.SetDestination(target.position);
            return NodeState.RUNNING;
        }
        else
        {
            chaseTimer -= Time.deltaTime;
            Debug.Log($"Timer : {chaseTimer}");
        }

        return chaseTimer <= 0 ? NodeState.SUCCESS : NodeState.FAILURE;
    }

    private void ChasingTime()
    {
        agent.isStopped = false;
        agent.SetDestination(target.position);
        Debug.Log($"Countdown before stop chase");
        agent.isStopped = true;
    }
}
