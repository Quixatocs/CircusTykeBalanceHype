using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fading : MonoBehaviour {

    public Texture2D fadeOutTexture;
    public float fadeSpeed = 0.8f;

    private int drawDepth = -1000;
    private float alpha = 1.0f;
    private int fadeDir = -1;


    void OnEnable()
    {
        SceneManager.sceneLoaded += this.OnLoadCallback;
    }


    void OnDisable()
    {
        SceneManager.sceneLoaded -= this.OnLoadCallback;
    }

    void OnGUI()
    {
        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
    }

    // set direction to fade
    public float beginFade(int direction)
    {
        fadeDir = direction;
        return (fadeSpeed);
    }

    void OnLoadCallback(Scene scene, LoadSceneMode sceneMode)
    {
        beginFade(-1);
    }
}
