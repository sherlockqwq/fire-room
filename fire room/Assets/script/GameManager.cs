using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour

{
    // Start is called before the first frame update
    public static GameManager instance;
    public List<firefly> fireflies;
    public List<firefly> removedFireflies=new List<firefly>();
    [SerializeField] float waitSeconds=0.6f;
    public int firefliesNumber;
    public int removedFirefliesNumber;
    public Vector3 savePosition;
    liftDoor lockedDoor;
    void Awake() {
        if(instance!=null){
            Destroy(this);
            return;
        }
        instance=this;
        DontDestroyOnLoad(this);
        fireflies=new List<firefly>();

    }

    void Update() {
        restartScene();
    }
    public static void regiserDoor(liftDoor door){
        instance.lockedDoor=door;
    }
    public static void registerFirefly(firefly bug){
        if(instance==null){
            return;
        }
        if( !instance.fireflies.Contains(bug)){
            instance.fireflies.Add(bug);
        }
        Uimanager.updateFirefliesNumber(instance.fireflies.Count);

    }
    public static void removeFirefly(firefly bug){
        if(!instance.fireflies.Contains(bug)){
            return;
        }
        instance.fireflies.Remove(bug);
        if(!instance.removedFireflies.Contains(bug)){
            instance.removedFireflies.Add(bug);
        }
        Uimanager.updateFirefliesNumber(instance.fireflies.Count);
        if(instance.fireflies.Count==0)
        instance.lockedDoor.open();
    }
    public static void playerDied(){
        loadScene(SceneManager.GetActiveScene().name);
        AudioManager.deathAudio();
    }
    public static void loadScene(string sceneName){
        instance.StartCoroutine(instance.loadLevel(sceneName));
        if(sceneName!= SceneManager.GetActiveScene().name){
            AudioManager.playBGM();
        }
        
    }
    IEnumerator loadLevel( string scene){
        GameObject.FindGameObjectWithTag("sceneTransition").GetComponent<Animator>().SetTrigger("fadein");
        yield return new WaitForSeconds(waitSeconds);
        SceneManager.LoadScene(scene);
        GameObject.FindGameObjectWithTag("Player").GetComponent<portalController>().hasFire=true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position=savePosition;
        instance.fireflies.Clear();
    }
    void restartScene(){
        if(Input.GetButtonDown("Restart")){
            loadScene(SceneManager.GetActiveScene().name);

        }
    }
    
}
