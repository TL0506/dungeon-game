using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource MusicSource;
    [SerializeField] AudioSource SFXSource;

    public AudioClip background;
    public AudioClip death;
    public AudioClip swordSwing;
    public AudioClip clownMusic;
    public AudioClip iceball;
    public AudioClip fireball;

    private void Start()
    {
        MusicSource.clip = background;
        MusicSource.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
