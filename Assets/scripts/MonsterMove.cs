using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    Rigidbody2D rigid;
    public int nextMove;
    public Transform player;
    Metronome rhythem;
    public GameObject Alert;
    public GameObject Atteck;
    SpriteRenderer rand;
    Animator anim;


    void Start()
    {
        rhythem = GameObject.Find("Metronome").GetComponent<Metronome>();
        rigid = GetComponent<Rigidbody2D>();
        rand = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        Think();

    }
    
    // Update is called once per frame
    void Update()
    {
        Vector2 frontVec = new Vector2(rigid.position.x + nextMove, rigid.position.y);
        Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("platform"));
        if (rhythem.metronom == 2)
        {
            alert();
            rigid.velocity = new Vector2(0, 0);


        }
        else if (rhythem.metronom == 3)
        {
            attack();
            rigid.velocity = new Vector2(0, 0);
        }
        else if(rayHit.collider == null)
        {
            anim.SetBool("isAttacking", false);
            nextMove *= -1;
            rigid.velocity = new Vector2(nextMove, rigid.velocity.y);
        }
        else
        {
            anim.SetBool("isAttacking", false);
            rigid.velocity = new Vector2(nextMove, rigid.velocity.y);
        }
    }

    void FixedUpdate()
    {
        if (rigid.velocity.x < 0) rand.flipX = false;
        else if (rigid.velocity.x > 0) rand.flipX = true;
    }

    void Think()
    {
        if(player.position.x - rigid.position.x < 5 && player.position.x - rigid.position.x > -5)
        {
            if (player.position.x > rigid.position.x) nextMove = 1;
            else nextMove = -1;
        }
        else nextMove = Random.Range(-1, 2);

        Invoke("Think", 2);
    }

    //공격하기 한 박자 전, 머리 위에 물음표를 띄우는 행위
    void alert()
    {
        Instantiate(Alert, new Vector2(rigid.position.x, rigid.position.y+1), Quaternion.identity);
    }
    
    void attack()
    {
        if(rand.flipX) Instantiate(Atteck, new Vector2(rigid.position.x+1, rigid.position.y), Quaternion.identity);
        else Instantiate(Atteck, new Vector2(rigid.position.x - 1, rigid.position.y), Quaternion.Euler(0,0,180));
        anim.SetBool("isAttacking", true);

    }

    void Killmob()
    {

    }
}
