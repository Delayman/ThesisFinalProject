using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PressAllPlateController : MonoBehaviour
{
    [Tooltip("Set what to show when completed puzzle")]
    [SerializeField] private GameObject rewardPrefab;
    [SerializeField] private float delay = 2f;

    private Checker checker;
    private List<Checker> activatedList;
    private List<bool> checkList;
    public List<GameObject> btnList;
    
    private bool isCompleted;
    private bool isDisableAfterCompleted;

    public GameObject NoComplete;
    public GameObject HaveBeenComplete;
    
    private TimerManager timer;

    public CutScenePlay cutplay;
    public AudioSource Winsound;
    public GameObject Startpoint;
    public GameObject MainGame;
    private void Awake()
    {
        activatedList ??= new List<Checker>();
        checkList ??= new List<bool>();
    }

    private void Start()
    {
        activatedList = FindObjectsOfType<Checker>().ToList();
        NoComplete.SetActive(true);
        HaveBeenComplete.SetActive(false);
        timer = FindObjectOfType<TimerManager>();
        timer.TriggerCompleteTimerTwo();
    }

    public void CheckCompleted(Checker _checker)
    {
        checker = _checker;
        
        if (checker.isPressed)
        {
            checkList.Add(checker.isPressed);
            isCompleted = true;
        }

        if (!_checker.isPressed)
        {
            ResetThisPuzzle();
        }
        
        if (checkList.Count == activatedList.Count && isCompleted)
        {
            if (isDisableAfterCompleted) return;
            //rewardPrefab.GetComponent<Renderer>().material.color = Color.green;
            NoComplete.SetActive(false);
            HaveBeenComplete.SetActive(true);
            Winsound.Play();
            var counter = GetComponentInParent<Counter>();
            counter.AddScore();
            CutScenePlay.PassPuzzle += 1;
            cutplay.CutScene2();
            isDisableAfterCompleted = true;
        }
    }

    public void ResetThisPuzzle()
    {
        isCompleted = false;
        checkList.Clear();
        ResetColor();
        MainGame.transform.position = Startpoint.transform.position;
        MainGame.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    private void ResetColor()
    {
        foreach (var _obj in activatedList)
        {
            _obj.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
            _obj.isPressed = false;
        }
    }
    
    public IEnumerator ButtonDelay()
    {
        foreach (var btn in btnList)
        {
            btn.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        
        yield return new WaitForSeconds(delay);
        
        foreach (var btn in btnList)
        {
            btn.gameObject.GetComponent<BoxCollider>().enabled = true;
        }
        
    }
}
