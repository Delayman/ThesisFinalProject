using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Playables;
using System.Linq;
using Photon.Pun;


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
    private bool isDisableAfterCompleted;

    public GameObject NoComplete;
    public GameObject HaveBeenComplete;

    public CutScenePlay cutplay;
    
    private TimerManager timer;

    public AudioSource Winsound;
    
    public List<DivideButton> divBtnList;
    public List<MultiplyButton> mulBtnList;

    private ResultText resultTxt;
    //public PlayableDirector cutseen1;
    //private List<DisablePlayerControl> DisAblePlayerlist;
    private void Start()
    {
        NoComplete.SetActive(true);
        HaveBeenComplete.SetActive(false);
        timer = FindObjectOfType<TimerManager>();
        resultTxt = FindObjectOfType<ResultText>();
    }
    
    public void CheckAnswer()
    {
        tempNum = float.Parse(answerBox.text);

        if (tempNum != answer)
        {
            if (divBtnList[0].state == 4)
            {
                foreach (var divBtn in divBtnList)
                {
                    divBtn.state = 1;
                    divBtn.divideNum = 2;
                }
                
                foreach (var mulBtn in mulBtnList)
                {
                    mulBtn.state = 1;
                    mulBtn.multiplyNum = 2;
                }
                
                resultTxt.ResetValue();
            }
        }

        if (tempNum == answer) 
            isCompleted = true;
        
        CheckCompleted();
    }

    private void CheckCompleted()
    {
        if (!isCompleted || isDisableAfterCompleted) return;
        // rewardPrefab.GetComponent<Renderer>().material.color = Color.green;
        NoComplete.SetActive(false);
        HaveBeenComplete.SetActive(true);
        timer.TriggerCompleteTimerFour();
        Winsound.Play();
        //var counter = GetComponentInParent<Counter>();
        //counter.AddScore();

        PlayCutscene();

        this.GetComponent<PhotonView>().RPC("PlayCutscene", RpcTarget.All);

        isDisableAfterCompleted = true;
    }
    
    [PunRPC]
    void PlayCutscene()
    {
        cutplay.CutScene1();
        CutScenePlay.PassPuzzle += 1;
        cutplay.CutScene2();
    }
}
