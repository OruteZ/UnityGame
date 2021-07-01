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
    List<KeyCode> inputKeycode;

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        rand = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        transform = GetComponent<Transform>();
        inputKeycode = new List<KeyCode>();
    }
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            inputKeycode.Add(KeyCode.LeftArrow);
        if (Input.GetKeyDown(KeyCode.RightArrow))
            inputKeycode.Add(KeyCode.RightArrow);
        if (Input.GetKeyDown(KeyCode.Space))
            inputKeycode.Add(KeyCode.Space);

        /*
        if (Input.GetButtonDown("Jump"))
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        */
    }

    /// <summary>
    /// 플레이어가 이동할 때 호출
    /// </summary>
    /// <param name="arrow"> 0일시 무시, 양수면 오른쪽 이동, 음수면 왼쪽 이동</param>
    public void Move(int arrow)
    {
        if (arrow > 0) transform.position += Vector3.right;
        else if (arrow < 0) transform.position += Vector3.left;
    }

    public KeyCode GetLastKey()
    {
        if (inputKeycode.Count == 0) return KeyCode.None;
        KeyCode key = inputKeycode[inputKeycode.Count - 1];
        inputKeycode.Clear();
        return key;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*
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
        */
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Finish")
        {
            gameManager.NextStage();
        }
    }

    public void VZero()
    {
        rigid.velocity = Vector2.zero;
    }
}
