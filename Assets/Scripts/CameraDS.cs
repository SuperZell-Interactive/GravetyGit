using UnityEngine;
using System.Collections;

public class CameraDS : MonoBehaviour {

    public static CameraDS cam;

    void OnLevelWasLoaded()
    {
        if (Application.loadedLevelName == "MenuPrincipal" || Application.loadedLevelName == "GameOver")
            Destroy(this.gameObject);
		if (cam == null) {
			cam = this;
			if(Application.loadedLevelName != "GameOver") DontDestroyOnLoad (transform.gameObject);
		} else {
			if (cam != this)
				Destroy (this.gameObject);
		}
    }
}
