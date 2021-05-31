using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metronome : MonoBehaviour
{
    public int bpm;
    double time = 0d;
    public int metronom = 0;
    public int accuracy = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 60d / bpm)
        {
            metronom = (metronom + 1) % 4;
            time -= 60d / bpm;
            accuracy = 10;
        }
    }

    void FixedUpdate()
    {
        if (accuracy > 0) accuracy--;
    }
}
