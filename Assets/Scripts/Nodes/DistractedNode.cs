using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DistractedMode : Node
{
    private Transform distractTarget;
    private NavMeshAgent agent;
    private EnemyAI enemmy;
    private bool isDistracted;
    private bool isFinishedPath;
    
    public DistractedMode(NavMeshAgent _agent, EnemyAI _enemy)
    {
        agent = _agent;
        enemmy = _enemy;
    }

    public override NodeState Evaluate()
    {
        isDistracted = EnemyAI.isDistractedbyPlayer;
        isFinishedPath = false;

        if (isDistracted && !isFinishedPath)
        {
            distractTarget = EnemyAI.DistractPos;
            agent.SetDestination(distractTarget.position);
            CheckFinish();
        }
        
        Debug.Log($"Distracted Log : {isDistracted} && {!isFinishedPath}");
        return !isFinishedPath ? NodeState.SUCCESS : NodeState.FAILURE;
    }

    private void CheckFinish()
    {
        var _distance = Vector3.Distance(distractTarget.position, agent.transform.position);
        enemmy.SetColor(Color.yellow);
        
        Debug.Log($"{_distance}");
        
        if (_distance < 5f)
        {
            isFinishedPath = true;
            EnemyAI.isDistractedbyPlayer = false;
        }
    }
}
