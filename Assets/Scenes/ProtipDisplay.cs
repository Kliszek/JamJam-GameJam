using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProtipDisplay : MonoBehaviour
{
    private string[] protips = { "Just don't die", "If you shoot an enemy, they get killed", "Load your ultimate bar by shooting down enemies" };
    public Text protipText;

    void Start()
    {
        protipText.text = "PROTIP: " + protips[Random.Range(0, protips.Length)] + "!";
    }
}
