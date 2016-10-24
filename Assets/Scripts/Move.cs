using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

    public float speed;
	public float jumpSpeed;

    public bool isFacingRight;
    public bool isFacingDown;
    public SpriteRenderer mySpriteRenderer;
	public Vector2 jumDir = Vector2.zero;

	// Use this for initialization
	void Start () {
        isFacingRight = false;
        isFacingDown = false;
        mySpriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
	
	}
	
	// Update is called once per frame
	void Update () {
		speed = 350f;
		jumpSpeed = 750f;

		GravChange gravitacional = GetComponent<GravChange> ();
		//Obtenemos el Rigid Body del Queco para que al saltar le podamos aplicar fuerzas.
		Rigidbody2D QuecoRig = this.gameObject.GetComponent<Rigidbody2D> ();

        if (Input.GetKey(KeyCode.D))
        {
			if(gravitacional.abajo || gravitacional.arriba){
                QuecoRig.velocity = new Vector2(speed, QuecoRig.velocity.y);
                if (gravitacional.abajo) isFacingRight = false;
                else isFacingRight = true;
			}
            mySpriteRenderer.flipX = isFacingRight;
        }

        if (Input.GetKey (KeyCode.A)) {
			if(gravitacional.abajo || gravitacional.arriba){
                QuecoRig.velocity = new Vector2(-speed, QuecoRig.velocity.y);
                if (gravitacional.abajo) isFacingRight = true;
                else isFacingRight = false;
			}
            mySpriteRenderer.flipX = isFacingRight;
		}

		if(Input.GetKey (KeyCode.W)){
			if(gravitacional.izq || gravitacional.der)
			{
                QuecoRig.velocity = new Vector2(QuecoRig.velocity.x, speed);
                if (gravitacional.der) isFacingRight = false;
                else isFacingRight = true;
			}
            mySpriteRenderer.flipX = isFacingRight;
		}

		if(Input.GetKey (KeyCode.S)){
			if(gravitacional.izq || gravitacional.der)
			{
                QuecoRig.velocity = new Vector2(QuecoRig.velocity.x, -speed);
                if (gravitacional.izq) isFacingRight = false;
                else isFacingRight = true;
			}
            mySpriteRenderer.flipX = isFacingRight;
		}

        if (Input.GetKeyDown (KeyCode.Space)) {
			if (gravitacional.abajo)
                QuecoRig.velocity = new Vector2(0, jumpSpeed);
			if(gravitacional.arriba)
                QuecoRig.velocity = new Vector2(0, -jumpSpeed);
			if(gravitacional.izq)
                QuecoRig.velocity = new Vector2(jumpSpeed, 0);
			if(gravitacional.der)
                QuecoRig.velocity = new Vector2(-jumpSpeed, 0);
		}
	}
}
