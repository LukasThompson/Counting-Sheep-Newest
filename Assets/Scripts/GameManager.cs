using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Tooltip("Shows if game has started or not.")]
    [SerializeField] private bool isGameActive;

    [Header("GUI Game Objects")]
    public GameObject titleScreen;
    public GameObject informationGUI;
    public GameObject eatingSheep;
    [Header("Spawnable Sheep")]
    public GameObject sheepControllerPrefab;

    public void StartGame(int difficulty)
    {
        titleScreen.SetActive(false);
        informationGUI.SetActive(true);
        eatingSheep.SetActive(false);
        isGameActive = true;
        InvokeRepeating(nameof(SpawnSheepWave), 2.0f, 2.0f);
    }

    public void EndGame()
    {
        CancelInvoke(nameof(SpawnSheepWave));
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SpawnSheepWave()
    {
                Instantiate(sheepControllerPrefab, transform.position, 
                    transform.rotation);
    }

}
