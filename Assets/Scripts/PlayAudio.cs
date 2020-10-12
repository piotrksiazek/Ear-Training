using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    AudioSource audioSource;
    AudioClip audioClip;
    private bool isPlayingAdio = false;

    RaycastHit2D hit;
    private bool isFirstInLine;
    private int layerMask;

    private void Start()
    {
        layerMask = 1 << 8;
        layerMask = ~layerMask;
        audioSource = GetComponent<AudioSource>();
        audioClip = audioSource.clip;
    }

    void Update()
    {
        PlayAudioIfPlayerBelow();
    }

    public void PlayAudioIfPlayerBelow()
    {
        hit = Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity, layerMask);

        if (hit)
        {
            isFirstInLine = GetComponent<ActivateDeactivateEnemy>().IsFirstInLine;
            
            if(hit.transform.tag == "Player" && isFirstInLine)
            {
                if(!isPlayingAdio)
                {
                    audioSource.PlayOneShot(audioClip);
                    isPlayingAdio = true;
                }
                    

                
            }

            else
            {
                isPlayingAdio = false;
                audioSource.Stop();
            }
        }
    }
}
