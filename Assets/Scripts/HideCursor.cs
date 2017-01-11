using UnityEngine;
using System.Collections;

public class HideCursor : MonoBehaviour {

	// Use this for initialization
    void Start()
    {
        if (Application.loadedLevelName == "MenuPrincipal" || Application.loadedLevelName == "GameOver")
        {
            Cursor.visible = true;
        }
    }
	void OnLevelWasLoaded () {
        if(Application.loadedLevelName == "MenuPrincipal" || Application.loadedLevelName == "GameOver")
        {
            Cursor.visible = true;
        }
	}
}
