using UnityEngine;
using TMPro;
using System;

public class TimeDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private float nightDuration = 360;
    private float elapsedTime = 0f;
    private float startHour = 0;
    private float endHour = 6;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateTimerDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        UpdateTimerDisplay();
    }

    void UpdateTimerDisplay()
    {
        float gameHours = Mathf.Lerp(startHour, endHour, elapsedTime / nightDuration);

        int hours = Mathf.FloorToInt(gameHours);
        int minutes = Mathf.FloorToInt((gameHours - hours) * 60f);

        timerText.text = $"{hours:00}:{minutes:00}";
    }
}
