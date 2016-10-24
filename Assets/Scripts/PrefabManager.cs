using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PrefabManager : MonoBehaviour
{

    public static PrefabManager currentPrefabs;

    public GameObject clavo;
    public GameObject newt;
    public GameObject player;

    public Text HUD_texto_vida;
    public Text HUD_texto_nivel;
    public Text HUD_texto_nails;
    public GameObject HUD_barra_vida;
    public GameObject HUD_barra_vida_borde;
    public GameObject HUD_barra_vida_punta;
    public GameObject HUD_barra_vida_fondo;
    public GameObject HUD_barra_exp;
    public GameObject HUD_barra_exp_fondo;
	public GameObject trail;
	public GameObject esferaExp;

    // Use this for initialization
    void Awake()
    {
		Cursor.visible = false;
        if (currentPrefabs == null)
        {
            currentPrefabs = this;
            //Aunque cambie de mapa, esto no se va a eliminar
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            if (currentPrefabs != this)
                Destroy(this.gameObject);
        }
    }
}
