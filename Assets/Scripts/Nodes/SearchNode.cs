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
        //Orange
        //enemy.SetColor(new Color(255, 162, 30, 1));
        PlayAnimation();
        
        targetPlayer = EnemyAI.targetedPlayer;

        playerStatus = targetPlayer.GetComponent<PlayerStatus>();

        if (playerStatus.isHidden)
        {
            EnemyAI.isDetectedPlayer = false; 
        }

        // return NodeState.SUCCESS;
        return !EnemyAI.isDetectedPlayer ? NodeState.FAILURE : NodeState.SUCCESS;
    }

    private void PlayAnimation()
    {
        MonsterAnimator.SetInteger("EMAnimationID",2);
    }
}
