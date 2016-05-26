using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class botonesMenu : MonoBehaviour {

	 public void BotonJugar(){
		SceneManager.LoadScene ("Nivel1");

	
	}
	public void BotonSalir(){
		Application.Quit ();

	}

	public void BotonSalirMenu(){
		SceneManager.LoadScene ("Menu");

	}

	public void numjugadores(){
		Opciones.jugadores = 2;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
