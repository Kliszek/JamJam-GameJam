using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class UiManager : MonoBehaviour
{
    [SerializeField] public GameObject fpsController;
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
            fpsController.GetComponent<FirstPersonController>().enabled = false;
            Cursor.visible = true ;        
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;


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
        UndoChanges();
    }
    public void LevelUpHealth()
    {
        GM.GetComponent<GameManager>().playerHealthLevel++;
        GM.GetComponent<GameManager>().ultimateUsed = false;
        UndoChanges();
    }
    public void LevelUpReload()
    {
        GM.GetComponent<GameManager>().playerReloadLevel++;
        GM.GetComponent<GameManager>().ultimateUsed = false;
        UndoChanges();
    }

    private void UndoChanges()
    {
        fpsController.GetComponent<FirstPersonController>().enabled = true;
        Cursor.visible = true ;        
        Cursor.lockState = CursorLockMode.Confined ;
        Time.timeScale = 1.0f;
    }

}
