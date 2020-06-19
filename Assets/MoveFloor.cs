using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MoveFloor : MonoBehaviour
{
    // stim characteristics
    public float amplitude;
    private float time_period = 2;
    public bool ML = true;
    public bool AP = false;

    private Vector3 newPosition;
    private Vector3 _startPosition;
    private float startTime;
    private float t;

    void Start()
    {
        // start position of object
        _startPosition = transform.position;

        startTime = Time.time;

    }

    void FixedUpdate()
    {
        if (ML)
        {
            transform.position = _startPosition + new Vector3(Mathf.Sin(((Mathf.PI * 2) / time_period) * Time.time) * amplitude, 0.0f, 0.0f);
        }

        if (AP)
        {
            transform.position = _startPosition + new Vector3(0.0f, 0.0f, Mathf.Sin(((Mathf.PI * 2) / time_period) * Time.time) * amplitude);
        }
    }

}
