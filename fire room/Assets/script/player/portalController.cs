using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalController : MonoBehaviour
{
    public bool hasFire=true;
    [SerializeField] GameObject prefabPoint;
    GameObject firePoint;
    [SerializeField]GameObject childFire;
    // Start is called before the first frame update
    void Start()
    {
        firePoint=childFire;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        enablePortal();
        createAndDestroyFirePoint();
    }
    void createAndDestroyFirePoint(){
        if(Input.GetButtonDown("Interact")){
            if(hasFire){
                firePoint= Instantiate(prefabPoint,transform.position,transform.rotation);
                hasFire=false;
            }
            else
            {
                if(firePoint.transform.position!=transform.position){
                    Destroy(firePoint);
                    hasFire=true;
                }
            }
        }

       
    }

    void enablePortal(){

        if(hasFire){
            childFire.SetActive(true);
        }
        else{
            teleport();
            childFire.SetActive(false);

        }
    }
    void teleport(){

        Transform fpTransform= firePoint.transform;
        //如果从左方或者下方穿过边界
        if(transform.position.x<fpTransform.Find("Bottom left Point").transform.position.x){
            transform.position=new Vector3(fpTransform.Find("Top right Point").transform.position.x,transform.position.y,transform.position.z);
        }
        if(transform.position.y<fpTransform.Find("Bottom left Point").transform.position.y){
            transform.position=new Vector3(transform.position.x,fpTransform.Find("Top right Point").transform.position.y,transform.position.z);
        }
        //如果从右方或者上方穿过
        if(transform.position.x>fpTransform.Find("Top right Point").transform.position.x){
            transform.position=new Vector3(fpTransform.Find("Bottom left Point").transform.position.x,transform.position.y,transform.position.z);
        }
        if(transform.position.y>fpTransform.Find("Top right Point").transform.position.y){
            transform.position=new Vector3(transform.position.x,fpTransform.Find("Bottom left Point").transform.position.y,transform.position.z);
        }
    }

}