using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

    public float speed = 20f;
    public float movex = 0f;
    public float movey = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 posicion = this.transform.position;

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * 0.08f, Space.World);
        }
        if (Input.GetKey(KeyCode.A)) transform.Translate(Vector2.left * 0.08f, Space.World);
        if (Input.GetKeyDown(KeyCode.Space)) transform.Translate(Vector2.up * 1.5f, Space.World);
        if (Input.GetKey(KeyCode.S)) transform.localScale = new Vector2(1f, 0.5f);
        if (Input.GetKeyUp(KeyCode.S)) transform.localScale = new Vector2(1f, 1f);

	}
}
