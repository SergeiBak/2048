using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public Cell right;
    public Cell down;
    public Cell left;
    public Cell up;

    private void OnEnable()
    {
        GameController.slide += OnSlide;
    }

    private void OnDisable()
    {
        GameController.slide -= OnSlide;
    }

    private void OnSlide(string whatWasSent)
    {
        Debug.Log(whatWasSent);
    }
}
