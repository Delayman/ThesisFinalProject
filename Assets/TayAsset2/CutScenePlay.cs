using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using System.Linq;

public class CutScenePlay : MonoBehaviour
{
    public PlayableDirector cutseen1;
    public PlayableDirector cutseen2;
    public PlayableDirector cutseen3;
    public PlayableDirector cutseen4;

    public static int PassPuzzle;
    private List<DisablePlayerControl> DisAblePlayerlist;
    // Start is called before the first frame update
    void Start()
    {
        DisAblePlayerlist = FindObjectsOfType<DisablePlayerControl>().ToList();
        PassPuzzle = 0;
    }

    public void CutScene1()
    {
        foreach (var player in DisAblePlayerlist)
        {
            player.isDisable = true;
        }
        cutseen1.Play();
    }

    public void CutScene2()
    {
        if (PassPuzzle == 5)
        {
            foreach (var player in DisAblePlayerlist)
            {
                player.isDisable = true;
            }
            cutseen2.Play();
        }
        
    }
    public void CutScene3()
    {
        foreach (var player in DisAblePlayerlist)
        {
            player.isDisable = true;
        }
        cutseen3.Play();
    }
    public void CutScene4()
    {
        foreach (var player in DisAblePlayerlist)
        {
            player.isDisable = true;
        }
        cutseen4.Play();
    }
}
