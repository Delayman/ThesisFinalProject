using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PasswordRoom : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI PasswordFull;

    public string anser = "222222";

    public void Number1()
    {
        PasswordFull.text += 1.ToString();
    }
    public void Number2()
    {
        PasswordFull.text += 2.ToString();
    }
    public void Number3()
    {
        PasswordFull.text += 3.ToString();
    }
    public void Number4()
    {
        PasswordFull.text += 4.ToString();
    }
    public void Number5()
    {
        PasswordFull.text += 5.ToString();
    }
    public void Number6()
    {
        PasswordFull.text += 6.ToString();
    }
    public void Number7()
    {
        PasswordFull.text += 7.ToString();
    }
    public void Number8()
    {
        PasswordFull.text += 8.ToString();
    }
    public void Number9()
    {
        PasswordFull.text += 9.ToString();
    }

    public void Execute()
    {
        if(PasswordFull.text == anser)
        {
            PasswordFull.text = "Correct";
        }
        else
        {
            PasswordFull.text = "Wrong";
        }
    }
}
