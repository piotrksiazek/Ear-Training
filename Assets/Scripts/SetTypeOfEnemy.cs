﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTypeOfEnemy : MonoBehaviour
{   // Intervals in audio clip
    public AudioClip PerfectUnison;
    public AudioClip MinorSecond;
    public AudioClip MajorSecond;
    public AudioClip MinorThird;
    public AudioClip MajorThird;
    public AudioClip PerfectFourth;
    public AudioClip Tritone;
    public AudioClip PerfectFifth;
    public AudioClip MinorSixth;
    public AudioClip MajorSixth;
    public AudioClip MinorSeventh;
    public AudioClip MajorSeventh;
    public AudioClip PerfectOctave;

    // Lists containing audio clips with intervals and interval names in string format
    public List<AudioClip> IntervalsList;
    public List<string> IntervalsListString;
    public Dictionary<string, AudioClip> IntervalsDictionary;


    private AudioSource audioSource;

    public int EnemyIndex;

    // Text on enemy with interval name. It can match inteval played by enemy but can be a lie as well
    [SerializeField]
    private Text intervalGuessUI = default;
    public string intervalGuess;

    public bool isALiar;


    void Start()
    {
        IntervalsList = GetIntervals();
        IntervalsListString = GetIntervalsString();
        IntervalsDictionary = getIntervalsDictionary(IntervalsListString, IntervalsList);
        audioSource = GetComponent<AudioSource>();
        DetermineTypeOfEnemy(audioSource);
        intervalGuessUI.text = intervalGuess;
        checkIfIsALiar();
        EnemyIndex = CommonData.Instance.CurrentEnemyIndex;
    }

    private void Update()
    {
        textUIFollowObject();
    }

    #region IntervalsList, ListString and Dictionary initialization
    // Used to initialise a list and assign it to a variable in Start() method
    private List<AudioClip> GetIntervals()
    {
        var intervalsList = new List<AudioClip>() { PerfectUnison,
                                                    MinorSecond,
                                                    MajorSecond,
                                                    MinorThird,
                                                    MajorThird,
                                                    PerfectFourth,
                                                    Tritone,
                                                    PerfectFifth,
                                                    MinorSixth,
                                                    MajorSixth,
                                                    MinorSeventh,
                                                    MajorSeventh,
                                                    PerfectOctave};
        return intervalsList;
    }

    // Used to initialise a list and assign it to a variable in Start() method
    public List<string> GetIntervalsString()
    {
        var intervalsListString = new List<string>(){"PerfectUnison",
                                                     "MinorSecond",
                                                     "MajorSecond",
                                                     "MinorThird",
                                                     "MajorThird",
                                                     "PerfectFourth",
                                                     "Tritone",
                                                     "PerfectFifth",
                                                     "MinorSixth",
                                                     "MajorSixth",
                                                     "MinorSeventh",
                                                     "MajorSeventh",
                                                     "PerfectOctave"};
                                                                    
        return intervalsListString;
    }

    private Dictionary<string, AudioClip> getIntervalsDictionary(List<string> intervalsListString, List<AudioClip> intervalsList)
    {
        var intervalsDictionary = new Dictionary<string, AudioClip>();

        for(int i = 0; i < intervalsListString.Count; i++)
        {
            intervalsDictionary.Add(intervalsListString[i], intervalsList[i]);
        }

        return intervalsDictionary;
    }

    #endregion

    #region Randomize IntervalGuess and played audioclip
    // Generates a random number corresponding with intervalsList length
    private int GetRandomIntervalIndex()
    {
        int randomIndex = Random.Range(0, IntervalsList.Count - 1);
        return randomIndex;
    }

    // Generates intervalGuess index that has 1/2 chance for being the same as tag and audio clip
    private void SetIntervalGuess(int randomIntervalIndex)
    {
        List<string> intervalListStringCopy = new List<string>(IntervalsListString); 
        float chance = Random.Range(0f, 1f);
        if(chance > 0.5)
        {
            intervalGuess = transform.tag;
        }
        else
        {
            intervalListStringCopy.Remove(transform.tag); // if chance is below 0.5 we want to have separate list without item chosen in DetermineTypeOfEnemy
            intervalGuess = intervalListStringCopy[Random.Range(0, intervalListStringCopy.Count - 1)];
        }
    }
    #endregion

    private void checkIfIsALiar()
    {
        if(transform.tag == intervalGuess)
        {
            isALiar = false;
        }
        else
        {
            isALiar = true;
        }
    }

    private void textUIFollowObject()
    {
        Vector2 textPosition = Camera.main.WorldToScreenPoint(transform.position);
        intervalGuessUI.transform.position = textPosition;
    }
    // Primary method of the class. Handles tag, audioclip and intevalGuess assignment
    private void DetermineTypeOfEnemy(AudioSource audioSource)
    {
        int randomIntervalIndex = GetRandomIntervalIndex();
        switch (randomIntervalIndex)
        {
            case 0:
                transform.tag = "PerfectUnison";
                audioSource.clip = IntervalsList[0];
                break;
            case 1:
                transform.tag = "MinorSecond";
                audioSource.clip = IntervalsList[1];
                break;
            case 2:
                transform.tag = "MajorSecond";
                audioSource.clip = IntervalsList[2];
                break;
            case 3:
                transform.tag = "MinorThird";
                audioSource.clip = IntervalsList[3];
                break;
            case 4:
                transform.tag = "MajorThird";
                audioSource.clip = IntervalsList[4];
                break;
            case 5:
                transform.tag = "PerfectFourth";
                audioSource.clip = IntervalsList[5];
                break;
            case 6:
                transform.tag = "Tritone";
                audioSource.clip = IntervalsList[6];
                break;
            case 7:
                transform.tag = "PerfectFifth";
                audioSource.clip = IntervalsList[7];
                break;
            case 8:
                transform.tag = "MinorSixth";
                audioSource.clip = IntervalsList[8];
                break;
            case 9:
                transform.tag = "MajorSixth";
                audioSource.clip = IntervalsList[9];
                break;
            case 10:
                transform.tag = "MinorSeventh";
                audioSource.clip = IntervalsList[10];
                break;
            case 11:
                transform.tag = "MajorSeventh";
                audioSource.clip = IntervalsList[11];
                break;
            case 12:
                transform.tag = "PerfectOctave";
                audioSource.clip = IntervalsList[12];
                break;

        }
        SetIntervalGuess(randomIntervalIndex);
    }
}
