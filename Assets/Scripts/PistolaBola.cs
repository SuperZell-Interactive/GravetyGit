using UnityEngine;
using System.Collections;

public class PistolaBola : MonoBehaviour {

    public int offsetRotacion = -30;
    public float rotationSpeed = 20f;
    public GameObject newt, player;

	// Use this for initialization
	void Start () {
        newt = GameObject.FindGameObjectWithTag("Robot");
        player = GameObject.FindGameObjectWithTag("Player");
        Vector2 posicionJugador = player.transform.position;
        newt.transform.position = new Vector2(posicionJugador.x, posicionJugador.y);
	}
	
	// Update is called once per frame
	void Update () {

    }

}
