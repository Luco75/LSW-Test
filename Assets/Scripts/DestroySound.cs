using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This script is added to the sounds when they are created
The AudioSource component is added previously, so you can always create an instance of it
Through this script the sound is removed from the scene once the playback of the audio clip is complete
*/

public class DestroySound : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(DestroyThis(audioSource.clip.length));
    }

    IEnumerator DestroyThis(float s)
    {
        yield return new WaitForSeconds(s);
        Destroy(gameObject);
    }
}
