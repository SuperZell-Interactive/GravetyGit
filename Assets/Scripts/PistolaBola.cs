using UnityEngine;
using System.Collections;

public class PistolaBola : MonoBehaviour {

    public int offsetRotacion = -30;
    public float rotationSpeed = 20f;
    public GameObject newt, player;

	// Use this for initialization
	void Start () {
        newt = PrefabManager.currentPrefabs.newt;
        player = PrefabManager.currentPrefabs.player;
        Vector2 posicionJugador = player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

    }

}
