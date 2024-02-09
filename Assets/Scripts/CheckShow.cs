using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckShow : MonoBehaviour
{
    public void OnShow(bool show)
    {
        gameObject.SetActive(show);
    }
}
