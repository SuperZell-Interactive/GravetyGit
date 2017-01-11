//@author: Manuel Gavilan Ortiz
//@version: 1.0 
using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour {

    public GameObject Queco, Bola;
	public float fireRate = 0; // Esto nos va a permitir ajustar la cadencia de disparo. 
	public LayerMask acertar;

    private float velBola = 20f;

	// Use this for initialization
	void Start () {
        Queco = GameObject.FindGameObjectWithTag("Player");
		Bola = GameObject.FindGameObjectWithTag ("Robot");
		Bola.transform.localScale = new Vector2 (0, 0);

	}
	
	// Update is called once per frame
	void Update () {
		apuntar ();
		float posx = Queco.transform.position.x + 0.5f;
		float posy = Queco.transform.position.y;
		Bola.transform.localPosition = new Vector2 (posx, posy);
        // Disparamos con el boton izquierdo
        if (Input.GetKey (KeyCode.F)) {
			Bola.transform.localScale = new Vector2 (0.07f, 0.07f);
		} else
			Bola.transform.localScale = new Vector2 (0,0);

	}

	void apuntar(){
		//Esta funcion nos devuelve una posicion que convierte la posicion en la pantalla en una posicion de dentro del juego.
		Vector2 posPuntero = new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y);
		//Esto guarda la posicion inicial en la que se encuetra el cuadrado.
		Vector2 posBola = new Vector2 (Bola.transform.position.x, Bola.transform.position.y);
		//Esto sirve para comprobar si se ha golpeado algo al disparar el robot.
		//@args: posicion inicial, direccion, longitud del raycast, LayerMask
		RaycastHit2D hit = Physics2D.Raycast (posBola, posPuntero-posBola, 100, acertar);
		if(Input.GetKey(KeyCode.F))
			Debug.DrawLine (posBola, (posPuntero-posBola)*100, Color.cyan);
		if (Input.GetMouseButtonDown (0)) {
            Vector3 posPantalla = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 direccion = (Input.mousePosition - posPantalla).normalized;
            GameObject proyectil = (GameObject)Instantiate(Bola, Bola.transform.position, Quaternion.identity);
            Rigidbody2D proyRig2D = proyectil.AddComponent<Rigidbody2D>();
            proyRig2D.AddForce(direccion * 20f, ForceMode2D.Impulse);

		}
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Scenario")
        {
            Destroy(this.gameObject);
        }
    }

}
