using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FindPathNode : Node
{
    private readonly List<GameObject> savedPath = new List<GameObject>();
    private readonly List<GameObject> tempPath= new List<GameObject>();
    private NavMeshAgent agent;
    private EnemyAI enemmy;
    private bool isDetected;

    public FindPathNode(List<GameObject> _path, NavMeshAgent _agent, EnemyAI _enemmy)
    {
        savedPath.AddRange(_path);
        tempPath.AddRange(_path);
        agent = _agent;
        enemmy = _enemmy;
    }

    public override NodeState Evaluate()
    {
        FindPath();
        isDetected = EnemyAI.isDetectedPlayer;
        
        return !isDetected ? NodeState.SUCCESS : NodeState.FAILURE;
    }
    
    private void FindPath()
    {
        enemmy.SetColor(Color.yellow);
        var _distance = Vector3.Distance(tempPath[0].transform.position, agent.transform.position);
        
        if (tempPath.Count > 0)
        {
            agent.SetDestination(tempPath[0].transform.position);
        }

        if (_distance < 0.5f)
        {
            tempPath.Remove(tempPath[0]);
        }

        if (_distance < 1f && tempPath.Count == 1)
        {
            tempPath.AddRange(savedPath);
        }
        
    }
}