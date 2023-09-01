using System.Collections;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private int levelMaster = 1; // Asegúrate de que levelMaster inicie en 1 o el valor que desees.
    [SerializeField] private GameObject panelLevelCanvas;
    [SerializeField] private PanelLevel panelLevelScript;

    [SerializeField] private const float timeBetweenLevels = 120f; // 2 minutos = 120 segundos

    // audio
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;

    // spawners levels
    [SerializeField] private GameObject[] spawnerLevels;

    void Start()
    {
        UpdateLevelPanel();
        StartCoroutine(LevelTimer());
    }

    private IEnumerator LevelTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenLevels);
            ChangeLevel();
        }
    }

    private void ChangeLevel()
    {
        levelMaster++;
        UpdateLevelPanel();
        ActiveSpawnerLevels(); // Activar el spawner correcto después de cambiar el nivel.
    }


    private void UpdateLevelPanel()
    {
        panelLevelScript.level = levelMaster;
        panelLevelCanvas.SetActive(true);
        Invoke("ClosePanelLevel", 2f);
        audioSource.PlayOneShot(audioClip);
    }

    private void ClosePanelLevel()
    {
        panelLevelCanvas.SetActive(false);
    }

    public void ActiveSpawnerLevels()
    {
        // Desactivar todos los spawners antes de activar el correspondiente.
        foreach (GameObject spawner in spawnerLevels)
        {
            spawner.SetActive(false);
        }

        // Usar switch-case para activar el spawner correspondiente al nivel.
        switch (levelMaster)
        {
            case 1:
                spawnerLevels[0].SetActive(true);
                break;
            case 2:
                spawnerLevels[1].SetActive(true);
                break;
            case 3:
                spawnerLevels[2].SetActive(true);
                break;
            case 4:
                spawnerLevels[3].SetActive(true);
                break;
            case 5:
                spawnerLevels[4].SetActive(true);
                break;
            case 6:
                spawnerLevels[5].SetActive(true);
                break;
            case 7:
                spawnerLevels[6].SetActive(true);
                break;
            case 8:
                spawnerLevels[7].SetActive(true);
                break;
            default:
                Debug.LogWarning("No hay un spawner definido para el nivel " + levelMaster);
                break;
        }
    }

}
