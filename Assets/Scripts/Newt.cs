using UnityEngine;
using System.Collections;

public class Newt : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Physics2D.IgnoreCollision(PrefabManager.currentPrefabs.player.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(PrefabManager.currentPrefabs.mochilaLlena.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(PrefabManager.currentPrefabs.mochilaVacia.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
