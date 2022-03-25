using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class savepoint : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;
    void Start()
    {
        anim=GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Player"){
            Debug.Log("playerSaved");
            GameManager.instance.savePosition=transform.position;
            anim.SetBool("lit",true);
            PlayerManager.instance.scenePassword="";
        }
    }
}
