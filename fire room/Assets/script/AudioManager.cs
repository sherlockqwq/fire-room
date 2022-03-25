using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("±≥æ∞“Ù¿÷")]
    [SerializeField] AudioClip BGM1;
    [SerializeField] AudioClip BGM2;
    [SerializeField] AudioClip BGM3;
    [SerializeField] AudioClip caveClip;
    [SerializeField] float caveVolume=0.3f;
    [SerializeField] float BGMVolume=1f;
    [Header("–ßπ˚“Ù")]
    [SerializeField] AudioClip fireFlyAudio;
    [SerializeField] AudioClip openTheDoor;
    [SerializeField] float FXVolume=0.5f;

    [Header("ÕÊº“")]
    [SerializeField] AudioClip playerJump;
    [SerializeField] AudioClip playerDied;
    [SerializeField] float playerVolume=0.5f;
    public static AudioManager instance;
    AudioSource BGMsource;
    AudioSource caveSource;
    AudioSource FXsource;
    AudioSource PlayerSource;
    void Awake() {
        if(instance!=null){
            Destroy(this);
            return;
        }
        instance=this;
        DontDestroyOnLoad(this);
        BGMsource=gameObject.AddComponent<AudioSource>();
        caveSource=gameObject.AddComponent<AudioSource>();
        FXsource=gameObject.AddComponent<AudioSource>();
        PlayerSource=gameObject.AddComponent<AudioSource>();
        playBGM();
        
    }
    void Start() {
        
    }
    void startLevelAduio(){
        instance.BGMsource.clip=instance.BGM1;
        instance.BGMsource.loop=true;
        instance.BGMsource.Play();
        instance.caveSource.clip=instance.caveClip;
        instance.caveSource.loop=true;
        instance.caveSource.Play();
    }
    void midLevelAudio(){
        instance.BGMsource.clip=instance.BGM2;
        instance.BGMsource.loop=true;
        instance.BGMsource.Play();
        instance.caveSource.clip=instance.caveClip;
        instance.caveSource.loop=true;
        instance.caveSource.Play();
    }
    void finalLevelAudio(){
        instance.BGMsource.clip=instance.BGM3;
        instance.BGMsource.loop=true;
        instance.BGMsource.Play();
        instance.caveSource.clip=instance.caveClip;
        instance.caveSource.loop=true;
        instance.caveSource.Play();
    }
    public static void playBGM(){
        if(SceneManager.GetActiveScene().buildIndex<1){
            instance. startLevelAduio();
        }
        else if(SceneManager.GetActiveScene().buildIndex<=2)
        {
            instance.midLevelAudio();
        }
        else if(SceneManager.GetActiveScene().buildIndex>=3)
        {
            instance.finalLevelAudio();
        }
        instance.caveSource.volume=instance.caveVolume;
        instance.BGMsource.volume=instance.BGMVolume;
    }
    public static void jumpAudio(){
        instance.PlayerSource.clip=instance.playerJump;
        instance.PlayerSource.Play();
        instance.PlayerSource.volume=instance.playerVolume;
    }
    public static void deathAudio(){
        instance.PlayerSource.clip=instance.playerDied;
        instance.PlayerSource.Play();
        instance.PlayerSource.volume=instance.playerVolume;
    }
    public static void firefliesAudio(){
        instance.FXsource.clip=instance.fireFlyAudio;
        instance.FXsource.Play();
        instance.FXsource.volume=instance.FXVolume;
    }
    public static void openDoorAudio(){
        instance.FXsource.clip=instance.openTheDoor;
        //instance.FXsource.Play();
        instance.FXsource.volume=instance.FXVolume;
    }
}
