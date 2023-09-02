using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] player;   // objetos player

    [SerializeField] private GameObject canvasGameOver;     // canvas game over

    // velocidad de resta de items
    [SerializeField] private float restaItemShoot; //   resta item multiple para icono canvas
    [SerializeField] private float restaItemBomb; //    resta item bomb para icono canvas
    [SerializeField] private float restaItemShield; //  resta item shield para icono canvas

    [SerializeField] private Image fillMultiple; // fill multiple icono canvas
    bool multiple;  // multiple true or false

    [SerializeField] private Image fillBomb;    // fill bomb icono canvas
    bool bomb;  // bomb true or false

    [SerializeField] private Image fillShield;  // fill shield icono canvas
    bool shield;    // shield true or false

    // audio source
    [SerializeField] AudioSource audioSource;
    // audio clip
    [SerializeField] AudioClip audioClipItem;

    //temblor camara
    [SerializeField] float duration = 0.2f;  // Duración del temblor en segundos
    [SerializeField] float magnitude = 0.2f;  // Magnitud del temblor

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
            fillMultiple.fillAmount -= restaItemShoot; //   resta item multiple para icono canvas
            // if multiple <= 0 set multiple false
            if (fillMultiple.fillAmount <= 0f)
            {
                multiple = false;
                player[0].GetComponent<PlayerShoot>().DisableShoot1(); // disable shoot 2 (multiple)
            }
        }

        // if bomb true resta 0.01f fillbomb
        if (bomb && fillBomb.fillAmount > 0f)
        {
            fillBomb.fillAmount -= restaItemBomb; //    resta item bomb para icono canvas
            // if bomb <= 0 set bomb false
            if (fillBomb.fillAmount <= 0f)
            {
                bomb = false;
                player[0].GetComponent<PlayerShoot>().DisableShootBoomb();  // disable bomb
            }
        }

        // if shield true resta 0.01f fillshield
        if (shield && fillShield.fillAmount > 0f)
        {
            fillShield.fillAmount -= restaItemShield;   //  resta item shield para icono canvas
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

    // temblor de cámara
    public void ShakeCamera()
    {
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        Vector3 originalPosition = Camera.main.transform.position;
        float elapsed = 0.0f;
        float randomStart = Random.Range(-1000.0f, 1000.0f);

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float percentComplete = elapsed / duration;

            // Genera valores aleatorios usando Perlin noise
            float offsetX = Mathf.PerlinNoise(randomStart, Time.time * 1.0f) * 2.0f - 1.0f;
            float offsetY = Mathf.PerlinNoise(randomStart + 1.0f, Time.time * 1.0f) * 2.0f - 1.0f;

            offsetX *= magnitude * (1.0f - percentComplete);
            offsetY *= magnitude * (1.0f - percentComplete);

            Camera.main.transform.position = new Vector3(originalPosition.x + offsetX, originalPosition.y + offsetY, originalPosition.z);

            yield return null;
        }

        // Restablecer la posición original de la cámara
        Camera.main.transform.position = originalPosition;
    }
    

    // activa disparo especial
    public void Shoot2Active()
    {
        player[0].GetComponent<PlayerShoot>().EnableShoot1();
        fillMultiple.fillAmount = 1f;
        multiple = true;
        // play sound
        audioSource.PlayOneShot(audioClipItem);
    }

    //  desactiva disparo especial
    public void Shoot2Deactive()
    {
        player[0].GetComponent<PlayerShoot>().DisableShoot1();
        fillMultiple.fillAmount = 0f;
        multiple = false;
    }

    //  activa bomba
    public void BoombActive()
    {
        player[0].GetComponent<PlayerShoot>().EnableShootBoomb();
        fillBomb.fillAmount = 1f;
        bomb = true;
        // play sound
        audioSource.PlayOneShot(audioClipItem);
    }

    //  desactiva bomba
    public void BoombDeactive()
    {
        player[0].GetComponent<PlayerShoot>().DisableShootBoomb();
        fillBomb.fillAmount = 0f;
        bomb = false;
    }

    //  activa escudo
    public void ShieldActive()
    {
        player[1].SetActive(true);
        fillShield.fillAmount = 1f;
        shield = true;
        // play sound
        audioSource.PlayOneShot(audioClipItem);
       
    }

    //  desactiva escudo
    public void ShieldDeactive()
    {
        player[1].SetActive(false);
        fillShield.fillAmount = 0f;
        shield = false;
        // playerEnergy.energy = 0f;
        player[0].GetComponent<PlayerEnergy>().RestaurarEnergia();
    }
}
