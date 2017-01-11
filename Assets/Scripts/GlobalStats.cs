﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GlobalStats : MonoBehaviour {

    public static GlobalStats currentStats;

	public GameObject jugador;
    public int minDamage, maxDamage;
    public int player_current_health;
    public int player_max_health;
    public int player_level;
    public int player_nails;
    public int player_current_exp;
    public int player_exp_next_level;
    public int critic_rate;
    public Vector2 awakeLocation;
    public int nextLevel;
    public float cameraSize;

    public GameObject objetoActivo;

	// Use this for initialization
	void Awake()
	{
		if (jugador == null)
			jugador = GameObject.FindGameObjectWithTag ("Player");
		jugador.GetComponent<Animator>().SetBool("Ground", true);
		objetoActivo = jugador;

		Time.timeScale = 1;
		if (player_current_health <= 0 || Application.loadedLevelName == "Level0")
			resetStats ();
		
		if (currentStats == null) {
			currentStats = this;
			resetStats ();
			//Aunque cambie de mapa, esto no se va a eliminar
			if(Application.loadedLevelName!= "GameOver") DontDestroyOnLoad (this.gameObject);
		} else {
			if (currentStats != this)
				Destroy (this.gameObject);
		}
	}

	void OnLevelWasLoaded() {

        if (Application.loadedLevelName == "MenuPrincipal" || Application.loadedLevelName == "GameOver")
            Destroy(this.gameObject);

		if (jugador == null)
			jugador = GameObject.FindGameObjectWithTag ("Player");
		jugador.GetComponent<Animator>().SetBool("Ground", true);
		objetoActivo = jugador;

        Time.timeScale = 1;

		if (player_current_health <= 0)
			resetStats ();
		
		if (currentStats == null) {
			currentStats = this;
			resetStats ();
			//Aunque cambie de mapa, esto no se va a eliminar
			if(Application.loadedLevelName!= "GameOver") DontDestroyOnLoad (this.gameObject);
		} else {
			if (currentStats != this)
				Destroy (this.gameObject);
		}

    }

    public void resetStats()
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
		//Definimos la situación de inicio del Level 0
		awakeLocation = new Vector2 (-708.5f, -398.9f);
    }

    public Vector3 obtenerMaxCameraPosition(string nombreNivel)
    {
        switch (nombreNivel)
        {
            case "Level0":
                return new Vector3(327f, -302f, -10f);
            case "Level1":
			return new Vector3(30117f, -4f, -10f);
            default:
                return new Vector3(0f, 0f, 0f);
        }
    }

    public Vector3 obtenerMinCameraPosition(string nombreNivel)
    {
        switch (nombreNivel)
        {
            case "Level0":
                return new Vector3(-500, -302f, -10f);
            case "Level1":
			return new Vector3(-5f, -8238f, -10f);
            default:
                return new Vector3(0f, 0f, 0f);
        }
    }

    public float getCameraSize(string nombreNivel)
    {
        switch (nombreNivel)
        {
            case "Level0":
                return 240.4f;
            case "Level1":
                return 540f;
            default:
                return 540f;
        }
    }

}
