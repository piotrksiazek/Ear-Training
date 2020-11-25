using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathRay : MonoBehaviour
{
    RaycastHit2D hit;
    int layerMask;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        layerMask = 1 << 9;
        layerMask = ~layerMask;
    }
    private void Update() => CastDeathRay();

    private void CastDeathRay()
    {
        hit = Physics2D.Raycast(transform.position, Vector2.right, Mathf.Infinity, layerMask);

        if (hit)
        {
            audioSource.PlayOneShot(audioSource.clip);
            CommonData.Instance.Points--;
            Destroy(hit.transform.gameObject);
        }


    }
}
