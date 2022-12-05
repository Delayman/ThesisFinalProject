using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class ChaseNode : Node
{
    private Transform target;
    private NavMeshAgent agent;
    private EnemyAI enemmy;
    private float chaseTimer;
    private Animator MonsterAnimator;

    public ChaseNode(Transform _target, NavMeshAgent _agent, EnemyAI _enemy, Animator _animator)
    {
        this.target = _target;
        this.agent = _agent;
        this.enemmy = _enemy;
        chaseTimer = 0f;
        this.MonsterAnimator = _animator;
    }
    public override NodeState Evaluate()
    {
        //enemmy.SetColor(Color.red);
        
        // MonsterAnimationEvent.Invoke(3);

        var _distance = Vector3.Distance(target.position, agent.transform.position);

        if (_distance > 0.1f)
        {
            agent.isStopped = false;
            agent.SetDestination(target.position);
            return NodeState.RUNNING;
        }

        return chaseTimer <= 0 ? NodeState.SUCCESS : NodeState.FAILURE;
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
