using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private float timeSeconds;
    private const float moveWait = 2.0f;
    private bool isPaused;
    private Camera mainCam;
    [SerializeField] private Transform[] transformArray;

    private void Start()
    {
        mainCam.orthographic = true;
        mainCam.orthographicSize = 2.5f;
        ResetTime();
    }

    private void Update()
    {
        timeSeconds += Time.deltaTime;
        int seconds = (int)timeSeconds % 60;
        
        if (Input.GetKeyDown(KeyCode.Space) && !isPaused)
        {
            isPaused = true;
            Time.timeScale = 0.0f;
            Debug.Log("Spacebar pressed, we paused time");
        }
        else if (Input.GetKeyDown(KeyCode.Space) && isPaused)
        {
            isPaused = false;
            Time.timeScale = 1.0f;
            Debug.Log("Spacebar pressed, we started time");
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            ResetTime();
        }
       
        Debug.Log(seconds);
        
        StartCoroutine(RandomRoutine(moveWait));
    }
    
    private void ResetTime()
    {
        timeSeconds = 0.0f;
    }

    private void MoveObject()
    {
        
    }

    IEnumerator RandomRoutine(float value)
    {
        //do something
        yield return new WaitForSeconds(value);
    }
}
