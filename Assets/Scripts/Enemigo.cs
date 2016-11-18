using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enemigo : MonoBehaviour {

    public int puntosVida;
    public int expAtDeath;
    public bool isHit;
    public GameObject DTprefab; // Es el texto que saldrá para recibir daño
    public float moveSpeed; // Velocidad de movimiento del enemigo.
    private float minDist = 800f; // Mínima distacia con el jugador
    private float maxDist; // Máxima distancia con el jugador

    // @param: minDamage, maxDamage: Valores que referencian el daño máximo y mínimo que ejecutarán. Cada enemigo tendrá uno.
    public int minDamage, maxDamage;
    Rigidbody2D myRB;

	// Use this for initialization
	void Start () {
        // Debug.Log("Tengo " + puntosVida + " puntos de vida.");
        myRB = GetComponent<Rigidbody2D>();
        isHit = false;
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(Vector2.Distance(transform.position, PrefabManager.currentPrefabs.player.transform.position));
        //Debug.Log(moveSpeed);
        //Debug.Log(player.transform.position);
        if (puntosVida <= 0)
        {
            SoundManager.currentSounds.enemyDeath.Play();
            transform.localScale = new Vector2(0,0);
            PrefabManager.currentPrefabs.player.GetComponent<Jugador>().subirExp(expAtDeath);
            Destroy(this);
        }

        if ((Mathf.Abs(Vector2.Distance(transform.position, PrefabManager.currentPrefabs.player.transform.position)) <= minDist) || isHit)
        {
            if (transform.position.x - PrefabManager.currentPrefabs.player.transform.position.x > 0)
            {
                myRB.velocity = new Vector2(-1.5f * moveSpeed, myRB.velocity.y);
            }
            else if (transform.position.x - PrefabManager.currentPrefabs.player.transform.position.x != 0)
            {
                myRB.velocity = new Vector2(1.5f * moveSpeed, myRB.velocity.y);
            }
        }

    }

    public void golpeado(int valorGolpe, bool isCrit)
    {
        isHit = true;
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.3f, 0);
        puntosVida -= valorGolpe;
        if (!isCrit)
            InitDT(valorGolpe.ToString()).GetComponent<Animator>().SetTrigger("Hit");
        else
            InitDT(valorGolpe.ToString()).GetComponent<Animator>().SetTrigger("Crit");
        // Debug.Log("Tengo " + puntosVida + " puntos de vida.");
    }

    GameObject InitDT(string text)
    {
        GameObject temp = Instantiate(DTprefab) as GameObject;
        RectTransform tempRect = temp.GetComponent<RectTransform>();
        temp.transform.SetParent(transform.FindChild("EnemyCanvas"));
        tempRect.transform.localPosition = DTprefab.transform.localPosition;
        tempRect.transform.localScale = DTprefab.transform.localScale;
        tempRect.transform.localRotation = DTprefab.transform.localRotation;

        temp.GetComponent<Text>().text = text;
        Destroy(temp.gameObject, 2);

        return temp;
    }

}
