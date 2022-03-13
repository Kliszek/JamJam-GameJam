using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProtipDisplay : MonoBehaviour
{
    private string[] protips = { "Avoid bumping into ghosts at all costs", "Press SHIFT to run faster", "Every time you shoot down a ghost, your light bulb gains energy", "Don't let the ghosts surround you", "Ghosts are usually afraid of light", "Pay attention to your mental health – stop playing when you're tired" };
    Text protipText;

    void Start()
    {
        protipText = GetComponent<Text>();
        protipText.text = "PROTIP: " + protips[Random.Range(0, protips.Length)] + "!";
    }
}
