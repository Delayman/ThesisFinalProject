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
    private AudioSource foot;
    private AudioSource footrun;
    private AudioSource DangerMusic;
    private AudioSource Detected;

    public SearchNode(NavMeshAgent _agent, EnemyAI _enemy, Animator _Animator, AudioSource _foot, AudioSource _footrun, AudioSource _DangerMusic, AudioSource _Detected)
    {
        this.agent = _agent;
        this.enemy = _enemy;
        this.MonsterAnimator = _Animator;
        foot = _foot;
        footrun = _footrun;
        DangerMusic = _DangerMusic;
        Detected = _Detected;
    }

    public override NodeState Evaluate()
    {
        targetPlayer = EnemyAI.targetedPlayer;
        
        if (targetPlayer.TryGetComponent<PlayerStatus>(out var playerStatus))
        {
            if (playerStatus.isHidden)
            {
                EnemyAI.isDetectedPlayer = false; 
                PlayAnimation();
                agent.isStopped = true;

                EnemyAI.isSearchingPlayer = true;
                EnemyAI.isTriggerSearchTime = true;
            }
        }

        return NodeState.RUNNING;
    }

    private void PlayAnimation()
    {
        //Debug.Log($"Search");
        MonsterAnimator.SetInteger("EMAnimationID",1);
        //foot.enabled = false;
        //footrun.enabled = false;
        //DangerMusic.enabled = false;
        //Detected.Stop();
    }
}
