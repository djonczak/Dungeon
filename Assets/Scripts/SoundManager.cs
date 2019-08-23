using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource audioSource;

    public AudioClip[] meleeAttackSound;

    public AudioClip rangeAttackSound;

    public AudioClip weaponChangeSound;

    public AudioClip deathSound;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void AttackSound()
    {
        var random = Random.Range(0, meleeAttackSound.Length);
        audioSource.PlayOneShot(meleeAttackSound[random], 0.1f);
    }

    public void RangeSound()
    {
        audioSource.PlayOneShot(rangeAttackSound, 0.1f);
    }

    public void ChangeSound()
    {
        audioSource.PlayOneShot(weaponChangeSound, 0.1F);
    }

    public void DeathSound()
    {
        audioSource.PlayOneShot(deathSound, 0.1f);
    }
}


