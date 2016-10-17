using UnityEngine;
using System.Collections;

public class GravChange : MonoBehaviour {

    public float gravity; //Inicializamos el valor de la gravedad.
    public bool abajo = true;
    public bool arriba = false;
    public bool izq = false;
    public bool der = false;
    public bool gravitational;
    public bool rotatable;

    public GameObject Queco;
    Rigidbody2D QuecoRig;


    public SpriteRenderer mySprite;
    ConstantForce2D miCF;

	// Use this for initialization
	void Start () {
        gravitational = false;
        gravity = -981f;
        Queco = GameObject.FindGameObjectWithTag("Player");
        Queco.GetComponent<GravChange>().gravitational = true;
        miCF = this.gameObject.GetComponent<ConstantForce2D>();
        //Debug.Log("El valor constante del cuerpo " + this.gameObject.name + " es (" + miCF.force.x + ", " + miCF.force.y + ")");
        //Debug.Log("El valor gravitational de " + this.gameObject.name + " es " + this.gameObject.GetComponent<GravChange>().gravitational); 
	}
	
	// Update is called once per frame
    void Update()
    {
        if (this.gameObject.GetComponent<GravChange>().gravitational == true)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (abajo)
                {
                    abajo = !abajo;
                    if(rotatable) transform.Rotate(Vector3.forward * 180);
                }
                //Physics2D.gravity = new Vector2(0f, -gravity);
                if (der)
                {
                    if (rotatable) transform.Rotate(Vector3.forward * 90);
                    der = !der;
                }
                if (izq)
                {
                    if (rotatable) transform.Rotate(Vector3.forward * -90);
                    izq = !izq;
                }
                if (!arriba) arriba = !arriba;
                miCF.force = new Vector2(0, -gravity);
                //Debug.Log("El valor constante del cuerpo " + this.gameObject.name + " es (" + miCF.force.x + ", " + miCF.force.y + ")");
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {

                //Physics2D.gravity = new Vector2(0f, gravity);
                if (arriba)
                {
                    arriba = !arriba;
                    if (rotatable) transform.Rotate(Vector3.forward * 180);
                }
                if (izq)
                {
                    if (rotatable) transform.Rotate(Vector3.forward * 90);
                    izq = !izq;
                }
                if (der)
                {
                    if (rotatable) transform.Rotate(Vector3.forward * -90);
                    der = !der;
                }
                if (!abajo) abajo = !abajo;
                miCF.force = new Vector2(0, gravity);
                //Debug.Log("El valor constante del cuerpo " + this.gameObject.name + " es (" + miCF.force.x + ", " + miCF.force.y + ")");
            }

            if (Input.GetKey("escape")) Application.Quit();

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (abajo)
                {
                    if (rotatable) transform.Rotate(Vector3.forward * -90);
                    abajo = !abajo;
                }
                if (arriba)
                {
                    if (rotatable) transform.Rotate(Vector3.forward * 90);
                    arriba = !arriba;
                }
                if (der)
                {
                    if (rotatable) transform.Rotate(Vector3.forward * 180);
                    der = !der;
                }
                //Physics2D.gravity = new Vector2(gravity, 0f);

                if (!izq) izq = !izq;
                miCF.force = new Vector2(gravity, 0);
                //Debug.Log("El valor constante del cuerpo " + this.gameObject.name + " es (" + miCF.force.x + ", " + miCF.force.y + ")");
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (abajo)
                {
                    if (rotatable) transform.Rotate(Vector3.forward * 90);
                    abajo = !abajo;
                }
                if (arriba)
                {
                    if (rotatable) transform.Rotate(Vector3.forward * -90);
                    arriba = !arriba;
                }
                if (izq)
                {
                    if (rotatable) transform.Rotate(Vector3.forward * 180);
                    izq = !izq;
                }

                miCF.force = new Vector2(-gravity, 0);
                //Debug.Log("El valor constante del cuerpo " + this.gameObject.name + " es (" + miCF.force.x + ", " + miCF.force.y + ")");
                if (!der) der = !der;
            }
        }
    }
}
