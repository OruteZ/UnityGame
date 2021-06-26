using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rigid;
    SpriteRenderer rand;
    Animator anim;
    public GameManager gameManager;
    public float Speed;
    public float jumpPower;
    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        rand = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        rigid.velocity = new Vector2(h * Speed, rigid.velocity.y);


        if(Input.GetButtonDown("Horizontal"))
        {
            rand.flipX = rigid.velocity.x < 0;
            anim.SetBool("isWalking", rigid.velocity.x != 0);

        }
        if (rigid.velocity.x != 0) anim.SetBool("isWalking", true);
        else anim.SetBool("isWalking", false);

        if (rigid.velocity.x < 0) rand.flipX = true;
        else if (rigid.velocity.x > 0) rand.flipX = false;
        
        if(rigid.velocity.y < 0)
        {
            Debug.DrawRay(rigid.position, Vector3.down, new Color(0, 1, 0));
                    RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Platform"));
                    if(rayHit.collider != null)
                    {
                            Debug.Log(rayHit.collider.name);
                    }
        }
        
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Finish")
        {
            gameManager.NextStage();
        }
    }
}
