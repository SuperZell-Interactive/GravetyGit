using UnityEngine;
using System.Collections;

public class Newt : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject jugador = PrefabManager.currentPrefabs.player;
        Physics2D.IgnoreCollision(jugador.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
