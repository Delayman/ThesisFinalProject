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
        //enemmy.SetColor(Color.red);
        
        // MonsterAnimationEvent.Invoke(3);

        // var _distance = Vector3.Distance(target.position, agent.transform.position);
        //
        // if (_distance > 0.1f)
        // {
        //     agent.isStopped = false;
        //     agent.SetDestination(target.position);
        //     return NodeState.RUNNING;
        // }
        
        targetPlayer = EnemyAI.targetedPlayer;
        
        if (targetPlayer != null)
        {
            playerStatus = targetPlayer.GetComponent<PlayerStatus>();

            agent.isStopped = false;
            agent.SetDestination(targetPlayer.transform.position);
            return NodeState.RUNNING;
        }

        return NodeState.SUCCESS;
    }

    // private void ChasingTime()
    // {
    //     agent.isStopped = false;
    //     agent.SetDestination(target.position);
    //     Debug.Log($"Countdown before stop chase");
    //     agent.isStopped = true;
    // }

    //  MonsterEvent MonsterAnimationEvent = new MonsterEvent();
    // public void monsteranimationevent(UnityAction<int> listener)
    // {
    //     MonsterAnimationEvent.AddListener(listener);
    // }

    private void PlayAnimation()
    {
        MonsterAnimator.SetInteger("EMAnimationID",3);
    }
}
