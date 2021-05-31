using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    Rigidbody2D rigid;
    public int nextMove;
    public Transform player;
    Metronome rhythem;

    void Start()
    {
        rhythem = GameObject.Find("Metronome").GetComponent<Metronome>();
        rigid = GetComponent<Rigidbody2D>();
        Think();
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector3.Distance(player.position, transform.position) < 8f && rhythem.metronom == 2)
        {
            alert();
            Invoke("attack", 60 / rhythem.bpm);            
        }
        else
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

    //�����ϱ� �� ���� ��, �Ӹ� ���� ����ǥ�� ���� ����
    void alert()
    {
        //��������Ʈ ���ϴ� ��� �ִϸ��̼� ����ֱ�
    }
    
    void attack()
    {

    }
}
