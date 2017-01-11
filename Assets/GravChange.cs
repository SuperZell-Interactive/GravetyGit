using UnityEngine;
using System.Collections;

public class GravChange : MonoBehaviour {

    float gravity = -9.8f; //Inicializamos el valor de la gravedad.
    bool abajo = true;
    bool arriba = false;
    bool izq = false;
    bool der = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Quaternion rotation = transform.localRotation;
        Vector2 localScale = transform.localScale;
        
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (abajo) abajo = !abajo;
            Physics2D.gravity = new Vector2(0f, -gravity);
            if (!arriba)
            {
                localScale.y *= -1;
                transform.localScale = localScale;
            }
            if (der)
            {
                transform.Rotate(Vector3.forward * -90);
                der = !der;
            }
            if (izq)
            {
                transform.Rotate(Vector3.forward * 90);
                izq = !izq;
            }
            if (!arriba) arriba = !arriba;
        }
        
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {

            Physics2D.gravity = new Vector2(0f, gravity);
            if (arriba && !abajo){
                arriba = !arriba;
                localScale.y *= -1;
                transform.localScale = localScale;
            }
            if (izq)
            {
                transform.Rotate(Vector3.forward * 90);
                izq = !izq;
            }
            if (der)
            {
                transform.Rotate(Vector3.forward * -90);
                der = !der;
            }
            if (!abajo) abajo = !abajo;
        }
        
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (abajo)
            {
                transform.Rotate(Vector3.forward * -90);
                abajo = !abajo;
            }
            if (arriba)
            {
                transform.Rotate(Vector3.forward * 90);
                arriba = !arriba;
            }
            if (der)
            {
                transform.Rotate(Vector3.forward * 180);
                der = !der;
            }
            Physics2D.gravity = new Vector2(gravity, 0f);

            if (!izq) izq = !izq;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (abajo)
            {
                transform.Rotate(Vector3.forward * 90);
                abajo = !abajo;
            }
            if (arriba)
            {
                transform.Rotate(Vector3.forward * -90);
                arriba = !arriba;
            }
            if (izq)
            {
                transform.Rotate(Vector3.forward * 180);
                izq = !izq;
            }

            Physics2D.gravity = new Vector2(-gravity, 0f);
            if (!der) der = !der;
        }
	}
}
