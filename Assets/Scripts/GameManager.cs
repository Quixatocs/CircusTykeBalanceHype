using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;

    private int gameHypeTimeAccrued = 5;

    public float timeToWaitAfterFailure = 6f;

    void Awake()
    {
        singleton();
    }

    void singleton()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += this.OnLoadCallback;
        EventManager.success += Success;
        EventManager.failure += Failure;
        EventManager.loadTheBalanceScene += LoadBalanceScene;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= this.OnLoadCallback;
        EventManager.success -= Success;
        EventManager.failure -= Failure;
        EventManager.loadTheBalanceScene -= LoadBalanceScene;
    }

    void OnLoadCallback(Scene scene, LoadSceneMode sceneMode)
    {
        Time.timeScale = 1;
        
        if (scene.name == "Balance")
        { // Balance Scene

        }
        if (scene.name == "Hype")
        { // Hype Scene
            gameHypeTimeAccrued = 5;
        }
        

    }

    private void Success()
    {
        StartCoroutine(TimerForTimeScale());
    }

    private void Failure()
    {
        StartCoroutine(TimerForTimeScale());
        //Invoke("LoadHypeScene", timeToWaitAfterFailure + 0.1f);
    }

    private IEnumerator TimerForTimeScale()
    {
        yield return new WaitForSeconds(timeToWaitAfterFailure);
        Debug.Log("Wait1");
        //Put Snapshot looking screenwipe in here
        yield return new WaitForSeconds(0.1f);
        Debug.Log("Wait2");
        StartCoroutine(LoadHypeScene());
        Debug.Log("AfterInvokeS");
        Time.timeScale = 0f;
        
    }

    private IEnumerator LoadHypeScene()
    {
        Debug.Log("Loading");
        yield return null;
        SceneManager.LoadScene("Hype");
    }

    public void IncreaseTheHypeTime()
    {
        gameHypeTimeAccrued += 5;
    }

    public void LoadBalanceScene()
    {
        SceneManager.LoadScene("Balance");
    }

    public int GetGameHypeTimeAccrued()
    {
        return gameHypeTimeAccrued;
    }


}
