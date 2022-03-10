using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class UiManager : MonoBehaviour
{
    [SerializeField] public GameObject fpsController;
    [SerializeField] private GameObject Screen;
    [SerializeField] private GameObject PauseMenu;
    bool IsNukeActive = true;
    [SerializeField] private GameObject GM;
    private bool activeMenubool = false;

    private GameObject UltimateProgressUI;
    // Start is called before the first frame update
    void Start()
    {
        UltimateProgressUI = GameObject.Find("LightBulb");
        PauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        IsNukeActive = GM.GetComponent<GameManager>().ultimateUsed;
        OpenLevelUp(IsNukeActive);
        OpenPause(IsNukeActive);
        
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
        UndoChanges();
        UltimateProgressClear();
    }
    public void LevelUpHealth()
    {
        GM.GetComponent<GameManager>().playerHealthLevel++;
        UndoChanges();
        UltimateProgressClear();
    }
    public void LevelUpReload()
    {
        GM.GetComponent<GameManager>().playerReloadLevel++;
        UndoChanges();
        UltimateProgressClear();
    }

    private void UndoChanges()
    {
        fpsController.GetComponent<FirstPersonController>().enabled = true;
        Cursor.visible = true ;        
        Cursor.lockState = CursorLockMode.Confined ;
        Time.timeScale = 1.0f;
    }

    private void UltimateProgressClear()
    {
        GM.GetComponent<GameManager>().ultimateUsed = false;
        GM.GetComponent<GameManager>().ultimateProgress = 0;
        UltimateProgressUI.GetComponent<Image>().fillAmount = 0;//is it necessary?

    }

    private void OpenPause(bool activeMenubool)
    {
        if (Input.GetButton("Cancel") && activeMenubool == false)
        {
            activeMenubool = true;
            PauseMenu.SetActive(true);
            fpsController.GetComponent<FirstPersonController>().enabled = false;
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void ResumeGame()
    {
        UndoChanges();
        PauseMenu.SetActive(false);
        activeMenubool = false;

    }
}
