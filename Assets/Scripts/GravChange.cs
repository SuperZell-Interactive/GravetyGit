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
	public float gravitySmooth;

    //Esto nos va a permitir cambiar la gravedad con el ratón.
    //posicionInicial es la posición inicial del personaje
    //posicionFinal es la posición donde soltamos el botón izquierdo del ratón
    //direccionGravedad es el vector con el que vamos a trabajar para obtener los cambios
    private Vector3 posicionInicial, posicionFinal;
    private Vector2 direccionGravedad;

    public GameObject Queco;
    Rigidbody2D QuecoRig;


    public SpriteRenderer mySprite;
    ConstantForce2D miCF;

	// Use this for initialization
	void Start () {
        gravitational = false;
        gravity = -981f;
        direccionGravedad = new Vector2(0, -1);
		Queco = GlobalStats.currentStats.jugador;
        Queco.GetComponent<GravChange>().gravitational = true;
        miCF = this.gameObject.GetComponent<ConstantForce2D>(); 
	}
	
	// Update is called once per frame
    void Update()
    {
        if (this.gameObject.GetComponent<GravChange>().gravitational == true)
        {
            if(Input.GetMouseButton(1))
            {
                Time.timeScale = 0.1f;
                posicionInicial = Camera.main.WorldToScreenPoint(Queco.transform.position);
            }
            if (Input.GetMouseButtonUp(1))
            {
                Time.timeScale = 1;
                posicionFinal = Input.mousePosition;
                direccionGravedad = obtenerDireccionGravedad(posicionInicial, posicionFinal);
            }

            if (direccionGravedad.y == 1 && !arriba)
            {
                if (this.gameObject.GetComponent<GravChange>().abajo)
                {
                    this.gameObject.GetComponent<GravChange>().abajo = !abajo;
                    if(rotatable) transform.Rotate(Vector3.forward * 180);
                }
                else if (this.gameObject.GetComponent<GravChange>().der)
                {
                    if (rotatable) transform.Rotate(Vector3.forward * 90);
                    der = !der;
                }
                else if (this.gameObject.GetComponent<GravChange>().izq)
                {
                    if (rotatable) transform.Rotate(Vector3.forward * -90);
                    izq = !izq;
                }
                else if (!this.gameObject.GetComponent<GravChange>().arriba) arriba = !arriba;
                this.GetComponent<Rigidbody2D>().velocity *= gravitySmooth;
                miCF.force = new Vector2(0, Mathf.Abs(gravity));
            }

            if (direccionGravedad.y == -1 && !abajo)
            {
                if (this.gameObject.GetComponent<GravChange>().arriba)
                {
                    arriba = !arriba;
                    if (rotatable) transform.Rotate(Vector3.forward * 180);
                }
                else if (this.gameObject.GetComponent<GravChange>().izq)
                {
                    if (rotatable) transform.Rotate(Vector3.forward * 90);
                    izq = !izq;
                }
                else if (this.gameObject.GetComponent<GravChange>().der)
                {
                    if (rotatable) transform.Rotate(Vector3.forward * -90);
                    der = !der;
                }
                else if (!this.gameObject.GetComponent<GravChange>().abajo) abajo = !abajo;
                this.GetComponent<Rigidbody2D>().velocity *= gravitySmooth;
                miCF.force = new Vector2(0, -Mathf.Abs(gravity));
            }

            if (Input.GetKey("escape")) Application.Quit();

            if (direccionGravedad.x == -1 && !izq)
            {
                if (this.gameObject.GetComponent<GravChange>().abajo)
                {
                    if (rotatable) transform.Rotate(Vector3.forward * -90);
                    abajo = !abajo;
                }
                else if (this.gameObject.GetComponent<GravChange>().arriba)
                {
                    if (rotatable) transform.Rotate(Vector3.forward * 90);
                    arriba = !arriba;
                }
                else if (this.gameObject.GetComponent<GravChange>().der)
                {
                    if (rotatable) transform.Rotate(Vector3.forward * 180);
                    der = !der;
                }
                else if (!this.gameObject.GetComponent<GravChange>().izq) izq = !izq;
                this.GetComponent<Rigidbody2D>().velocity *= gravitySmooth;
                miCF.force = new Vector2(-Mathf.Abs(gravity), 0);
            }

            if (direccionGravedad.x == 1 && !der)
            {
                if (abajo)
                {
                    if (rotatable) transform.Rotate(Vector3.forward * 90);
                    abajo = !abajo;
                }
                else if (arriba)
                {
                    if (rotatable) transform.Rotate(Vector3.forward * -90);
                    arriba = !arriba;
                }
                else if (izq)
                {
                    if (rotatable) transform.Rotate(Vector3.forward * 180);
                    izq = !izq;
                }
                if (!this.gameObject.GetComponent<GravChange>().der) der = !der;
				this.GetComponent<Rigidbody2D> ().velocity *= gravitySmooth;
                miCF.force = new Vector2(Mathf.Abs(gravity), 0);
            }
        }
    }

    Vector2 obtenerDireccionGravedad(Vector3 posicionInicial, Vector3 posicionFinal)
    {
        Vector2 diferencia = (posicionFinal - posicionInicial).normalized;
        if(Mathf.Abs(diferencia.x) > Mathf.Abs(diferencia.y))
        {
            if (diferencia.x > 0) return new Vector2(1, 0);
            else return new Vector2(-1, 0);
        }
        else
        {
            if (diferencia.y > 0) return new Vector2(0, 1);
            else return new Vector2(0, -1);
        }
    }
		
}
