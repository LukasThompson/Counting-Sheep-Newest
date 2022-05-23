using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    public TMP_Text savedText;
    public TMP_Text deadText;
    public int savedCount = 0;
    private int deadCount = 0;

    private void Start()
    {
        savedCount = 0;
        deadCount = 0;
    }

    public void AddSavedSheep()
    {
        savedCount++;
        savedText.text = "Saved: " + savedCount;
    }
    public void AddDeadSheep()
    {
        deadCount++;
        deadText.text = "Dead: " + deadCount;
    }
}
