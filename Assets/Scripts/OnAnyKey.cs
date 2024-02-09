using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnAnyKey : MonoBehaviour
{
    [SerializeField] UnityEvent contEvent;

    void Update()
    {
        if (Input.anyKeyDown) contEvent.Invoke();
    }
}
