using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundExplosion : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource; // audio source
    [SerializeField] private AudioClip soundExplosion; // sound explosion

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    // Método para reproducir sonido de explosión
    public void PlaySoundExplosion()
    {
        // play sound si no está sonando
       // if (!audioSource.isPlaying)
       // {
            audioSource.clip = soundExplosion;
            audioSource.Play();
       // }

        
    }
}
