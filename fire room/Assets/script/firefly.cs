using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firefly : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
        GameManager.registerFirefly(this);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Player"){
            AudioManager.firefliesAudio();
            GameManager.removeFirefly(this);
            gameObject.SetActive(false);
            
        }
    }
}
