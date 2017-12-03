using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {

    public static GameManager instance = null;

    private int gameHypeTimeAccrued = 10;

    public float timeToWaitAfterFailure = 6f;

    private bool isSecondPlusPlaythrough = false;

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
            isSecondPlusPlaythrough = true;
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
        EventManager.invokeSubscribersTo_TakeSnapshot();
        float fadetime = GetComponent<Fading>().beginFade(1);
        yield return new WaitForSeconds(fadetime);
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
        StartCoroutine(LoadBalanceSceneAfterFade());
    }

    public IEnumerator LoadBalanceSceneAfterFade()
    {
        float fadetime = GetComponent<Fading>().beginFade(1);
        yield return new WaitForSeconds(fadetime);
        SceneManager.LoadScene("Balance");
    }

    public int GetGameHypeTimeAccrued()
    {
        return gameHypeTimeAccrued;
    }

    public bool GetIsSecondPlusPlaythrough()
    {
        return isSecondPlusPlaythrough;
    }


}
