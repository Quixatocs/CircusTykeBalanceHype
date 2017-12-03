using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;

    private int gameHypeTimeAccrued = 10;

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
        EventManager.increaseTheHypeTime += IncreaseTheHypeTime;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= this.OnLoadCallback;
        EventManager.success -= Success;
        EventManager.failure -= Failure;
        EventManager.loadTheBalanceScene -= LoadBalanceScene;
        EventManager.increaseTheHypeTime -= IncreaseTheHypeTime;
    }

    void OnLoadCallback(Scene scene, LoadSceneMode sceneMode)
    {
        Time.timeScale = 1;
        
        if (scene.name == "Balance")
        { // Balance Scene

        }
        if (scene.name == "Hype")
        { // Hype Scene
            gameHypeTimeAccrued = 10;
            EventManager.invokeSubscribersTo_UpdateBalanceSecondsSignToUI(gameHypeTimeAccrued);
        }
        

    }

    private void Success()
    {
        StartCoroutine(TimerForTimeScale());
    }

    private void Failure()
    {
        StartCoroutine(TimerForTimeScale());
    }

    private IEnumerator TimerForTimeScale()
    {
        yield return new WaitForSeconds(timeToWaitAfterFailure);
        //Put Snapshot looking screenwipe in here
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(LoadHypeScene());
        Time.timeScale = 0f;
        
    }

    private IEnumerator LoadHypeScene()
    {
        yield return null;
        SceneManager.LoadScene("Hype");
    }

    public void IncreaseTheHypeTime()
    {
        gameHypeTimeAccrued += 5;

        if (gameHypeTimeAccrued > 995)
            gameHypeTimeAccrued = 999;

        EventManager.invokeSubscribersTo_UpdateBalanceSecondsSignToUI(gameHypeTimeAccrued);
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
