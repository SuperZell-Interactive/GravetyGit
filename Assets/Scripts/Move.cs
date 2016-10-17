using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

    public float speed;
	public float jumpSpeed;
    public float movex = 0f;
    public float movey = 0f;

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
		speed = 275;
		jumpSpeed = 500f;

		GravChange gravitacional = GetComponent<GravChange> ();
		//Obtenemos el Rigid Body del Queco para que al saltar le podamos aplicar fuerzas.
		Rigidbody2D QuecoRig = this.gameObject.GetComponent<Rigidbody2D> ();

        if (Input.GetKey(KeyCode.D))
        {
			if(gravitacional.abajo || gravitacional.arriba){
            	transform.Translate(Vector2.right * speed * Time.deltaTime, Space.World);
				movex = 1f;
                if (gravitacional.abajo) isFacingRight = false;
                else isFacingRight = true;
			}
            else if (gravitacional.der) transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y / 2);
            mySpriteRenderer.flipX = isFacingRight;
        }
        if (Input.GetKey (KeyCode.A)) {
			if(gravitacional.abajo || gravitacional.arriba){
				movex = -1f;
				transform.Translate (Vector2.left * speed * Time.deltaTime, Space.World);
                if (gravitacional.abajo) isFacingRight = true;
                else isFacingRight = false;
			}
            else if (gravitacional.izq) transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y / 2); ;
            mySpriteRenderer.flipX = isFacingRight;
		}

		if(Input.GetKey (KeyCode.W)){
			if(gravitacional.izq || gravitacional.der)
			{
				transform.Translate(Vector2.up * speed * Time.deltaTime, Space.World);
				movey = 1f;
                if (gravitacional.der) isFacingRight = false;
                else isFacingRight = true;
			}
            else if (gravitacional.arriba) transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y / 2); ;
            mySpriteRenderer.flipX = isFacingRight;
		}
		if(Input.GetKey (KeyCode.S)){
			if(gravitacional.izq || gravitacional.der)
			{
				transform.Translate(Vector2.down * speed * Time.deltaTime, Space.World);
				movey = -1f;
                if (gravitacional.izq) isFacingRight = false;
                else isFacingRight = true;
			}
            else if (gravitacional.abajo) transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y / 2); ;
            mySpriteRenderer.flipX = isFacingRight;
		}
        if (Input.GetKeyDown (KeyCode.Space)) {
			if (gravitacional.abajo)
			{
				movey = 1.3f;
				if (movex == 1f) movex = 0.1f;
				if (movex == -1f) movex = -0.1f;
			}
			if(gravitacional.arriba)
			{
				movey = -1.3f;
				if (movex == 1f) movex = 0.1f;
				if (movex == -1f) movex = -0.1f;
			}
			if(gravitacional.izq)
			{
				movex = 1.3f;
				if (movey == 1f) movey = 0.1f;
				if (movey == -1f) movey = -0.1f;
			}
			if(gravitacional.der)
			{
				movex = -1.3f;
				if (movey == 1f) movey = 0.1f;
				if (movey == -1f) movey = -0.1f;
			}
			jumDir = new Vector2(movex, movey);
			QuecoRig.AddForce(jumDir * jumpSpeed, ForceMode2D.Impulse);

		}

		//Gestionamos que ya han dejado de pulsarse las direcciones.
		if(Input.GetKeyUp(KeyCode.D)) movex = 0f;
		if(Input.GetKeyUp(KeyCode.A)) movex = 0f;
        if (Input.GetKeyUp(KeyCode.S) && gravitacional.abajo) transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y * 2); ;
        if (Input.GetKeyUp(KeyCode.W) && gravitacional.arriba) transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y * 2);
        if (Input.GetKeyUp(KeyCode.A) && gravitacional.izq) transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y * 2);
        if (Input.GetKeyUp(KeyCode.D) && gravitacional.der) transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y * 2);

	}
}
