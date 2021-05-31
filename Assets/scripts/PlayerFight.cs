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
        //공격하는 캐릭터 크기의 모션 따로 공수할 예정. 해당 스프라이트가 나오고 결정
        Debug.Log("공격성공");
    }
    void Damaged()
    {
        Debug.Log("공격받음");
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
