using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProtipDisplay : MonoBehaviour
{
    private string[] protips = { "Try not to get shot next time", "If you dodge bullets fast enough, you won't get killed", "If you shoot an enemy, they immediately die", "Load your ultimate bar by shooting down enemies", "Make sure not to paste bullet movement into the player's script", "Pay attention to your mental health – stop playing when you're too tired" };
    public Text protipText;

    void Start()
    {
        protipText.text = "PROTIP: " + protips[Random.Range(0, protips.Length)] + "!";
    }
}
