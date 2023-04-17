using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class ExportDataToGGSheet : MonoBehaviour
{
   public int i = 10;
    public string k = "koko";


    [SerializeField] private string BaseURL = "https://docs.google.com/spreadsheets/d/1CCtQ2vtmOuPAFGYjmDwWW_USTfGDvm9503YwyrIP6dM/edit?usp=sharing";
   IEnumerator Post()
    {
        WWWForm form = new WWWForm();
        form.AddField("num",i);
        form.AddField("name", k);
        byte[] rawdata = form.data;
        WWW www = new WWW(BaseURL , rawdata);
        yield return www;
    }

    public void Send()
    {
        StartCoroutine(Post());
    }
}
