using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Uimanager : MonoBehaviour
{
    // Start is called before the first frame update
    public static Uimanager instance;
    [SerializeField] TextMeshProUGUI fireFliesText;
    void Awake() {
        if(instance){
            Destroy(gameObject);
            return;
        }
        instance=this;
        DontDestroyOnLoad(this);
        
    }
    public static void updateFirefliesNumber(int count){
        instance.fireFliesText.text=count.ToString();
    }
}
