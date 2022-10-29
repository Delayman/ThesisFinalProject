using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyPathFinding : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    [SerializeField] private GameObject[] _pratolPaths;
        
    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _pratolPaths = GameObject.FindGameObjectsWithTag("EnemyPath");
        StartCoroutine(LocatePath());
    }

    private IEnumerator LocatePath()
    {
        var _randomNum = Random.Range(0, 3);
        
        yield return new WaitForSeconds(1f);
        _navMeshAgent.SetDestination(_pratolPaths[_randomNum].transform.position);
        
        yield return new WaitForSeconds(1f);
        if (_navMeshAgent.remainingDistance == 0)
        {
            Debug.Log($"Done!");
            StartCoroutine(LocatePath());
        }
        else
        {
            yield return new WaitForSeconds(10f);
            StartCoroutine(LocatePath());
        }
    }
}
