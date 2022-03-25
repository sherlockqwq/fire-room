using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Door : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject fence1;
    [SerializeField] GameObject fence2;
    public bool isOpen=false;
    public string  nextLevel;
    void Start()
    {
    }
    virtual public void open(){
        fence1.SetActive(false);
        fence2.SetActive(false);
        isOpen=true;
        AudioManager.openDoorAudio();
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Player" &&isOpen ){
            Debug.Log("playerEnter");
                GameManager.loadScene(nextLevel);
            
        }
    }

}
