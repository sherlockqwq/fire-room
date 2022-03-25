using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class liftDoor : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;
    Rigidbody2D rb;
    void Start()
    {
        anim=GetComponentInChildren<Animator>();
        GameManager.regiserDoor(this);
        rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public void open(){
        Debug.Log("has open");
        anim.SetBool("isOpen",true);
        
    }
}
