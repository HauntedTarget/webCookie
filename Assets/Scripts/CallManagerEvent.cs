using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CallManagerEvent : MonoBehaviour
{
    [SerializeField] List<string> GM_events = null;
    [SerializeField] UnityEvent SuccessEvent = null, FailEvent = null;

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

    public void CallEvents()
    {
        if (GM_events != null)
        {
            foreach (var gmEvent in GM_events)
            {
                Debug.Log("Invoking event: " + gmEvent);
                gameManager.Invoke(gmEvent, 0);
                Invoke(nameof(After), 0);
            }
        }
        else
        {
            Debug.Log("No events in variable for object: " + gameObject.name);
        }
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
