using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

    public static HUD hud;

    void Awake()
    {
        if (hud == null)
        {
            hud = this;
            if (Application.loadedLevelName != "GameOver") DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            if (hud != this)
                Destroy(this);
        }
    }

    void OnLevelWasLoaded()
    {
        if (Application.loadedLevelName == "MenuPrincipal" || Application.loadedLevelName == "GameOver")
            Destroy(this.gameObject);
		if (hud == null) {
			hud = this;
			if(Application.loadedLevelName != "GameOver") DontDestroyOnLoad (transform.gameObject);
		} else {
			if (hud != this)
				Destroy (this);
		}
    }
}
