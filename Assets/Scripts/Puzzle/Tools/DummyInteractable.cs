using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyInteractable : Interactable
{
    private const string testText = "[E] to play test";

    public override string GetDescription()
    {
        return testText;
    }

    public override void Interact()
    {
        var counter = GetComponent<Counter>();
        counter.AddScore();
    }
}
