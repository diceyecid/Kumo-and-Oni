using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip oniAttackSound, jumpSound, damagedSound, parrySound, leverSound, bowReleaseSound;
    static AudioSource aduioSrc;

    // Start is called before the first frame update
    void Start()
    {
        oniAttackSound = Resources.Load<AudioClip>("oniAttack");
        jumpSound = Resources.Load<AudioClip>("jump");
        damagedSound = Resources.Load<AudioClip>("damaged");
        parrySound = Resources.Load<AudioClip>("parry");
        bowReleaseSound = Resources.Load<AudioClip>("bowRelease");
        leverSound = Resources.Load<AudioClip>("lever");

        aduioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "oniAttack":
                aduioSrc.PlayOneShot(oniAttackSound);
                break;
            case "jump":
                aduioSrc.PlayOneShot(jumpSound);
                break;
            case "damaged":
                aduioSrc.PlayOneShot(damagedSound);
                break;
            case "parry":
                aduioSrc.PlayOneShot(parrySound);
                break;
            case "bowRelease":
                aduioSrc.PlayOneShot(bowReleaseSound);
                break;
            case "lever":
                aduioSrc.PlayOneShot(leverSound);
                break;
        }
    }
}
