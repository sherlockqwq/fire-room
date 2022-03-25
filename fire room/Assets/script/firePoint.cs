using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firePoint : MonoBehaviour
{
    // Start is called before the first frame update
    public float  EdgeLength;
    LineRenderer lir;
    public Transform topRightPoint;
    public Transform bottomLeftPoint;
    
    void Start()
    {
        lir=GetComponent<LineRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        setPoint();
        drawRectangle();
    }
    void setPoint(){
        topRightPoint.position=new Vector3(transform.position.x+EdgeLength/2,transform.position.y+EdgeLength/2,transform.position.z);
        bottomLeftPoint.position=new Vector3(transform.position.x-EdgeLength/2,transform.position.y-EdgeLength/2,transform.position.z);
    }
    void drawRectangle(){
        Vector3 bottomRight =new Vector3(transform.position.x+EdgeLength/2,transform.position.y-EdgeLength/2,transform.position.z);
        Vector3 topLeft= new Vector3 (transform.position.x-EdgeLength/2,transform.position.y+EdgeLength/2,transform.position.z);
        lir.SetPosition(0,bottomLeftPoint.position);
        lir.SetPosition(1,topLeft);
        lir.SetPosition(2,topRightPoint.position);
        lir.SetPosition(3,bottomRight);
        lir.SetPosition(4,bottomLeftPoint.position);
    }
}
