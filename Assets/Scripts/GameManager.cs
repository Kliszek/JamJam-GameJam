using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static Player playerInstance;
    public int playerScore;
    public float ultimateProgress = 0.0f;
    public float ultimateBoundary = 100.0f;
    public float NormalizedUltimate => ultimateProgress / ultimateBoundary;
    public bool CanUseUltimate => ultimateProgress >= ultimateBoundary;
    //public bool ultimateUsed = false;

    [Header("Player levels")]
    public int playerSpeedLevel = 1;
    public int playerHealthLevel = 1;
    public int playerReloadLevel = 1;

    public GameObject ghostPrefab;
    public Transform spawnPoint;
    float enemyCooldown;

    public bool isGamePaused = false;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        if (playerInstance == null)
            playerInstance = FindObjectOfType<Player>();

    }
    void Start()
    {
        enemyCooldown = 5.0f;
        if (playerInstance == null)
            playerInstance = FindObjectOfType<Player>();
        if (playerInstance == null)
            Debug.LogError("Coult not find the Player!");

        playerScore = 0;
        ultimateProgress = 0.0f;

        isGamePaused = false;
    }

    private void Update()
    {
        enemyCooldown -= Time.deltaTime;
        if (enemyCooldown <= 0.0f)
        {
            Instantiate(ghostPrefab, spawnPoint);
            enemyCooldown = 3.0f;
        }
    }

    void AddPoints(int points)
    {
        playerScore += points;
    }

    public void ChargeUltimate(float value)
    {
        ultimateProgress += value;
        UiManager.instance.UpdateUltimateBar();
        if(CanUseUltimate)
        {
            //some code
        }
    }

    public void UseUltimate()
    {
        ultimateProgress = 0;
        UiManager.instance.UpdateUltimateBar();
        UiManager.instance.OpenLevelUp();
        //some code
    }

    public void OnDie()
    {
        Time.timeScale = 0.0f;
        SceneManager.LoadScene(2);
    }
}
