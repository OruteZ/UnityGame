using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Transform transform;
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
        transform = GetComponent<Transform>();

    }
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetButtonDown("Jump") && anim.GetBool("isJumping") == false)
        {
            anim.SetBool("isJumping", true);
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
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

        if (rigid.velocity.y < 0)
        {
            Debug.DrawRay(rigid.position, Vector3.down, new Color(0, 1, 0));
            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("platform"));
            if (rayHit.collider != null)
            {
                if (rayHit.distance < 0.5f && anim.GetBool("isJumping"))
                    anim.SetBool("isJumping", false);
            }

        }


    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Finish")
        {
            gameManager.NextStage();
        }
        else if (col.gameObject.tag == "mob" && gameObject.layer == 8)
        {
            gameManager.Damaged();
            OnDamaged(col.transform.position);
        }

        void OnDamaged(Vector2 tragetPos)
        {
            gameObject.layer = 7;                   //PlayerDamaged layer = 7
            rand.color = new Color(1, 1, 1, 0.4f);

            //Knockback
            VZero();
            int dirc = transform.position.x - tragetPos.x > 0 ? 1 : -1;
            rigid.AddForce(new Vector2(-5, 1) * 5, ForceMode2D.Impulse);

            // anim add
            Invoke("OffDamaged", 2);
        }

    }

    public void VZero()
    {
        rigid.velocity = Vector2.zero;
    }

    void OffDamaged()
    {
        gameObject.layer = 8;
        rand.color = new Color(1, 1, 1, 1);
    }
}
