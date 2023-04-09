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
    private AudioSource foot;
    private AudioSource footrun;
    private AudioSource DangerMusic;
    private AudioSource Detected;
    public DistractedMode(NavMeshAgent _agent, EnemyAI _enemy, Animator _animator, AudioSource _foot, AudioSource _footrun, AudioSource _DangerMusic, AudioSource _Detected)
    {
        agent = _agent;
        enemmy = _enemy;
        this.MonsterAnimator = _animator;
        foot = _foot;
        footrun = _footrun;
        DangerMusic = _DangerMusic;
        Detected = _Detected;
    }

    public override NodeState Evaluate()
    {
        isDistracted = EnemyAI.isDistractedbyPlayer;
        isFinishedPath = false;

        if (isDistracted && !isFinishedPath)
        {
            PlayAnimation();

            distractTarget = EnemyAI.DistractPos;
            agent.SetDestination(distractTarget.position);
            CheckFinish();
        }

        return !isFinishedPath ? NodeState.SUCCESS : NodeState.FAILURE;
    }

    private void CheckFinish()
    {
        var _distance = Vector3.Distance(distractTarget.position, agent.transform.position);
        
        if (_distance < 5f)
        {
            isFinishedPath = true;
            EnemyAI.isDistractedbyPlayer = false;
        }
    }

    private void PlayAnimation()
    {
        MonsterAnimator.SetInteger("EMAnimationID",2);
        //foot.enabled = true;
        //footrun.enabled = false;
        //DangerMusic.enabled = false;
        //Detected.Stop();
    }
}
