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
    public bool ultimateUsed = false;

    [Header("Player levels")]
    public int playerSpeedLevel = 1;
    public int playerHealthLevel = 1;
    public int playerReloadLevel = 1;

    public GameObject ghostPrefab;
    public Transform spawnPoint;
    float enemyCooldown;

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
        ultimateUsed = false;
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

    void ChargeUltimate(float value)
    {
        ultimateProgress += value;
        if(CanUseUltimate)
        {
            //some code
        }
    }

    public void UseUltimate()
    {
        ultimateUsed = true;

        //some code
    }

    public void OnDie()
    {
        SceneManager.LoadScene(2);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
