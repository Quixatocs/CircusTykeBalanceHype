using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour {

    public static SoundManager instance = null;

    public float musicVolume = 0.7f;

    public AudioSource gameMusicSource;
    public AudioSource gameSFXSource1;
    public AudioSource gameSFXSource2;
    public AudioSource gameSFXSource3;
    public AudioSource gameSFXSource4;
    public AudioSource gameSFXSource5;

    public AudioClip music_HypeMusic;
    public AudioClip music_DrumOneHit;
    public AudioClip[] sfx_GameVoices;
    public AudioClip cheer;
    public AudioClip boo;
    public AudioClip cameraShutter;

    public AudioClip bossBalanceTykePhrase;
    public AudioClip[] bossAntecedantPhrases;
    public AudioClip[] bossConsequentPhrases;





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
        EventManager.failure += FailureSound;
        EventManager.success += SuccessSound;
        EventManager.takeSnapshot += SnapshotSound;

        EventManager.playAntecedent += PlayAntecedent;
        EventManager.playConsequent += PlayConsequent;
        EventManager.playTyke += PlayTyke;

    }


    void OnDisable()
    {
        SceneManager.sceneLoaded -= this.OnLoadCallback;
        EventManager.playGaspSound -= PlayGaspingSound;
        EventManager.failure -= FailureSound;
        EventManager.success -= SuccessSound;
        EventManager.takeSnapshot -= SnapshotSound;

        EventManager.playAntecedent -= PlayAntecedent;
        EventManager.playConsequent -= PlayConsequent;
        EventManager.playTyke -= PlayTyke;
    }


    void OnLoadCallback(Scene scene, LoadSceneMode sceneMode)
    {

        if (scene.name == "Hype")
        { // Hype Scene
            PlayMusic(music_HypeMusic, true);
        }

        if (scene.name == "Balance")
        { // Balance Scene
            PlayMusic(music_DrumOneHit, false);

        }
        


    }


    private void PlayGaspingSound()
    {
        int RNGsus = Mathf.FloorToInt(Random.Range(0, sfx_GameVoices.Length));
        if (!gameSFXSource1.isPlaying)
        {
            gameSFXSource1.clip = sfx_GameVoices[RNGsus];
            gameSFXSource1.pitch = Random.Range(0.8f, 1.4f);
            gameSFXSource1.Play();
        }
        else if (!gameSFXSource2.isPlaying)
        {
            gameSFXSource2.clip = sfx_GameVoices[RNGsus];
            gameSFXSource2.pitch = Random.Range(0.8f, 1.4f);
            gameSFXSource2.Play();
        }
        else if (!gameSFXSource3.isPlaying)
        {
            gameSFXSource3.clip = sfx_GameVoices[RNGsus];
            gameSFXSource3.pitch = Random.Range(0.8f, 1.4f);
            gameSFXSource3.Play();
        }
        else if (!gameSFXSource4.isPlaying)
        {
            gameSFXSource4.clip = sfx_GameVoices[RNGsus];
            gameSFXSource4.pitch = Random.Range(0.8f, 1.4f);
            gameSFXSource4.Play();
        }
        else if (!gameSFXSource5.isPlaying)
        {
            gameSFXSource5.clip = sfx_GameVoices[RNGsus];
            gameSFXSource5.Play();
        }


    }


    

    private void PlayMusic(AudioClip music, bool isLoop)
    {
        gameMusicSource.Stop();
        gameMusicSource.volume = musicVolume;
        gameMusicSource.loop = isLoop;
        gameMusicSource.clip = music;
        gameMusicSource.Play();
    }

    private void FailureSound()
    {
        gameSFXSource5.Stop();
        gameSFXSource5.loop = false;
        gameSFXSource5.clip = boo;
        gameSFXSource5.Play();
    }

    private void SuccessSound()
    {
        gameSFXSource5.Stop();
        gameSFXSource5.loop = false;
        gameSFXSource5.clip = cheer;
        gameSFXSource5.Play();
    }

    private void SnapshotSound()
    {
        gameSFXSource4.Stop();
        gameSFXSource4.pitch = Random.Range(0.9f, 1.1f);
        gameSFXSource4.loop = false;
        gameSFXSource4.clip = cameraShutter;
        gameSFXSource4.Play();
    }

    private void PlayAntecedent()
    {
        int RNGsus = Mathf.FloorToInt(Random.Range(0, bossAntecedantPhrases.Length));
        gameSFXSource5.Stop();
        gameSFXSource5.loop = false;
        gameSFXSource5.clip = bossAntecedantPhrases[RNGsus];
        gameSFXSource5.Play();
    }

    private void PlayConsequent()
    {
        int RNGsus = Mathf.FloorToInt(Random.Range(0, bossConsequentPhrases.Length));
        gameSFXSource5.Stop();
        gameSFXSource5.loop = false;
        gameSFXSource5.clip = bossConsequentPhrases[RNGsus];
        gameSFXSource5.Play();
    }

    private void PlayTyke()
    {
        gameSFXSource5.Stop();
        gameSFXSource5.loop = false;
        gameSFXSource5.clip = bossBalanceTykePhrase;
        gameSFXSource5.Play();
    }






}
