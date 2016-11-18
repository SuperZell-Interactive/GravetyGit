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

    public GameObject Queco;
    Rigidbody2D QuecoRig;


    public SpriteRenderer mySprite;
    ConstantForce2D miCF;

	// Use this for initialization
	void Start () {
        gravitational = false;
        gravity = -981f;
		Queco = PrefabManager.currentPrefabs.player;
        Queco.GetComponent<GravChange>().gravitational = true;
        miCF = this.gameObject.GetComponent<ConstantForce2D>(); 
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
				this.GetComponent<Rigidbody2D> ().velocity *= gravitySmooth;
                miCF.force = new Vector2(0, Mathf.Abs(gravity));
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
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
				this.GetComponent<Rigidbody2D> ().velocity *= gravitySmooth;
                miCF.force = new Vector2(0, -Mathf.Abs(gravity));
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
                if (!izq) izq = !izq;
				this.GetComponent<Rigidbody2D> ().velocity *= gravitySmooth;
                miCF.force = new Vector2(-Mathf.Abs(gravity), 0);
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
				this.GetComponent<Rigidbody2D> ().velocity *= gravitySmooth;
                miCF.force = new Vector2(Mathf.Abs(gravity), 0);
                if (!der) der = !der;
            }
        }
    }
}
