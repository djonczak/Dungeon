using UnityEngine;

public class SoundManager : MonoBehaviour, IPlaySound
{
    private AudioSource _audioSource;

    public AudioClip[] meleeAttackSound;
    public AudioClip rangeAttackSound;
    public AudioClip weaponChangeSound;
    public AudioClip deathSound;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void AttackSound()
    {
        var random = Random.Range(0, meleeAttackSound.Length);
        _audioSource.PlayOneShot(meleeAttackSound[random], 0.1f);
    }

    public void RangeSound()
    {
        _audioSource.PlayOneShot(rangeAttackSound, 0.1f);
    }

    public void ChangeSound()
    {
        _audioSource.PlayOneShot(weaponChangeSound, 0.1F);
    }

    public void DeathSound()
    {
        _audioSource.PlayOneShot(deathSound, 0.1f);
    }
}


