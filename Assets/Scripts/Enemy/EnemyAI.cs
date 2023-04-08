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
    
    // [SerializeField] private float chasingRange = 3f;

    // [SerializeField] private Transform playerTransform;
    public float searchingTime = 10f;

    private Material material;
    private NavMeshAgent agent;

    private Node topNode;
    private SphereCollider sphereCollider;
    
    public static bool isDetectedPlayer;
    public static bool isSearchingPlayer;
    public static bool isDistractedbyPlayer;
    public static bool isTriggerSearchTime = true;
    
    public static Transform DistractPos;
    public static GameObject targetedPlayer;

    private Animator _animator;

    public AudioSource foot;
    public AudioSource footrun;
    public AudioSource DangerMusic;
    public AudioSource Detected;
    
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
        var _chaseNode = new ChaseNode(agent, this, _animator, foot, footrun, DangerMusic, Detected);
        var _findPathNode = new FindPathNode(pratolPaths, agent, this, _animator , foot , footrun , DangerMusic , Detected);
        var _distractedMode = new DistractedMode(agent, this, _animator, foot, footrun, DangerMusic, Detected);
        var _searchNode = new SearchNode(agent, this, _animator, foot, footrun, DangerMusic, Detected);

        var _chaseSequnce = new Sequnce(new List<Node> {_chaseNode, _searchNode});
        var _pratol = new Sequnce(new List<Node> {_findPathNode, _distractedMode});

        topNode = new Selector(new List<Node> {_pratol, _chaseSequnce});
    }

    private void Update()
    {
        topNode.Evaluate();
        if (topNode.NodeState == NodeState.FAILURE)
        {
            agent.isStopped = true;
        }

        if (isSearchingPlayer && isTriggerSearchTime)
        {
            TriggerSearchTimer();
            isTriggerSearchTime = false;
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
        if (other.CompareTag("Player"))
        {
            isDetectedPlayer = true;
            targetedPlayer = other.gameObject;
            // Debug.Log($"player : {targetedPlayer.name}");

            StopCoroutine(StopChaseTimer());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(StopChaseTimer());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            PhotonNetwork.LoadLevel("Scenes/Result");
        }
        
    }

    private void TriggerSearchTimer()
    {
        StartCoroutine(SearchTimer());
    }

    private IEnumerator StopChaseTimer()
    {
        yield return new WaitForSeconds(10f);
        isDetectedPlayer = false;
    }
    
    private IEnumerator SearchTimer()
    {
        Debug.Log($"Trigger Timer");

        yield return new WaitForSeconds(searchingTime);
        isSearchingPlayer = false;
    }
}
