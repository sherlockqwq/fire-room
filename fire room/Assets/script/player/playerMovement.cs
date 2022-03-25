using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class playerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float runSpeed=5f;
    
    [Header("跳跃和地面检测")]
    [SerializeField] Transform checkPoint;
    [SerializeField] Vector2 checkBoxSize;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] bool jumpPressed;
    [SerializeField] bool onGround;
    [SerializeField] bool isJump;
    [SerializeField] float jumpForce=350;
    [SerializeField] int jumpNumber;
    
    int jumpCount;

    Rigidbody2D rb;
    Collider2D coll;
    
    float horizontalMove;
        void Start()
    {
        coll=GetComponent<Collider2D>();
        rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        getValueInUpdate();
        groundChecking();
        jump();
    }
    void FixedUpdate() {
        horizontalMovement();
    }
    void groundChecking(){//检测是否在地面
        Collider2D check= Physics2D.OverlapBox(checkPoint.position,checkBoxSize,0,groundLayer);
        if(!check){
            onGround=false;
            
        } 
        else{
            onGround=true;
            isJump=false;
        }
    }
    void OnDrawGizmos() {
        
        Gizmos.DrawWireCube(checkPoint.position,checkBoxSize);
        Gizmos.color=Color.red;
    }
    
    void getValueInUpdate(){//在update里面让某些变量获得值，改善手感
        horizontalMove=Input.GetAxisRaw("Horizontal");
        jumpPressed=Input.GetButtonDown("Jump");

    }
    void horizontalMovement(){//水平移动
        rb.velocity=new Vector2(horizontalMove*runSpeed,rb.velocity.y);
        if(horizontalMove<0)
        transform.localScale= new Vector3(-1,1,1);
        if(horizontalMove>0)
        transform.localScale= new Vector3(1,1,1);

    }
    void jump(){//垂直方向的跳跃
        
        if(jumpPressed){
            if(onGround){
            jumpCount=jumpNumber;
            isJump=true;
            rb.velocity=new Vector2 (rb.velocity.x,jumpForce);
            jumpPressed=false;
            jumpCount--;
            AudioManager.jumpAudio();
            }
            else if(jumpCount>0){
                rb.velocity=new Vector2 (rb.velocity.x,jumpForce);
                jumpPressed=false;
                jumpCount--;
                isJump=true;
                AudioManager.jumpAudio();
            }
        }
        
        
    }
    


}
