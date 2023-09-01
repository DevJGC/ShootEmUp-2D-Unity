using System.Collections;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private int levelMaster = 1; // Comienza por el nivel 1
    [SerializeField] private GameObject panelLevelCanvas; // panel level canvas
    [SerializeField] private PanelLevel panelLevelScript;   // panel level script

    [SerializeField] private const float timeBetweenLevels = 120f; // 2 minutos = 120 segundos

    // audio
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;

    // spawners levels
    [SerializeField] private GameObject[] spawnerLevels; // spawners levels

    void Start()
    {
        //  Activar el spawner correspondiente al nivel.
        UpdateLevelPanel();
        StartCoroutine(LevelTimer());
    }

    //  Corrutina para cambiar de nivel cada 2 minutos.
    private IEnumerator LevelTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenLevels);
            ChangeLevel();
        }
    }

    //  Método para cambiar de nivel.
    private void ChangeLevel()
    {
        levelMaster++;
        UpdateLevelPanel();
        ActiveSpawnerLevels(); // Activar el spawner correcto después de cambiar el nivel.
    }

    //  Método para actualizar el panel de nivel.
    private void UpdateLevelPanel()
    {
        panelLevelScript.level = levelMaster;
        panelLevelCanvas.SetActive(true);
        Invoke("ClosePanelLevel", 2f);
        audioSource.PlayOneShot(audioClip);
    }

    //  Método para cerrar el panel de nivel.
    private void ClosePanelLevel()
    {
        panelLevelCanvas.SetActive(false);
    }

    //  Método para activar el spawner correspondiente al nivel.
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
