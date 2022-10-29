using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class EnemyAI : MonoBehaviour
{
    #region Enemy Setting Variable
    
    [FormerlySerializedAs("_pratolPaths")] [SerializeField] private List<GameObject> pratolPaths = new List<GameObject>();
    
    [SerializeField] private float chasingRange = 3f;

    [SerializeField] private Transform playerTransform;

    private Material material;
    private NavMeshAgent agent;

    private Node topNode;
    private SphereCollider sphereCollider;
    public static bool isDetectedPlayer;

    #endregion
    
    private void Awake()
    {
        material = GetComponentInChildren<MeshRenderer>().material;
        pratolPaths = GameObject.FindGameObjectsWithTag("EnemyPath").ToList();
        
        if(!TryGetComponent<NavMeshAgent>(out var _agent)) return;
        if(!TryGetComponent<SphereCollider>(out var _sphere)) return;
        
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
        var _chaseNode = new ChaseNode(playerTransform, agent, this);
        var _findPathNode = new FindPathNode(pratolPaths, agent, this);

        var _chaseSequnce = new Sequnce(new List<Node> { _chaseNode });
        var _pratol = new Sequnce(new List<Node> { _findPathNode });

        topNode = new Selector(new List<Node> {_pratol, _chaseSequnce });
    }

    private void Update()
    {
        topNode.Evaluate();
        if (topNode.NodeState == NodeState.FAILURE)
        {
            SetColor(Color.cyan);
            agent.isStopped = true;
        }
        
    }

    public void SetColor(Color _color)
    {
        material.color = _color;
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

    private IEnumerator StopChaseTimer()
    {
        yield return new WaitForSeconds(10f);
        isDetectedPlayer = false;
    }
}
