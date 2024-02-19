using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnAutoEvent : MonoBehaviour
{
    [SerializeField, Range(1, 25)] float timerEnd = 5;
    [SerializeField] UnityEvent GM_events = null;
    [SerializeField] UnityEvent SuccessEvent = null, FailEvent = null;
    private float timer = 0;

    GameManager gameManager = null;

    private void Start()
    {
        try
        {
            Debug.Log("GameManager found.");
            gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        }
        catch (Exception)
        {
            Debug.LogError("GameManager not found! Error will be caused by further action!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timerEnd) CallEvents();
    }

    public void CallEvents()
    {
        if (GM_events != null)
        {
            Debug.Log("Invoking event: " + nameof(GM_events));
            GM_events.Invoke();
            Invoke(nameof(After), 0);
        }
        else
        {
            Debug.Log("No events in variable for object: " + gameObject.name);
        }

        timer = 0;
    }

    public void After()
    {
        if (gameManager.Quiry)
        {
            gameManager.Quiry = false;
            if (SuccessEvent != null)
            {
                SuccessEvent.Invoke();
            }
        }
        else
        {
            if (FailEvent != null)
            {
                FailEvent.Invoke();
            }
        }
    }
}
