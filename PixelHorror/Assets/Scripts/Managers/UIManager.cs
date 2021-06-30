using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Canvas")]
    [SerializeField]
    private Canvas myCanvas;

    [Header("Main Menu")]
    [SerializeField]
    private GameObject mainMenuObject;

    [Header("Loading Screen")]
    [SerializeField]
    private GameObject loadingScreenObject;
    [SerializeField]
    private Image loadingImage;

    [Header("Gameplay")]
    [SerializeField]
    private GameObject gameplayObject;
    [SerializeField]
    private GameObject gameplayInventoryObject;

    [Header("Pause Menu")]
    [SerializeField]
    private GameObject pauseObject;


    public static UIManager Instance { get; private set; } = null;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            AwakeSetupManager(); //Setup the manager
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void AwakeSetupManager()        //Add code here to do on Awake!
    {
        DontDestroyOnLoad(gameObject);

        
    }

    //Main Menu Stuff
    #region MainMenu
    public void ShowMainMenuStuff()
    {
        mainMenuObject.SetActive(true);
    }
    public void HideMainMenuStuff()
    {
        mainMenuObject.SetActive(false);
    }
    #endregion
    //Gameplay Stuff
    #region Gameplay

    public void ShowGameplayHUD()
    {
        gameplayObject.SetActive(true);
    }

    public void HideGameplayHUD()
    {
        gameplayObject.SetActive(false);
    }

    public void ShowInventory()
    {
        gameplayInventoryObject.SetActive(true);
    }

    public void HideInventory()
    {
        gameplayInventoryObject.SetActive(false);
    }

    #endregion

    //Loading Level Stuff
    #region Loading
    public void UpdateLoadingBar(float val)
    {
        loadingImage.fillAmount = val;
    }

    public void ShowLoadingScreen()
    {
        loadingScreenObject.SetActive(true);
    }

    public void HideLoadingScreen()
    {
        loadingScreenObject.SetActive(false);
    }

    #endregion
}
