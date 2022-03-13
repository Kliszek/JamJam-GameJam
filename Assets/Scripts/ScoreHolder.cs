using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreHolder : MonoBehaviour
{
    public float playerScore = 0.0f;

    private void Awake()
    {
        Debug.Log("AWAKE");
        DontDestroyOnLoad(this);
    }

    void OnLevelWasLoaded(int levelindex)
    {
        if(levelindex == 2)
        {
            Debug.Log($"SCORE HOLDER: score = {playerScore}");
            GameObject.Find("Score").GetComponent<Text>().text = $"SCORE:\n{playerScore}";
        }
    }
}
