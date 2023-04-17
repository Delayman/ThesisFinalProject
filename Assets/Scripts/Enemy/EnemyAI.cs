using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Photon.Pun;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class EnemyAI : MonoBehaviour
{
    #region Enemy Setting Variable
    
    [FormerlySerializedAs("_pratolPaths")] [SerializeField] private List<GameObject> pratolPaths = new List<GameObject>();
    
    public float huntTime = 15f;
    public float enemyRunSpeed = 7f;
    public float enemyWalkSpeed = 3.5f;
    
    // public float searchingTime = 10f;

    private Material material;
    private NavMeshAgent agent;

    private Node topNode;
    private SphereCollider sphereCollider;
    
    public static bool isDetectedPlayer;
    public static bool isSearchingPlayer;
    public static bool isDistractedbyPlayer;
    public bool isTriggerChaseTimer;
    public bool isFinishedPath;

    public static bool isSetToStopEverything;
    
    public static Transform DistractPos;
    public static GameObject targetedPlayer;

    private Animator _animator;

    public AudioSource foot;
    public AudioSource footrun;
    public AudioSource DangerMusic;
    public AudioSource Detected;

    public GameObject playerNeedToRPC;
    
    #endregion
    
    private void Awake()
    {
        //material = GetComponentInChildren<MeshRenderer>().material;
        pratolPaths = GameObject.FindGameObjectsWithTag("EnemyPath").ToList();
        
        if(!TryGetComponent<NavMeshAgent>(out var _agent)) return;
        if(!TryGetComponent<SphereCollider>(out var _sphere)) return;

        _animator = GetComponentInChildren<Animator>();
        
        agent = _agent;
        sphereCollider = _sphere;
        isDetectedPlayer = false;
    }

    private void Start()
    {
        ConstructBehaviourTree();
    }

    private void ConstructBehaviourTree()
    {
        var _chaseNode = new ChaseNode(agent, this, _animator);
        var _findPathNode = new FindPathNode(pratolPaths, agent, this, _animator , foot , footrun , DangerMusic , Detected);
        // var _distractedMode = new DistractedNode(agent, this, _animator, foot, footrun, DangerMusic, Detected);
        // var _searchNode = new SearchNode(agent, this, _animator, foot, footrun, DangerMusic, Detected);

        var _chaseSequnce = new Sequnce(new List<Node> {_chaseNode});
        var _pratol = new Sequnce(new List<Node> {_findPathNode});

        topNode = new Selector(new List<Node> {_pratol, _chaseSequnce});
    }

    private void Update()
    {
        topNode.Evaluate();

        // if (DistractPos != null)
        // {
        //     Debug.Log($"Dis pos : {DistractPos.position}");
        // }
        
        if (topNode.NodeState == NodeState.FAILURE)
        {
            agent.isStopped = true;
        }
    }
    
    private void OnDrawGizmosSelected()
    {
        var _transformPos = transform.position;
        
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_transformPos, 3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        playerNeedToRPC = other.gameObject;
        
        var PV = GetComponent<PhotonView>();
        PV.RPC("StartChase", RpcTarget.All);

        // var playerStatus = targetedPlayer.GetComponent<PlayerStatus>();
        // var playerHideStatus = FindObjectOfType<PlayerHidingStatus>();
        
        // if (playerStatus.PlayerName.Contains("3") && !playerHideStatus.isPlayerBHiding)
        // {
        //     isDetectedPlayer = true;
        //     Debug.Log($"Currently hunt + {targetedPlayer.GetComponent<PlayerStatus>().PlayerName} + {isDetectedPlayer}");
        // }
    }
    
    [PunRPC]
    public void StartChase()
    {
        targetedPlayer = playerNeedToRPC;
        
        isDetectedPlayer = true;
        
        // Debug.Log($"Currently hunt + {targetedPlayer.GetComponent<PlayerStatus>().PlayerName} + {isDetectedPlayer}");
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var PV = GetComponent<PhotonView>();
            PV.RPC("StoppingChase", RpcTarget.All);
        }
    }

    [PunRPC]
    public void StoppingChase()
    {
        if (isTriggerChaseTimer) return;
        
        isTriggerChaseTimer = true;
        StartCoroutine(StopChaseTimer());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            var PV = GetComponent<PhotonView>();
            PV.RPC("GameOver", RpcTarget.All); 
        }
    }
    
    [PunRPC]
    private void GameOver()
    {
        PhotonNetwork.LoadLevel("Scenes/Result");
    }
    
    private IEnumerator StopChaseTimer()
    {
        yield return new WaitForSeconds(huntTime);
        isDetectedPlayer = false;
        isTriggerChaseTimer = false;
    }
    
    public void StartDistracted()
    {
        var PV = GetComponent<PhotonView>();
        PV.RPC("StartDistractedRPC", RpcTarget.All); 
    }
    
    [PunRPC]
    public void StartDistractedRPC()
    {
        isFinishedPath = false;
    }
    
    public void EndDistracted()
    {
        var PV = GetComponent<PhotonView>();
        PV.RPC("EndDistractedRPC", RpcTarget.All); 
    }
    
    [PunRPC]
    public void EndDistractedRPC()
    {
        isFinishedPath = true;
        isDistractedbyPlayer = false;
    }

    // public void StopEverything()
    // {
    //     var PV = GetComponent<PhotonView>();
    //     PV.RPC("StopDetectedPlayer", RpcTarget.All); 
    // }

    // public void SearchRpc()
    // {
    //     var PV = GetComponent<PhotonView>();
    //     PV.RPC("StartSearchPlayer", RpcTarget.All); 
    // }
    
    // [PunRPC]
    // public void StopDetectedPlayer()
    // {
    //     isDetectedPlayer = false;
    //     agent.isStopped = true;
    // }
    
    // [PunRPC]
    // public void StartSearchPlayer()
    // {
    //     isSearchingPlayer = true;
    //     isTriggerSearchTime = true;
    // }

    // private void TriggerSearchTimer()
    // {
    //     var PV = GetComponent<PhotonView>();
    //     PV.RPC("CalledSearchRPC", RpcTarget.All);
    // }
    
    // [PunRPC]
    // public void CalledSearchRPC()
    // {
    //     StartCoroutine(SearchTimer());
    // }
    
    
    // private IEnumerator SearchTimer()
    // {
    //     yield return new WaitForSeconds(searchingTime);
    //     isSearchingPlayer = false;
    //     isTriggerSearchTime = false;
    // }
}
