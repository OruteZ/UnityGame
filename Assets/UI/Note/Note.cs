using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public float noteSpeed;

    // Update is called once per frame
    void Update() => transform.localPosition += Vector3.right * noteSpeed * Time.deltaTime;

}
