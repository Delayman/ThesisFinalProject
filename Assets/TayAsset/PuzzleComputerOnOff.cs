using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleComputerOnOff : MonoBehaviour
{
    public float numberOn ;
    public float numberoff;
    public GameObject b;
    TheSystemInCamararoomTest the;
    // Start is called before the first frame update
    void Start()
    {
        numberOn = 0;
        numberoff = 0;
        b.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    private void OnTriggerStay(Collider other)
    {
        if (other.tag =="MustON")
        {
            numberOn+=1f;
            Debug.Log("1");
        }
        if (other.tag == "LightCheck")
        {
            numberoff+= 1f;
            Debug.Log("2");
        }
        if (numberOn==numberoff && numberOn!=0)
        {
            b.SetActive(true);
          //  LightSwitch.Blue = true;
        }
        if(other.tag == "Player")
        {
            b.SetActive(true);
           
        }
        
    }
}
