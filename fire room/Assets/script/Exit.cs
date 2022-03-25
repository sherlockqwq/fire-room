using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    // Start is called before the first frame update
    public string sceneName;

    [SerializeField] string thisScenePW;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Player"){
            PlayerManager.instance.scenePassword=thisScenePW;
            GameManager.loadScene(sceneName);
        }
    }
}
