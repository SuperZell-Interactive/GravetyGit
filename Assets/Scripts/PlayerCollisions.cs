using UnityEngine;
using System.Collections;

/* Esta clase se empleará para gestionar las colisiones del jugador con los diferentes elementos del entorno.
 * También gestionará los coleccionables y elementos con los que el personaje se encontrará. **/

public class PlayerCollisions : MonoBehaviour {

    public AudioSource sonido;
    public float pullx, pully;

	void Start () {
        pullx = 500f;
        pully = 150f;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        // Recogemos clavos del suelo y aumentamos el contador de clavos disponibles.
        if (col.gameObject.tag == "Nails")
        {
            sonido = col.gameObject.GetComponent<AudioSource>();
            sonido.Play();
            GlobalStats.currentStats.player_nails += 10;
            col.gameObject.transform.localScale = new Vector2(0, 0);
        }

        // Nos chocamos contra un enemigo
        if (col.gameObject.tag == "Enemy")
        {
            SoundManager.currentSounds.EloiseHit.Play();
            int direction = comprobarDireccionColision(this.gameObject, col.gameObject);
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(pullx * direction, pully);
            int damageHit = col.gameObject.GetComponent<Enemigo>().minDamage;
            this.GetComponent<Jugador>().getDamage(damageHit);
        }

        // Cogemos un objeto de curación
        if (col.gameObject.tag == "Lifebox")
        {
            int lifeAmount = col.gameObject.GetComponent<LifeBox>().lifeAmount;
            if (GlobalStats.currentStats.player_max_health - lifeAmount < GlobalStats.currentStats.player_current_health)
                GlobalStats.currentStats.player_current_health = GlobalStats.currentStats.player_max_health;
            else
                GlobalStats.currentStats.player_current_health += lifeAmount;
            col.gameObject.transform.localScale = new Vector2(0, 0);
        }
    }

    int comprobarDireccionColision(GameObject jugador, GameObject enemigo)
    {
        if ((jugador.transform.position.x - enemigo.transform.position.x) < 0)
            return -1;
        else
            return 1;
    }
}
