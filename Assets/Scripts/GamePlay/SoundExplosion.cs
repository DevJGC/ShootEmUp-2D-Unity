using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundExplosion : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip soundExplosion;
    
    void Start()
    {
        
    }


    void Update()
    {
        
    }

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
