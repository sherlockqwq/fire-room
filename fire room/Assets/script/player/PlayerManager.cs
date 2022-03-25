using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static PlayerManager instance;
    public string scenePassword;
    void Awake() {
        if(instance==null)
            instance=this;
        else if(instance!=this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

    }

}
