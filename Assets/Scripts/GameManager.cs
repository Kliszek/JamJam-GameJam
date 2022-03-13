using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    private GameObject ultimateGameObject;

    public float spawnInterval = 2.0f;
    public Transform[] spawnPoints;
    private float spawnNoise = 0.0f;

    [Header("Player levels")]
    public int playerSpeedLevel = 1;
    public int playerHealthLevel = 1;
    public int playerReloadLevel = 1;

    [Space(10)]
    public float waitAfterUltimate = 1.0f;
    float waitTime;

    public GameObject ghostPrefab;
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
        ultimateGameObject = GameObject.Find("Ultimate");
        ultimateGameObject.SetActive(false);

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
        if (enemyCooldown <= spawnNoise && !ultimateUsed)
        {
            Transform spawnPoint = spawnPoints[Random.Range(0,spawnPoints.Length)];
            Instantiate(ghostPrefab, spawnPoint);
            enemyCooldown = spawnInterval;

            spawnNoise = Random.Range(0, 5) * 0.1f;
        }

        if(ultimateUsed)
        {
            waitTime += Time.deltaTime;
            if(waitTime >= waitAfterUltimate)
            {
                ultimateUsed = false;
                ultimateGameObject.SetActive(false);
                ultimateProgress = 0.0f;
                UiManager.instance.UpdateUltimateBar();
                UiManager.instance.OpenLevelUp();
            }
        }
    }

    public void AddPoints(int points)
    {
        playerScore += points;
        UiManager.instance.UpdateScoreUI();
    }

    public void ChargeUltimate(float value)
    {
        ultimateProgress += value;
        UiManager.instance.UpdateUltimateBar();
        if(CanUseUltimate)
        {
            //UiManager.instance.UpdateUltimateBar();
        }
    }

    public void UseUltimate()
    {
        ultimateGameObject.SetActive(true);
        ultimateProgress = 0;
        ultimateUsed = true;
        waitTime = 0.0f;
        AddPoints(50);

        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            enemy.GetComponent<Ghost>().Explode();
        }

        //some code
    }

    public void OnDie()
    {
        GameObject.Find("ScoreHolder").GetComponent<ScoreHolder>().playerScore = playerScore;
        SceneManager.LoadScene(2);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
