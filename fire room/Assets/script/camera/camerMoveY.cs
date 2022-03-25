using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerMoveY : MonoBehaviour
{
    // Start is called before the first frame updateTransform target;
    Transform target;
    [SerializeField] float smoothSpeed;
    [SerializeField] float minX;
    [SerializeField] float maxX;
    [SerializeField] float minY;
    [SerializeField] float maxY;
    
    void Start()
    {
        target=GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void LateUpdate() 
    {
        
        transform.position=Vector3.Lerp(transform.position,new Vector3(target.position.x,target.position.y,-10),smoothSpeed*Time.deltaTime);
        transform.position=new Vector3(Mathf.Clamp(transform.position.x,minX,maxX),Mathf.Clamp(transform.position.y,minY,maxY),-10);
    }
    
    
}
