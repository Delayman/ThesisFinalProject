using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class DistractedMode : Node
{
    private Transform distractTarget;
    private NavMeshAgent agent;
    private EnemyAI enemmy;
    private bool isDistracted;
    private bool isFinishedPath;
    private Animator MonsterAnimator;
    
    public DistractedMode(NavMeshAgent _agent, EnemyAI _enemy, Animator _animator)
    {
        agent = _agent;
        enemmy = _enemy;
        this.MonsterAnimator = _animator;
    }

    public override NodeState Evaluate()
    {

        isDistracted = EnemyAI.isDistractedbyPlayer;
        isFinishedPath = false;

        if (isDistracted && !isFinishedPath)
        {
            distractTarget = EnemyAI.DistractPos;
            agent.SetDestination(distractTarget.position);
            CheckFinish();
        }

        PlayAnimation();
        
        return !isFinishedPath ? NodeState.SUCCESS : NodeState.FAILURE;
    }

    private void CheckFinish()
    {
        var _distance = Vector3.Distance(distractTarget.position, agent.transform.position);
        //enemmy.SetColor(Color.yellow);
        
        if (_distance < 5f)
        {
            isFinishedPath = true;
            EnemyAI.isDistractedbyPlayer = false;
        }
    }

    private void PlayAnimation()
    {
        MonsterAnimator.SetInteger("EMAnimationID",2);
    }

    // MonsterEvent MonsterAnimationEvent = new MonsterEvent();
    // public void monsteranimationevent(UnityAction<int> listener)
    // {
    //     MonsterAnimationEvent.AddListener(listener);
    // }
}
