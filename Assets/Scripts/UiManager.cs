using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;
    [SerializeField] public GameObject fpsController;
    [SerializeField] private GameObject Screen;
    [SerializeField] private GameObject PauseMenu;
    //bool IsNukeActive = true;
    //[SerializeField] private GameObject GM;
    //public bool activeMenubool = false;

    private Image UltimateBar;
    private Image HealthBar;
    private Image ReloadBar;
    // Start is called before the first frame update
    void Start()
    {
        UltimateBar = GameObject.Find("LightBulb").GetComponent<Image>();
        HealthBar = GameObject.Find("Brain_full").GetComponent<Image>();
        ReloadBar = GameObject.Find("ReloadIcon").GetComponent<Image>();
        PauseMenu.SetActive(false);

        UpdateUltimateBar();        //sets the ultimate bar to zero at the start of the game
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void UpdateUltimateBar()
    {
        UltimateBar.fillAmount = GameManager.instance.NormalizedUltimate;
    }

    public void UpdateHealthBar()
    {
        HealthBar.fillAmount = GameManager.playerInstance.NormalizedHealth;
    }

    public void UpdateReloadBar()
    {
        ReloadBar.fillAmount = GameManager.playerInstance.NormalizedReload;
    }

    // Update is called once per frame
    void Update()
    {
        //IsNukeActive = GM.GetComponent<GameManager>().ultimateUsed;
        //OpenLevelUp(IsNukeActive);
        //OpenPause(IsNukeActive);
        //      \(O_o)/

        if(Input.GetButton("Cancel") && !GameManager.instance.isGamePaused)
        {
            OpenPause();
        }
    }
    public void OpenLevelUp()
    {
        Screen.SetActive(true);
        fpsController.GetComponent<FirstPersonController>().enabled = false;
        Cursor.visible = true ;        
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
    }
    public void LevelUpSpeed()
    {
        GameManager.instance.playerSpeedLevel++;
        if(GameManager.instance.spawnInterval > 1.0f)
            GameManager.instance.spawnInterval -= 0.2f;
        ResumeGame();
        //UltimateProgressClear();
    }
    public void LevelUpHealth()
    {
        GameManager.instance.playerHealthLevel++;
        if (GameManager.instance.spawnInterval > 1.0f)
            GameManager.instance.spawnInterval -= 0.2f;
        ResumeGame();
        //UltimateProgressClear();
    }
    public void LevelUpReload()
    {
        GameManager.instance.playerReloadLevel++;
        if (GameManager.instance.spawnInterval > 1.0f)
            GameManager.instance.spawnInterval -= 0.2f;
        ResumeGame();
        //UltimateProgressClear();
    }

    private void UndoChanges()
    {
        fpsController.GetComponent<FirstPersonController>().enabled = true;
        Cursor.visible = true ;        
        Cursor.lockState = CursorLockMode.Confined ;
        Time.timeScale = 1.0f;
    }

    //private void UltimateProgressClear()
    //{
    //    GM.GetComponent<GameManager>().ultimateUsed = false;
    //    GM.GetComponent<GameManager>().ultimateProgress = 0;
    //    UltimateBar.GetComponent<Image>().fillAmount = 0;//is it necessary?

    //}


    public void OpenPause()
    {
        //activeMenubool = true;    //?????
        GameManager.instance.isGamePaused = true;
        PauseMenu.SetActive(true);
        fpsController.GetComponent<FirstPersonController>().enabled = false;
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void ResumeGame()
    {
        UndoChanges();
        PauseMenu.SetActive(false);
        Screen.SetActive(false);
        //activeMenubool = false;;
        GameManager.instance.isGamePaused = false;
    }


    
}
