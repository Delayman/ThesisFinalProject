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
    private AudioSource foot;
    private AudioSource footrun;
    private AudioSource DangerMusic;
    private AudioSource Detected;

    public ChaseNode(NavMeshAgent _agent, EnemyAI _enemy, Animator _animator, AudioSource _foot, AudioSource _footrun, AudioSource _DangerMusic, AudioSource _Detected)
    {
        this.agent = _agent;
        this.enemy = _enemy;
        chaseTimer = 0f;
        this.MonsterAnimator = _animator;
        foot = _foot;
        footrun = _footrun;
        DangerMusic = _DangerMusic;
        Detected = _Detected;
    }
    public override NodeState Evaluate()
    {
        targetPlayer = EnemyAI.targetedPlayer;
        
        if (targetPlayer != null)
        {
            playerStatus = targetPlayer.GetComponent<PlayerStatus>();

            agent.isStopped = false;
            agent.speed = 7.5f;
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
        //foot.enabled = false;
        //footrun.enabled = true;
        //DangerMusic.enabled = true;
        //Detected.Play();
    }
}
