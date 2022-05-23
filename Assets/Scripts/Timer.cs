using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float countDown = 60.00f;
    public TMPro.TMP_Text timerText;
    public GameManager gameManager;
    private Counter counter;

    private void Start()
    {
        counter = FindObjectOfType<Counter>();
    }
    void Update()
    {
        if (countDown > 0)
        {
            countDown -= Time.deltaTime;
        }

        double time = System.Math.Round(countDown, 0);
        timerText.text = time.ToString();

        if (countDown < 0)
        {
            Debug.Log("Completed");
            gameManager.EndGame();
        }

        //if (counter.savedCount % 10 == 0)
        //{
        //    countDown += 10;
        //}
    }
}
