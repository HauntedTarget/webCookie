using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class OnLoad : MonoBehaviour
{
    [SerializeField] UnityEvent loadEvent;

    // Start is called before the first frame update
    void Start()
    {
        loadEvent.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
