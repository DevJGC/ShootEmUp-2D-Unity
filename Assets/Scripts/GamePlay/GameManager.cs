using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] player;

    [SerializeField] private GameObject canvasGameOver;

    // velocidad de resta de items
    [SerializeField] private float restaItemShoot;
    [SerializeField] private float restaItemBomb;
    [SerializeField] private float restaItemShield;

    [SerializeField] private Image fillMultiple;
    bool multiple;

    [SerializeField] private Image fillBomb;
    bool bomb;

    [SerializeField] private Image fillShield;
    bool shield;

    // audio source
    [SerializeField] AudioSource audioSource;
    // audio clip
    [SerializeField] AudioClip audioClipItem;

    void Start()
    {
        
    }
    

    void Update()
    {
        // if player no existe return
        if (player[0] == null)
        {
            return;
        }

        // if multiple true resta 0.01f fillmultiple
        if (multiple && fillMultiple.fillAmount > 0f)
        {
            fillMultiple.fillAmount -= restaItemShoot;
            // if multiple <= 0 set multiple false
            if (fillMultiple.fillAmount <= 0f)
            {
                multiple = false;
                player[0].GetComponent<PlayerShoot>().DisableShoot1();
            }
        }

        // if bomb true resta 0.01f fillbomb
        if (bomb && fillBomb.fillAmount > 0f)
        {
            fillBomb.fillAmount -= restaItemBomb;
            // if bomb <= 0 set bomb false
            if (fillBomb.fillAmount <= 0f)
            {
                bomb = false;
                player[0].GetComponent<PlayerShoot>().DisableShootBoomb();
            }
        }

        // if shield true resta 0.01f fillshield
        if (shield && fillShield.fillAmount > 0f)
        {
            fillShield.fillAmount -= restaItemShield;
            // if shield <= 0 set shield false
            if (fillShield.fillAmount <= 0f)
            {
                shield = false;
                player[1].SetActive(false);
                ShieldDeactive();
            }
        }


    }

    // destroy player
    public void DestroyPlayer()
    {
        canvasGameOver.SetActive(true);
        Destroy(player[0],1f);
    }

    // public void Shake camera
    public void ShakeCamera()
    {
        // dot tween shake camera
        Camera.main.DOShakePosition(0.5f, 0.5f, 10, 90, true);
    }

    public void Shoot2Active()
    {
        player[0].GetComponent<PlayerShoot>().EnableShoot1();
        fillMultiple.fillAmount = 1f;
        multiple = true;
        // play sound
        audioSource.PlayOneShot(audioClipItem);
    }

    public void Shoot2Deactive()
    {
        player[0].GetComponent<PlayerShoot>().DisableShoot1();
        fillMultiple.fillAmount = 0f;
        multiple = false;
    }

    public void BoombActive()
    {
        player[0].GetComponent<PlayerShoot>().EnableShootBoomb();
        fillBomb.fillAmount = 1f;
        bomb = true;
        // play sound
        audioSource.PlayOneShot(audioClipItem);
    }

    public void BoombDeactive()
    {
        player[0].GetComponent<PlayerShoot>().DisableShootBoomb();
        fillBomb.fillAmount = 0f;
        bomb = false;
    }

    public void ShieldActive()
    {
        player[1].SetActive(true);
        fillShield.fillAmount = 1f;
        shield = true;
        // play sound
        audioSource.PlayOneShot(audioClipItem);
       
    }

    public void ShieldDeactive()
    {
        player[1].SetActive(false);
        fillShield.fillAmount = 0f;
        shield = false;
        // playerEnergy.energy = 0f;
        player[0].GetComponent<PlayerEnergy>().RestaurarEnergia();
    }
}
