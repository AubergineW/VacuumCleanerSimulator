using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    private Vector3 _startRotation;
    private void Start()
    {
        _startRotation = transform.eulerAngles;
    }
    private void Update()
    {
        transform.eulerAngles = _startRotation;
    }
}
