using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Photon.Pun;

public class DistractedNode : Node
{
    // private Transform distractTarget;
    private NavMeshAgent agent;
    private EnemyAI enemmy;
    // private bool isDistracted;
    // private bool isFinishedPath;
    private Animator MonsterAnimator;
    public DistractedNode(NavMeshAgent _agent, EnemyAI _enemy, Animator _animator, AudioSource _foot, AudioSource _footrun, AudioSource _DangerMusic, AudioSource _Detected)
    {
        agent = _agent;
        enemmy = _enemy;
        this.MonsterAnimator = _animator;
    }

    public override NodeState Evaluate()
    {
        // enemmy.StartDistracted();
        
        Debug.Log($"Lure");

        if (EnemyAI.isDistractedbyPlayer && !enemmy.isFinishedPath)
        {
            Debug.Log($"Get Lure to {EnemyAI.DistractPos.position}");
            CheckFinish();
        }

        return !enemmy.isFinishedPath ? NodeState.SUCCESS : NodeState.FAILURE;
    }

    private void CheckFinish()
    {
        PlayAnimation();

        agent.ResetPath();
        agent.isStopped = true;
            
        agent.SetDestination(EnemyAI.DistractPos.position);
        agent.isStopped = false;
        
        var _distance = Vector3.Distance(EnemyAI.DistractPos.position, agent.transform.position);

        if (!(_distance < 5f)) return;

        // enemmy.EndDistracted();
    }

    private void PlayAnimation()
    {
        MonsterAnimator.SetInteger("EMAnimationID",2);
    }
}
