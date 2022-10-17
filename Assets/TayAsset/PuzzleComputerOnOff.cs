using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleComputerOnOff : MonoBehaviour
{
    public float numberOn ;
    public float numberoff;
    public GameObject b;
    // Start is called before the first frame update
    void Start()
    {
        numberOn = 0;
        numberoff = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag =="MustON")
        {
            numberOn++;
        }
        if (collision.gameObject.tag == "MustNotOn")
        {
            numberoff++;
        }
        if (numberOn==numberoff && numberOn!=0)
        {
            b.SetActive(true);
          //  LightSwitch.Blue = true;
        }
        
    }
}
