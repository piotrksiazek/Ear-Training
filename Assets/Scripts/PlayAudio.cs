using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    AudioSource audioSource;
    AudioClip audioClip;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioClip = audioSource.clip;
    }

    void Update()
    {
        if (CommonData.Instance.PlayerMovePointX == transform.position.x)
        {
            print($"Jestem pod przeciwnikiem {transform.tag}");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            audioSource.PlayOneShot(audioClip);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        audioSource.Stop();
    }
}
