using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    Rigidbody2D rigid;
    public int nextMove;
    public Transform player;
    SpriteRenderer rand;
    Animator anim;


    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rand = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        Think();

    }
    
    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (rigid.velocity.x < 0) rand.flipX = false;
        else if (rigid.velocity.x > 0) rand.flipX = true;
        rigid.velocity = new Vector2(nextMove * 2, rigid.velocity.y);
    }

    void Think()
    {
        if(player.position.x - rigid.position.x < 5 && player.position.x - rigid.position.x > -5)
        { 
            if (player.position.x > rigid.position.x) nextMove = 1;
            else nextMove = -1;
                
        }
        else nextMove = Random.Range(-1, 2);

        AvoidFall();
        Invoke("Think", 2);
    }

    void AvoidFall()
    {
        Vector2 frontVec = new Vector2(rigid.position.x + nextMove, rigid.position.y);
        Debug.DrawRay(frontVec, Vector3.down, new Color(1, 1, 1));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("platform"));
        if (rayHit.collider == null)
        {
            nextMove *= -1;
        }
    }
}
