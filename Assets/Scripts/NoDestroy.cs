using UnityEngine;
using System.Collections;

public class NoDestroy : MonoBehaviour {

    public static NoDestroy nod;

    void OnLevelWasLoaded()
    {
		if (Application.loadedLevelName != "GameOver") {
			if (nod == null)
			{
				nod = this;
				DontDestroyOnLoad(transform.gameObject);
			}
			else
			{
				if (nod != this)
					Destroy(this.gameObject);
			}
		}

        if (Application.loadedLevel == 0 || Application.loadedLevel == 1)
            Destroy(this.gameObject);

    }
}
