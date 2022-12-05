using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Playables;
using System.Linq;


public class MathPuzzleController : MonoBehaviour
{
    [Tooltip("Set what to show when completed puzzle")]
    [SerializeField] private GameObject rewardPrefab;
    
    [Tooltip("Set the answer")] [SerializeField]
    private float answer = 15f;

    [Tooltip("Set the TMP Box of answer")] [SerializeField]
    private TextMeshProUGUI answerBox;
    
    private float tempNum;
    private bool isCompleted;
    public GameObject NoComplete;
    public GameObject HaveBeenComplete;

    public CutScenePlay cutplay;
   
    //public PlayableDirector cutseen1;
    //private List<DisablePlayerControl> DisAblePlayerlist;
    private void Start()
    {
       // rewardPrefab.GetComponent<Renderer>().material.color = Color.red;
        NoComplete.SetActive(true);
        HaveBeenComplete.SetActive(false);
        //DisAblePlayerlist = FindObjectsOfType<DisablePlayerControl>().ToList();
    }
    
    public void CheckAnswer()
    {
        tempNum = float.Parse(answerBox.text);

        if (tempNum == answer) isCompleted = true;
        CheckCompleted();
    }

    private void CheckCompleted()
    {
        if (!isCompleted) return;
        // rewardPrefab.GetComponent<Renderer>().material.color = Color.green;
        NoComplete.SetActive(false);
        HaveBeenComplete.SetActive(true);
        cutplay.CutScene1();
        CutScenePlay.PassPuzzle += 1;
        cutplay.CutScene2();
            
        //foreach (var player in DisAblePlayerlist)
        //{
        //    player.isDisable = true;
        //}
        //cutseen1.Play();

    }

}
