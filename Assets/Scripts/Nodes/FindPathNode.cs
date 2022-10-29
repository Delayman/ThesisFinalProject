using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FindPathNode : Node
{
    private List<GameObject> path;
    private NavMeshAgent agent;
    private EnemyAI enemmy;
    private bool isDetected;

    public FindPathNode(List<GameObject> _path, NavMeshAgent _agent, EnemyAI _enemmy)
    {
        path = _path;
        agent = _agent;
        enemmy = _enemmy;
    }

    public override NodeState Evaluate()
    {
        FindPath();
        isDetected = EnemyAI.isDetectedPlayer;
        return !isDetected ? NodeState.SUCCESS : NodeState.FAILURE;
    }
    
    private Transform FindPath()
    {
        enemmy.SetColor(Color.yellow);
        Transform _destination = null;

        if (path[0] == null) return _destination;
        
        if (path[0].transform != null)
        {
            return path[0].transform;
        }
        
        // foreach (var _waypoint in path)
        // {
        //     return _waypoint;
        // }


        return _destination;
    }
}
