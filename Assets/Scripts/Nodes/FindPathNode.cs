using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Photon.Pun;

public class FindPathNode : Node
{
    private readonly List<GameObject> savedPath = new List<GameObject>();
    private readonly List<GameObject> tempPath= new List<GameObject>();
    private NavMeshAgent agent;
    private EnemyAI enemy;
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
        enemy = _enemmy;
        MonsterAnimator = _animator;
        foot = _foot;
        footrun = _footrun;
        DangerMusic = _DangerMusic;
        Detected = _Detected;
    }

    public override NodeState Evaluate()
    {
        // isDetected = EnemyAI.isDetectedPlayer;

        // if (isDetected)
        // {
        //     PlayAnimation(3);
        //     
        //     foot.enabled = false;
        //     footrun.enabled = true;
        //     DangerMusic.enabled = true;
        //     Detected.Play();
        //     
        //     return NodeState.FAILURE;
        // }

        FindPath();
        
        foot.enabled = true;
        footrun.enabled = false;
        DangerMusic.enabled = false;
        Detected.Stop();
        
        return NodeState.SUCCESS;
    }

    public void FindPath()
    {
        // PlayAnimation(2);

        // Debug.Log($"Find Path");
        
        var _distance = Vector3.Distance(tempPath[0].transform.position, agent.transform.position);
        agent.speed = enemy.enemyWalkSpeed;
        agent.angularSpeed = 180f;
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
        MonsterAnimator.SetInteger("EMAnimationID",_value);
    }
}