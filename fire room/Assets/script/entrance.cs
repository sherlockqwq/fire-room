using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class entrance : MonoBehaviour
{
    // Start is called before the first frame update
    public string entrancePW;
    void Start()
    {
        if(PlayerManager.instance.scenePassword==entrancePW){
            PlayerManager.instance.transform.position=new Vector3(transform.position.x,transform.position.y,0);
            Debug.Log("enter");
        }
        else
        Debug.Log("ERROR");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
