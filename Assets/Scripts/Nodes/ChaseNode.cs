using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.AI;
using Photon.Pun;

public class ChaseNode : Node
{
    private NavMeshAgent agent;
    private EnemyAI enemy;
    private float chaseTimer;
    private Animator MonsterAnimator;
    
    private GameObject targetPlayer;
    private PlayerHidingStatus playerHideStatus;
    
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

        // Debug.Log($"Target : {targetPlayer} name : {playerName}");

        if (targetPlayer != null)
        {
            Debug.Log($"Run u fuck");
            SetChaseToPlayer();
            
            return NodeState.SUCCESS;
        }

        return NodeState.SUCCESS;
    }

    public void SetChaseToPlayer()
    {
        agent.ResetPath();
        agent.isStopped = true;
        agent.speed = enemy.enemyRunSpeed;
        agent.angularSpeed = 450f;
        agent.SetDestination(targetPlayer.transform.position);
        agent.isStopped = false;
        PlayAnimation();
    }

    private void PlayAnimation()
    {
        MonsterAnimator.SetInteger("EMAnimationID",3);
    }
}
