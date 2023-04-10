using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class ResultText : MonoBehaviour
{   
    [FormerlySerializedAs("text")]
    [Tooltip("Set where number will show (IN ORDER LEFT TO RIGHT)")]
    [SerializeField] private List<TextMeshProUGUI> placeholder;
    private TextMeshProUGUI currentText;
    private MathPuzzleController mathPuzzleController;

    public List<MultiplyButton> multiplyButton;
    public List<DivideButton> divideButtons;

    private float num;

    private void Awake()
    {
        multiplyButton ??= new List<MultiplyButton>();
        divideButtons ??= new List<DivideButton>();
    }

    private void Start()
    {
        // multiplyButton = FindObjectsOfType<MultiplyButton>().ToList();
        // divideButtons = FindObjectsOfType<DivideButton>().ToList();
        mathPuzzleController = FindObjectOfType<MathPuzzleController>();
        
        DisableAllBtn();
        multiplyButton[0].gameObject.SetActive(true);
        divideButtons[0].gameObject.SetActive(true);
        
        num = 10;
    }

    public void UpdateText(float _state)
    {
        switch(_state)
        {
            case 1 :
                currentText = placeholder[1];
                DisableAllBtn();
                multiplyButton[1].gameObject.SetActive(true);
                divideButtons[1].gameObject.SetActive(true);
                break;
            case 2 :
                currentText = placeholder[2];
                DisableAllBtn();
                multiplyButton[2].gameObject.SetActive(true);
                divideButtons[2].gameObject.SetActive(true);
                break;
            case 3 :
                currentText = placeholder[3];
                DisableAllBtn();
                // multiplyButton[2].gameObject.SetActive(true);
                // divideButtons[2].gameObject.SetActive(true);
                break;
        }
    }

    public void MultiplyState(float _multiplyNum)
    {
        num *= _multiplyNum;
        num = Mathf.Round(num);
        currentText.text = num.ToString();
    }

    public void DivideState(float _divineNum)
    {
        num /= _divineNum;
        num = Mathf.Round(num);
        currentText.text = num.ToString();
    }

    public void ChangeStateToAll(float _value)
    {
        foreach (var _btn in multiplyButton)
        {
            _btn.state++;
            _btn.multiplyNum = _value + 1;
        }
        
        foreach (var _btn in divideButtons)
        {
            _btn.state++;
            _btn.divideNum = _value + 1;
        }
        
        mathPuzzleController.CheckAnswer();
    }

    public void ResetValue()
    {
        num = 10;
        
        placeholder[1].text = "00";
        placeholder[2].text = "00";
        placeholder[3].text = "00";
    }

    private void DisableAllBtn()
    {
        foreach (var _btn in multiplyButton)
        {
            _btn.gameObject.SetActive(false);
        }
        
        foreach (var _btn in divideButtons)
        {
            _btn.gameObject.SetActive(false);
        }
    }
}
