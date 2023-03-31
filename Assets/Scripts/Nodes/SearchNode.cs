using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SearchNode : Node
{
    private NavMeshAgent agent;
    private EnemyAI enemy;

    private PlayerStatus playerStatus;
    
    private GameObject targetPlayer;
    private Animator MonsterAnimator;
    
    public SearchNode(NavMeshAgent _agent, EnemyAI _enemy, Animator _Animator)
    {
        this.agent = _agent;
        this.enemy = _enemy;
        this.MonsterAnimator = _Animator;
    }

    public override NodeState Evaluate()
    {
        targetPlayer = EnemyAI.targetedPlayer;

        playerStatus = targetPlayer.GetComponent<PlayerStatus>();

        if (playerStatus.isHidden)
        {
            EnemyAI.isDetectedPlayer = false; 
            PlayAnimation();
            agent.isStopped = true;

            EnemyAI.isSearchingPlayer = true;
            EnemyAI.isTriggerSearchTime = true;
        }

        return NodeState.RUNNING;

        // return EnemyAI.isSearchingPlayer ? NodeState.RUNNING : NodeState.SUCCESS;
    }

    private void PlayAnimation()
    {
        Debug.Log($"Search");
        MonsterAnimator.SetInteger("EMAnimationID",1);
    }
}
