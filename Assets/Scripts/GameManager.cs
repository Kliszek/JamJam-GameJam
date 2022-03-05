using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static Player playerInstance;
    public int playerScore;
    public float ultimateProgress;
    public float ultimateBoundary = 100.0f;
    public bool CanUseUltimate => ultimateProgress >= ultimateBoundary;
    public bool ultimateUsed = false;

    [Header("Player levels")]
    public int playerSpeedLevel = 1;
    public int playerHealthLevel = 1;
    public int playerReloadLevel = 1;

    private void Awake()
    {
        if (instance == null)
            instance = this;

    }
    void Start()
    {
        if (playerInstance == null)
            playerInstance = FindObjectOfType<Player>();

        playerScore = 0;
        ultimateProgress = 0.0f;
        ultimateUsed = false;
    }

    void AddPoints(int points)
    {
        playerScore += points;
    }

    void ChargeUltimate(float value)
    {
        ultimateProgress += value;
        if(CanUseUltimate)
        {
            //some code
        }
    }

    void UseUltimate()
    {
        ultimateUsed = true;
        //some code
    }


}
