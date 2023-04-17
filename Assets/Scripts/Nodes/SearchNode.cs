using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Photon.Pun;

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
        // Debug.Log($"target in search + {targetPlayer.GetComponent<PlayerStatus>().PlayerName}");

        if (targetPlayer.TryGetComponent<PlayerStatus>(out var playerStatus))
        {
            if (playerStatus.PlayerName.Contains("2") && EnemyAI.isDetectedPlayer)
            {
                if (GameObject.FindObjectOfType<PlayerHidingStatus>().isPlayerAHiding)
                {
                    Debug.Log($"Hide Player A");
                    // enemy.StopEverything();
                    // enemy.SearchRpc();
                    PlayAnimation();
                    
                    return NodeState.RUNNING;
                }
                return NodeState.FAILURE;
            }
            
            if (playerStatus.PlayerName.Contains("3") && EnemyAI.isDetectedPlayer)
            {
                if (GameObject.FindObjectOfType<PlayerHidingStatus>().isPlayerBHiding)
                {
                    Debug.Log($"Hide Player B");
                    // enemy.StopEverything();
                    // enemy.SearchRpc();
                    PlayAnimation();
                    
                    return NodeState.RUNNING;
                }
                return NodeState.FAILURE;
            }
        }

        return NodeState.RUNNING;
    }

    [PunRPC]
    public void HideRunnerA()
    {
        
    }
    
    private void PlayAnimation()
    {
        MonsterAnimator.SetInteger("EMAnimationID",1);
    }
}
