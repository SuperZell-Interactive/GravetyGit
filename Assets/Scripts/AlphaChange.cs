using UnityEngine;
using System.Collections;

public class AlphaChange : MonoBehaviour {

    public GameObject jugador;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
            Physics2D.IgnoreCollision(jugador.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());

        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        }
    }
}
