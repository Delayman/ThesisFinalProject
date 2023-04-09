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
    private bool isDetected, isDistracted, isSearching;
    private Animator MonsterAnimator;
    private AudioSource foot;
    private AudioSource footrun;
    private AudioSource DangerMusic;
    private AudioSource Detected;

    public FindPathNode(List<GameObject> _path, NavMeshAgent _agent, EnemyAI _enemmy, Animator _animator,AudioSource _foot , AudioSource _footrun , AudioSource _DangerMusic ,AudioSource _Detected)
    {
        savedPath.AddRange(_path);
        tempPath.AddRange(_path);
        agent = _agent;
        enemmy = _enemmy;
        MonsterAnimator = _animator;
        foot = _foot;
        footrun = _footrun;
        DangerMusic = _DangerMusic;
        Detected = _Detected;
    }

    public override NodeState Evaluate()
    {
        isDetected = EnemyAI.isDetectedPlayer;
        isDistracted = EnemyAI.isDistractedbyPlayer;
        isSearching = EnemyAI.isSearchingPlayer;

        if (!isSearching)
        {
            FindPath();
            if (isDetected && !isSearching)
            {
                PlayAnimation(3);
                foot.enabled = false;
                footrun.enabled = true;
                DangerMusic.enabled = true;
                Detected.Play();
                return NodeState.FAILURE;
            }
            
            if(!isDetected)
            {
                PlayAnimation(2);
                foot.enabled = true;
                footrun.enabled = false;
                DangerMusic.enabled = false;
                Detected.Stop();
            }

            if (isSearching)
            {
                PlayAnimation(1); 
                foot.enabled = false;
                footrun.enabled = false;
                DangerMusic.enabled = false;
                Detected.Stop();
            }
        }
        
        return NodeState.SUCCESS;
    }
    
    private void FindPath()
    {
        var _distance = Vector3.Distance(tempPath[0].transform.position, agent.transform.position);
        agent.speed = 3.5f;
        agent.angularSpeed = 120f;
        // Debug.Log($"Distance left : {_distance}");
        
        if (tempPath.Count > 0)
        {
            // Debug.Log($"Set Path");
            agent.isStopped = false;
            agent.SetDestination(tempPath[0].transform.position);
        }

        if (_distance < 1.5f)
        {
            // Debug.Log($"Remove path");

            tempPath.Remove(tempPath[0]);
        }

        if (_distance < 1.5f && tempPath.Count == 1)
        {
            // Debug.Log($"Add path for loop");

            tempPath.AddRange(savedPath);
        }
    }

    private void PlayAnimation(int _value)
    {
        Debug.Log($"Find Path");
        MonsterAnimator.SetInteger("EMAnimationID",_value);
        
    }
}