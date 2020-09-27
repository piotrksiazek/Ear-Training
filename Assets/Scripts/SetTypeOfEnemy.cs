﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTypeOfEnemy : MonoBehaviour
{
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
    public List<AudioClip> IntervalsList;
    private AudioSource audioSource;
    public int EnemyIndex;

    void Start()
    {
        IntervalsList = GetIntervals();
        audioSource = GetComponent<AudioSource>();
        DetermineTypeOfEnemy(audioSource);
        EnemyIndex = CommonData.Instance.CurrentEnemyIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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

    private int GetRandomIntervalIndex()
    {
        int randomIndex = Random.Range(0, IntervalsList.Count + 1);
        return randomIndex;
    }

    private void DetermineTypeOfEnemy(AudioSource audioSource)
    {
        switch (GetRandomIntervalIndex())
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
    }
}