using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

    public static SoundManager currentSounds;

    public AudioSource nailShoot;
    public AudioSource enemyDeath;
    public AudioSource enemyHit;
    public AudioSource EloiseHit;

    // Use this for initialization
    void Awake()
    {
        Cursor.visible = false;
        if (currentSounds == null)
        {
            currentSounds = this;
            //Aunque cambie de mapa, esto no se va a eliminar
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            if (currentSounds != this)
                Destroy(this.gameObject);
        }
    }
}
