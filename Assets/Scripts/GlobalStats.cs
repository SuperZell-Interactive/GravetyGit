using UnityEngine;
using System.Collections;

public class GlobalStats : MonoBehaviour {

    public static GlobalStats currentStats;

    public int minDamage, maxDamage;
    public int player_current_health;
    public int player_max_health;
    public int player_level;
    public int player_nails;
    public int player_current_exp;
    public int player_exp_next_level;
    public int critic_rate;

    public GameObject objetoActivo;

	// Use this for initialization
	void Awake () {

        if (currentStats == null)
        {
            currentStats = this;
            resetStats();
            //Aunque cambie de mapa, esto no se va a eliminar
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            if (currentStats != this)
                Destroy(this.gameObject);
        }
	}

    void resetStats()
    {
        minDamage = 10;
        maxDamage = 16;
        player_current_health = 180;
        player_max_health = 180;
        player_level = 1;
        player_nails = 60;
        player_current_exp = 0;
        player_exp_next_level = 10;
        critic_rate = 90;
    }
	
}
