using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundManager
{
    public static void CreateSound(AudioClip clip, Vector3 position, bool variablePitch, float volume)
    {
        GameObject sonido = new GameObject("Sonido");
        AudioSource audioSource = sonido.AddComponent<AudioSource>();
        sonido.transform.position = position;
        audioSource.clip = clip;
        if (variablePitch) audioSource.pitch = 1 + Random.Range(-0.1f, 0.1f);
        audioSource.volume = volume;
        audioSource.Play();
        sonido.AddComponent<DestroySound>();
    }
}
