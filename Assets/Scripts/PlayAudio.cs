using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    AudioSource audioSource;
    AudioClip audioClip;
    private bool isPlayingAdio = false;
    [SerializeField]
    private float fadeInDuration = default;
    [SerializeField]
    private float fadeOutDuration = default;

    RaycastHit2D hit;
    private bool isFirstInLine;
    private int layerMask;

    private void Start()
    {
        layerMask = 1 << 8;
        layerMask = ~layerMask;
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0;
        audioClip = audioSource.clip;
    }

    void Update()
    {
        PlayAudioIfPlayerBelow();
    }

    private void PlayAudioIfPlayerBelow()
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
                    StartCoroutine("fadeIn");
                    
                }          
            }

            else
            {
                if (audioSource.isPlaying)
                    StartCoroutine("fadeOut");
            }
        }
    }

    IEnumerator fadeIn()
    {
        isPlayingAdio = true;
        while (audioSource.isPlaying)
        {
            if(audioSource.volume < 1)
            {
                audioSource.volume += Time.deltaTime / fadeInDuration;
            }
            yield return null;
        }
        audioSource.volume = 1;
    }

    IEnumerator fadeOut()
    {
        while (audioSource.volume > 0)
        {   
            audioSource.volume -= Time.deltaTime / fadeOutDuration;
            
            yield return null;
            //audioSource.Stop();
        }
        audioSource.Stop(); // Tutaj wkleiłem
        isPlayingAdio = false;
        audioSource.volume = 0;
    }


}
