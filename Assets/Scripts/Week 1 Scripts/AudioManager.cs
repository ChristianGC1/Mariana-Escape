using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioClip Explosion, DamageTwo;
    static AudioSource audioSrc;

    void Start()
    {
        Explosion = Resources.Load<AudioClip>("Explosion");
        DamageTwo = Resources.Load<AudioClip>("DamageTwo");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Explosion":
                audioSrc.PlayOneShot(Explosion);
                break;
            case "DamageTwo":
                audioSrc.PlayOneShot(DamageTwo);
                break;
        }
    }
}
