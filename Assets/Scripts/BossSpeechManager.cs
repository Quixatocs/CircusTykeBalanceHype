using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossSpeechManager : MonoBehaviour {

    public Text textDisplayBoss;
    public Text textDisplayResponse;
    public Image speechBubbleTyke;
    public GameObject startButton;
    public GameObject hypeButton;
    

    private bool hasSeenExplanation = false;
    private bool isBustingRhymesDuringThisTimes = true;

    public float midRhymeWaitTime = 3f;
    WaitForSeconds midRhymeWait;
    public float endRhymeWaitTime = 3f;
    WaitForSeconds endRhymeWait;
    public float responseRhymeWaitTime = 0.5f;
    WaitForSeconds responseRhymeWait;


    public Couplet[] startCouplets;
    public Couplet[] tykeCouplets;
    public Couplet[] explanationCouplets;
    public Couplet[] hypeCouplets;
    public Couplet[] withoutFurtherAdoCouplets;
    private int coupletGroupCount = 0;

    void OnEnable()
    {
        EventManager.startTheBalancing += InitiateEndOfSpeech;
    }

    void OnDisable()
    {
        EventManager.startTheBalancing -= InitiateEndOfSpeech;
    }

    void Start()
    {
        midRhymeWait = new WaitForSeconds(midRhymeWaitTime);
        endRhymeWait = new WaitForSeconds(endRhymeWaitTime);
        responseRhymeWait = new WaitForSeconds(responseRhymeWaitTime);
        StartCoroutine(BeginCouplet(startCouplets));
    }

    void Update()
    {
        if (!isBustingRhymesDuringThisTimes)
        {
            isBustingRhymesDuringThisTimes = true;
            switch (coupletGroupCount)
            {
                case 1:
                    StartCoroutine(BeginCouplet(tykeCouplets));
                    break;
                case 2:
                    StartCoroutine(BeginCouplet(explanationCouplets));
                    break;
                case 3:
                    StartCoroutine(BeginCouplet(hypeCouplets));
                    break;

                default:
                    Debug.Log("No Couplet Group with value <" + coupletGroupCount + ">");
                    break;
            }
            
        }
    }

    private IEnumerator BeginCouplet(Couplet[] couplets)
    {
        int RNGsus = Mathf.FloorToInt(Random.Range(0, couplets.Length));

        textDisplayBoss.text = couplets[RNGsus].antecedent;
        

        if (couplets == hypeCouplets)
        {
            hypeButton.SetActive(true);
            startButton.SetActive(true);
        }
        else
        {
            coupletGroupCount++;
        }

        yield return midRhymeWait;

        textDisplayBoss.text = couplets[RNGsus].consequence;

        if (couplets[RNGsus].tykeResponse.Length != 0)
        {
            yield return responseRhymeWait;
            speechBubbleTyke.enabled = true;
            textDisplayResponse.enabled = true;
            textDisplayResponse.text = couplets[RNGsus].tykeResponse[0];
        }

        yield return endRhymeWait;
        speechBubbleTyke.enabled = false;
        textDisplayResponse.enabled = false;

        isBustingRhymesDuringThisTimes = false;
    }


    private void InitiateEndOfSpeech()
    {
        isBustingRhymesDuringThisTimes = true;
        StopAllCoroutines();
        StartCoroutine(WithoutFurtherAdoCouplet());
    }

    private IEnumerator WithoutFurtherAdoCouplet()
    {
        /*
        int RNGsus = Mathf.FloorToInt(Random.Range(0, couplets.Length));
        textDisplayBoss.text = couplets[RNGsus].antecedent;
        yield return midRhymeWait;
        textDisplayBoss.text = couplets[RNGsus].consequence;
        if (couplets[RNGsus].tykeResponse.Length != 0)
        {
            yield return responseRhymeWait;
            speechBubbleTyke.enabled = true;
            textDisplayResponse.enabled = true;
            textDisplayResponse.text = couplets[RNGsus].tykeResponse[0];
        }
        yield return endRhymeWait;
        speechBubbleTyke.enabled = false;
        textDisplayResponse.enabled = false;
        coupletGroupCount++;
        isBustingRhymesDuringThisTimes = false;
        */
        yield return null;
        EventManager.invokeSubscribersTo_LoadTheBalanceScene();
    }

}

[System.Serializable]
public class Couplet
{
    public string antecedent;
    public string consequence;
    public string[] tykeResponse;
}
