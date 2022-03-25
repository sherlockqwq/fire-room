using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathzone : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Player"){
            GameManager.playerDied();
            
        }
    }
}
