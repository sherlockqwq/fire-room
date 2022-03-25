using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveShadow : MonoBehaviour
{
    // Start is called before the first frame update
    Transform target;
    Rigidbody2D rb;
    [SerializeField] float movespeed_fast; 
    [SerializeField] float movespeed_slow;
    [SerializeField] float distance;
    void Start()
    {
        target=GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveTowardsPlayer();
    }
    void moveTowardsPlayer(){
        if(Mathf.Abs(target.position.y-transform.position.y)<=distance){
            rb.velocity=new Vector2(rb.velocity.x,movespeed_slow);
        }
        else if(Mathf.Abs(target.position.y-transform.position.y)>distance)
        {
            rb.velocity=new Vector2(rb.velocity.x,movespeed_fast);
        }
    }
}
