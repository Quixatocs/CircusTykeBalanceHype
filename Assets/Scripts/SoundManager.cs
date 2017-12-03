using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour {

    public static SoundManager instance = null;

    public AudioSource gameMusicSource;
    public AudioSource gameSFXSource1;
    public AudioSource gameSFXSource2;
    public AudioSource gameSFXSource3;
    public AudioSource gameSFXSource4;
    public AudioSource gameSFXSource5;

    public AudioClip music_HypeMusic;
    public AudioClip music_DrumOneHit;
    public AudioClip[] sfx_Voices;



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
        EventManager.playGaspSound += PlayGaspingSound;
    }


    void OnDisable()
    {
        SceneManager.sceneLoaded -= this.OnLoadCallback;
        EventManager.playGaspSound -= PlayGaspingSound;
    }


    void OnLoadCallback(Scene scene, LoadSceneMode sceneMode)
    {

        if (scene.name == "Hype")
        { // Hype Scene
            //Update_CurrentFunc = Update_Hype;

            PlayMusic(music_HypeMusic, true);
        }

        if (scene.name == "Balance")
        { // Balance Scene
            //Update_CurrentFunc = Update_Balance;
            PlayMusic(music_DrumOneHit, false);

        }
        


    }

    
    delegate void UpdateFunc();
    UpdateFunc Update_CurrentFunc;

    void Update()
    {
        //Update_CurrentFunc();
    }

    private void Update_Hype()
    {
        // NOT IMPLEMENTED
    }

    private void Update_Balance()
    {

        

    }


    private void PlayGaspingSound()
    {
        int RNGsus = Mathf.FloorToInt(Random.Range(0, sfx_Voices.Length));
        if (!gameSFXSource1.isPlaying)
        {
            gameSFXSource1.clip = sfx_Voices[RNGsus];
            gameSFXSource1.pitch = Random.Range(0.8f, 1.4f);
            gameSFXSource1.Play();
        }
        else if (!gameSFXSource2.isPlaying)
        {
            gameSFXSource2.clip = sfx_Voices[RNGsus];
            gameSFXSource2.pitch = Random.Range(0.8f, 1.4f);
            gameSFXSource2.Play();
        }
        else if (!gameSFXSource3.isPlaying)
        {
            gameSFXSource3.clip = sfx_Voices[RNGsus];
            gameSFXSource3.pitch = Random.Range(0.8f, 1.4f);
            gameSFXSource3.Play();
        }
        else if (!gameSFXSource4.isPlaying)
        {
            gameSFXSource4.clip = sfx_Voices[RNGsus];
            gameSFXSource4.pitch = Random.Range(0.8f, 1.4f);
            gameSFXSource4.Play();
        }
        else if (!gameSFXSource5.isPlaying)
        {
            gameSFXSource5.clip = sfx_Voices[RNGsus];
            gameSFXSource5.pitch = Random.Range(0.8f, 1.4f);
            gameSFXSource5.Play();
        }


    }


    

    private void PlayMusic(AudioClip music, bool isLoop)
    {
        gameMusicSource.Stop();
        gameMusicSource.loop = isLoop;
        gameMusicSource.clip = music;
        gameMusicSource.Play();
    }




}
