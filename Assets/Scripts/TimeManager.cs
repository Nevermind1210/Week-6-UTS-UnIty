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
    private bool isCount;
    [SerializeField] private Transform[] transformArray;

    private void Start()
    {
        mainCam = GetComponent<Camera>();
        mainCam.orthographic = true;
        mainCam.orthographicSize = 2.5f;
        ResetTime();
    }

    private void Update()
    {
        timeSeconds += Time.deltaTime;
        int seconds = (int)timeSeconds % 60;
        Debug.Log(seconds);
        
        InvokeRepeating("MoveObject", 0.0f, 2.0f);
        
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
        
        StartCoroutine(RandomRoutine(moveWait));
    }
    
    private void ResetTime()
    {
        timeSeconds = 0.0f;
    }

    private void MoveObject()
    {
        if (!isCount)
        {
            isCount = true;
            float tempPosy = transformArray[0].position.y;
            transformArray[0].position = new Vector3(transformArray[0].position.x, transformArray[1].position.y, 0);
            transformArray[1].position = new Vector3(transformArray[1].position.x, tempPosy, 0);
        }
        else if (isCount)
        {
            isCount = false;
            float tempPosy = transformArray[0].position.y;
            transformArray[0].position = new Vector3(transformArray[0].position.x, transformArray[1].position.y, 0);
            transformArray[1].position = new Vector3(transformArray[1].position.x,tempPosy, 0);
        }
    }

    IEnumerator RandomRoutine(float value)
    {
        //do something
        yield return new WaitForSeconds(value);
    }
}
