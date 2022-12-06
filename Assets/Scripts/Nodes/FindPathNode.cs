using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class FindPathNode : Node
{
    private readonly List<GameObject> savedPath = new List<GameObject>();
    private readonly List<GameObject> tempPath= new List<GameObject>();
    private NavMeshAgent agent;
    private EnemyAI enemmy;
    private bool isDetected, isDistracted;

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
        isDistracted = EnemyAI.isDistractedbyPlayer;
        
        MonsterAnimationEvent.Invoke(2);

        // Debug.Log($"Log : {isDistracted}");

        if (isDetected)
        {
            return NodeState.FAILURE;
        }
        
        return NodeState.SUCCESS;
    }
    
    private void FindPath()
    {
        // enemmy.SetColor(Color.green);
        var _distance = Vector3.Distance(tempPath[0].transform.position, agent.transform.position);
        
        if (tempPath.Count > 0)
        {
            Debug.Log($"Set Path");
            agent.isStopped = false;
            agent.SetDestination(tempPath[0].transform.position);
        }

        if (_distance < 0.8f)
        {
            Debug.Log($"Remove path");

            tempPath.Remove(tempPath[0]);
        }

        if (_distance < 1f && tempPath.Count == 1)
        {
            Debug.Log($"Add path for loop");

            tempPath.AddRange(savedPath);
        }
        
    }
    MonsterEvent MonsterAnimationEvent = new MonsterEvent();
    public void monsteranimationevent(UnityAction<int> listener)
    {
        MonsterAnimationEvent.AddListener(listener);
    }
}