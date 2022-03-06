using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] private GameObject Screen;
    bool IsNukeActive = true;
    [SerializeField] private GameObject GM;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        IsNukeActive = GM.GetComponent<GameManager>().ultimateUsed;
        OpenLevelUp(IsNukeActive);
        
    }
    private void OpenLevelUp(bool IsNukeActive)
    {
        if (IsNukeActive == true)
        {
            Screen.SetActive(true);

        }
        else
        {
            Screen.SetActive(false);
        }
    }
    public void LevelUpSpeed()
    {
        GM.GetComponent<GameManager>().playerSpeedLevel++;
        GM.GetComponent<GameManager>().ultimateUsed = false;
        Time.timeScale = 1.0f;
        Cursor.visible = false;
    }
    public void LevelUpHealth()
    {
        GM.GetComponent<GameManager>().playerHealthLevel++;
        GM.GetComponent<GameManager>().ultimateUsed = false;
        Time.timeScale = 1.0f;
        Cursor.visible = false;
    }
    public void LevelUpReload()
    {
        GM.GetComponent<GameManager>().playerReloadLevel++;
        GM.GetComponent<GameManager>().ultimateUsed = false;
        Time.timeScale = 1.0f;
        Cursor.visible = false;
    }

}
