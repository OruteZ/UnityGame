using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelSaw : MonoBehaviour
{
    Rigidbody2D rigid;
    int nextMove = 1;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rigid.velocity = new Vector2(0, 4 * nextMove);
    }

    // Update is called once per frame
    void Awake()
    {
 
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer ==6)
        {
            nextMove *= -1;
        }
    }
}
