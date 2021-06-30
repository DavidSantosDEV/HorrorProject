using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //SceneManagement Stuff
    private PlayerController _Player;

    public static GameManager Instance { get; private set; } = null;
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
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    //Reference Setting
    public void SetPlayer(PlayerController player)
    {
        _Player = player;
    }

    //SCENE MANAGEMENT

    private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            //Main Menu
        }
        else
        {
            //Game
        
        }
    }

    public void OpenLevel(int levelIndex)
    {

    }

    private IEnumerator LoadLevel(int level)
    {
        AsyncOperation loadingLevel = SceneManager.LoadSceneAsync(level);
        UIManager.Instance.ShowLoadingScreen();
        while (!loadingLevel.isDone)
        {
            //UpdateProgress
            UIManager.Instance.UpdateLoadingBar(loadingLevel.progress);
            yield return null;
        }
        //UpdateProgress
        UIManager.Instance.UpdateLoadingBar(loadingLevel.progress);
        yield return null;
        UIManager.Instance.HideLoadingScreen();
        //Finished
    }
}
