using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip playerWalkSound, playerGunSound, playerSubGunSound, flyingEnemySound, walkingEnemySound;
    static AudioSource audioSrc;

    void Start()
    {
        playerWalkSound = Resources.Load<AudioClip>("Walk");
        playerGunSound = Resources.Load<AudioClip>("Gun");
        playerSubGunSound = Resources.Load<AudioClip>("Laser");
        flyingEnemySound = Resources.Load<AudioClip>("FlyingEnemy2");
        walkingEnemySound = Resources.Load<AudioClip>("GroundEnemy");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "Gun":
                audioSrc.PlayOneShot(playerGunSound);
                break;
            case "Laser":
                audioSrc.PlayOneShot(playerSubGunSound);
                break;
            case "Walk":
                audioSrc.PlayOneShot(playerWalkSound);
                break;
            case "FlyingEnemy2":
                audioSrc.PlayOneShot(flyingEnemySound);
                break;
            case "GroundEnemy":
                audioSrc.PlayOneShot(walkingEnemySound);
                break;
        }
    }
}
