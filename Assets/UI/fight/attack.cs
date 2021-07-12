using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack: MonoBehaviour
{
    Metronome rhythem;

    // Start is called before the first frame update
    void Start()
    {
        rhythem = GameObject.Find("Metronome").GetComponent<Metronome>();
        Invoke("delete", 60 / rhythem.bpm);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void delete()
    {
        Destroy(gameObject);
    }
}
