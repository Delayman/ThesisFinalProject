using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class ChaseNode : Node
{
    private NavMeshAgent agent;
    private EnemyAI enemy;
    private float chaseTimer;
    private Animator MonsterAnimator;
    
    private GameObject targetPlayer;
    private PlayerStatus playerStatus;

    public ChaseNode(NavMeshAgent _agent, EnemyAI _enemy, Animator _animator)
    {
        this.agent = _agent;
        this.enemy = _enemy;
        chaseTimer = 0f;
        this.MonsterAnimator = _animator;
    }
    public override NodeState Evaluate()
    {
        targetPlayer = EnemyAI.targetedPlayer;
        
        if (targetPlayer != null)
        {
            playerStatus = targetPlayer.GetComponent<PlayerStatus>();

            agent.isStopped = false;
            agent.speed = 10f;
            agent.angularSpeed = 180f;
            agent.SetDestination(targetPlayer.transform.position);
            PlayAnimation();
            return NodeState.RUNNING;
        }

        return NodeState.SUCCESS;
    }

    private void PlayAnimation()
    {
        MonsterAnimator.SetInteger("EMAnimationID",3);
    }
}
