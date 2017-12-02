using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public float timeToWaitAfterFailure = 6f;

    void OnEnable()
    {
        SceneManager.sceneLoaded += this.OnLoadCallback;
        EventManager.success += Success;
        EventManager.failure += Failure;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= this.OnLoadCallback;
        EventManager.success -= Success;
        EventManager.failure -= Failure;
    }

    void OnLoadCallback(Scene scene, LoadSceneMode sceneMode)
    {
        Time.timeScale = 1;
        /*
        if (scene.name == "Balance")
        { // Balance Scene
            Time.timeScale = 1;
        }
        if (scene.name == "Hype")
        { // Hype Scene
            Time.timeScale = 1;
        }
        */

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
        Time.timeScale = 0;

    }


}
