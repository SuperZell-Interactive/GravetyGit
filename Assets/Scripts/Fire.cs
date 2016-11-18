//@author: Manuel Gavilan Ortiz
//@version: 1.0 
using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour {

    private GameObject Queco;
    public bool loaded;
    public GameObject objetoActivo;
    public int offsetRotacion;

    private float velBola;
    private float velClavo;

	// Use this for initialization
	void Start () {
        Queco = PrefabManager.currentPrefabs.player;
        PrefabManager.currentPrefabs.newt.transform.localScale = Vector2.zero;
        PrefabManager.currentPrefabs.mochilaLlena.transform.localScale = new Vector2(0.9680524f, 0.9680524f);
        PrefabManager.currentPrefabs.mochilaVacia.transform.localScale = Vector2.zero;
        loaded = true;
        GlobalStats.currentStats.objetoActivo = PrefabManager.currentPrefabs.player;
        velBola = 3000f;
        velClavo = 4000f;

	}
	
	// Update is called once per frame
	void Update () {
        // Disparamos a Newt. Primero apuntamos y después disparamos.
        if (Input.GetMouseButton(1))
        {
            PrefabManager.currentPrefabs.mochilaLlena.transform.localScale = new Vector2(0f, 0f);
            PrefabManager.currentPrefabs.mochilaVacia.transform.localScale = new Vector2(0.9680524f, 0.9680524f);
            PrefabManager.currentPrefabs.newt.transform.localScale = new Vector2(0.3f, 0.3f);
            PrefabManager.currentPrefabs.newt.transform.position = PrefabManager.currentPrefabs.puntoNewt.transform.position;
            if (Input.GetMouseButtonDown(0))
            {
                if (PrefabManager.currentPrefabs.newt.GetComponent<Fire>().loaded != false)
                {
                    GameObject newt = (GameObject) Instantiate(PrefabManager.currentPrefabs.newt, Queco.transform.localPosition, Quaternion.identity);
                    newt.transform.localScale = new Vector2(15f, 15f);
                    newt.AddComponent<Rigidbody2D>();
                    Rigidbody2D newtRB = newt.GetComponent<Rigidbody2D>();
                    newtRB.transform.position = new Vector2(PrefabManager.currentPrefabs.puntoNewt.transform.position.x, PrefabManager.currentPrefabs.puntoNewt.transform.position.y);
                    newtRB.transform.rotation = PrefabManager.currentPrefabs.puntoNewt.transform.localRotation;
                    disparar(newtRB, velBola);
                    loaded = false;
                }
            }
        }
        else
        {
            if (PrefabManager.currentPrefabs.newt.GetComponent<Fire>().loaded)
            {
                PrefabManager.currentPrefabs.mochilaLlena.transform.localScale = new Vector2(0.9680524f, 0.9680524f);
                PrefabManager.currentPrefabs.mochilaVacia.transform.localScale = Vector2.zero;
            }

            PrefabManager.currentPrefabs.newt.transform.localScale = Vector2.zero;
            if (Input.GetMouseButtonDown(0))
            {
                if (GlobalStats.currentStats.player_nails > 0)
                {
                    GameObject clavo = (GameObject) Instantiate(PrefabManager.currentPrefabs.clavo, Queco.transform.localPosition, Quaternion.identity);
                    clavo.transform.localScale = new Vector2(10f, 10f);
                    Rigidbody2D clavoRB = clavo.GetComponent<Rigidbody2D>();
                    //clavoRB.transform.position = new Vector2(Queco.transform.position.x, Queco.transform.position.y);
                    clavoRB.transform.position = new Vector2(PrefabManager.currentPrefabs.puntoDisparo.transform.position.x, PrefabManager.currentPrefabs.puntoDisparo.transform.position.y);
                    transform.rotation = Quaternion.identity;
                    dispararClavo(clavoRB, velClavo);
                }
            }
        }
        // Disparo principal con pistola de clavos.

       

        // Recargamos a Newt en su posición
        if (Input.GetKeyDown(KeyCode.R)){
            if (GlobalStats.currentStats.objetoActivo != PrefabManager.currentPrefabs.player)
            {
                GlobalStats.currentStats.objetoActivo.GetComponent<GravChange>().gravitational = false;
                PrefabManager.currentPrefabs.newt.GetComponent<Fire>().loaded = true;
                GlobalStats.currentStats.objetoActivo = Queco;
                PrefabManager.currentPrefabs.player.GetComponent<GravChange>().gravitational = true;
            }
        }
	}

    void disparar(Rigidbody2D proyectil, float velocidad)
    {
        Vector3 posPantalla = Camera.main.WorldToScreenPoint(Queco.transform.position);
        Vector3 direccion = (Input.mousePosition - posPantalla).normalized;
        if (PrefabManager.currentPrefabs.player.transform.localScale.x < 0)
            proyectil.velocity = transform.TransformDirection(new Vector2(-direccion.x, direccion.y) * velocidad);
        else
            proyectil.velocity = transform.TransformDirection(new Vector2(direccion.x, direccion.y) * velocidad);
    }

    void dispararClavo(Rigidbody2D proyectil, float velocidad)
    {
        SoundManager.currentSounds.nailShoot.Play();
        Vector3 posPantalla = Camera.main.WorldToScreenPoint(PrefabManager.currentPrefabs.puntoDisparo.transform.position);
        Vector3 direccion = (Input.mousePosition - posPantalla).normalized;
        proyectil.GetComponent<Clavo>().setRandomDamage();
        //proyectil.velocity = transform.TransformDirection(new Vector2(direccion.x, direccion.y) * velocidad);
        if (PrefabManager.currentPrefabs.player.transform.localScale.x < 0)
            proyectil.velocity = transform.TransformDirection(new Vector2(-direccion.x, direccion.y) * velocidad);
        else
            proyectil.velocity = transform.TransformDirection(new Vector2(direccion.x, direccion.y) * velocidad);

        GlobalStats.currentStats.player_nails--;
        //proyectil.AddForce(direccion * velocidad, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Scenario")
        {
            PrefabManager.currentPrefabs.newt.GetComponent<Fire>().loaded = true;
            Destroy(this.gameObject);
            //Debug.Log("LOADED es " + loaded);
        }
        else if (col.gameObject.tag == "Objeto")
        {
            GlobalStats.currentStats.objetoActivo = col.gameObject;
            GlobalStats.currentStats.objetoActivo.GetComponent<GravChange>().gravitational = true;
            PrefabManager.currentPrefabs.player.GetComponent<GravChange>().gravitational = false;
            PrefabManager.currentPrefabs.newt.GetComponent<Fire>().loaded = false;
            Destroy(this.gameObject);
        }
    }

}
