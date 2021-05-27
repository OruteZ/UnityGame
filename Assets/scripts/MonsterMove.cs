using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    Rigidbody2D rigid;
    public int nextMove;
    public Transform player;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        Think();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y);

    }

    void Think()
    {
        if(player.position.y == rigid.position.y)
        {
            if (player.position.x > rigid.position.x) nextMove = 1;
            else nextMove = -1;
        }
        else nextMove = Random.Range(-1, 2);

        Invoke("Think", 2);
    }
}
