using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFight : MonoBehaviour
{

    Metronome rhythem;
    Animator anim;
    public bool isCounterOn = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rhythem = GameObject.Find("Metronome").GetComponent<Metronome>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            //rhythem = GameObject.Find("Metronome").GetComponent<Metronome>();
            if (rhythem.accuracy > 0) isCounterOn = true;
        if (rhythem.accuracy <= 0 && isCounterOn) isCounterOn = false;
    }

    void FixedUpdate()
    {

    }
    void Counter()
    {
        //�����ϴ� ĳ���� ũ���� ��� ���� ������ ����. �ش� ��������Ʈ�� ������ ����
        Debug.Log("���ݼ���");
    }
    void Damaged()
    {
        Debug.Log("���ݹ���");
    }
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "mob")
        {
            bool isMobAttacking = col.gameObject.GetComponent<Animator>().GetBool("isAttacking"); 
            if(isMobAttacking)
            {
                if (isCounterOn) Counter();
                else if (rhythem.accuracy <= 0) Damaged();
            }
        }
    }
}
