using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : Interactable
{
    [SerializeField] private float delay = 0.5f;
    [SerializeField] private float powerToAdd = 10;
    private const string clickText = "[E] to add power";

    private bool isHeld;
    
    private void Start()
    {
        
    }

    public override string GetDescription()
    {
        return clickText;
    }

    public override void Interact()
    {
        AddPower();
    }

    private void AddPower()
    {
        var generatorTimer = GetComponent<GeneratorTimer>();

        generatorTimer.AddTime(powerToAdd);
    }

    // private IEnumerator HoldToAddPower()
    // {
    //     while (isHeld)
    //     {
    //         AddPower();
    //         yield return new WaitForSeconds(delay);
    //     }
    // }
}
