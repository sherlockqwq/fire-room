using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    // Start is called before the first frame update
    Transform target;
    [SerializeField] float smoothSpeed;
    [SerializeField] float minX;
    [SerializeField] float maxX;
    [SerializeField] float minY;
    [SerializeField] float maxY;
    [SerializeField] float cameraY1=0;
    [SerializeField] float cameraY2;
    [SerializeField] float PlayerEdgeY=8;
    void Start()
    {
        target=GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void LateUpdate() 
    {
        changeY();
        transform.position=Vector3.Lerp(transform.position,new Vector3(target.position.x,target.position.y,-10),smoothSpeed*Time.deltaTime);
        transform.position=new Vector3(Mathf.Clamp(transform.position.x,minX,maxX),Mathf.Clamp(transform.position.y,minY,maxY),-10);
    }
    void changeY(){
        if(PlayerManager.instance.transform.position.y>PlayerEdgeY){
            minY=maxY=cameraY2;
        }
        else
        {
            minY=maxY=cameraY1;
        }
        
    }
}
