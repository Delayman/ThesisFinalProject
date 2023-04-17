using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using System.Linq;
using Photon.Pun;

public class CutScenePlay : MonoBehaviour
{
    [SerializeField] private EnemyAI enemyPrefab;
    [SerializeField] private GameObject spawnPos;
    
    public PlayableDirector cutseen1;
    public PlayableDirector cutseen2;
    public PlayableDirector cutseen3;
    public PlayableDirector cutseen4;

    public static int PassPuzzle;
    private List<DisablePlayerControl> DisAblePlayerlist;

    void Start()
    {
        DisAblePlayerlist = FindObjectsOfType<DisablePlayerControl>().ToList();
        PassPuzzle = 0;
    }

    public void CutScene1()
    {
        foreach (var player in DisAblePlayerlist)
        {
            player.isDisableControlAndCam = true;
            player.isDisableUI = true;
            player.isDisableInteraction = true;
        }
        cutseen1.Play();
        // cutseen1.stopped += SpawnEnemy;
    }

    // private void SpawnEnemy(PlayableDirector aDirector)
    // {
    //     if (cutseen1 == aDirector)
    //     {
    //         PhotonNetwork.Instantiate(enemyPrefab.name, spawnPos.transform.position, Quaternion.identity);
    //     }
    // }

    public void CutScene2()
    {
        // Debug.Log("PassPuzzle = "+PassPuzzle);
        if (PassPuzzle == 5)
        {
            foreach (var player in DisAblePlayerlist)
            {
                player.isDisableControlAndCam = true;
                player.isDisableUI = true;
                player.isDisableInteraction = true;
            }
            cutseen2.Play();
        }
        
    }
    public void CutScene3()
    {
        foreach (var player in DisAblePlayerlist)
        {
            player.isDisableControlAndCam = true;
            player.isDisableUI = true;
            player.isDisableInteraction = true;
        }
        cutseen3.Play();
    }
    
    public void CutScene4()
    {
        foreach (var player in DisAblePlayerlist)
        {
            player.isDisableControlAndCam = true;
            player.isDisableUI = true;
            player.isDisableInteraction = true;
        }
        cutseen4.Play();
    }
    
    // private void OnDisable()
    // {
    //     cutseen1.stopped -= SpawnEnemy;
    // }
    //
    // private void OnDestroy()
    // {
    //     cutseen1.stopped -= SpawnEnemy;
    // }
}
