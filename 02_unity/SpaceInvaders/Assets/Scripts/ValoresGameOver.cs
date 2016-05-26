using UnityEngine;
using System.Collections;

public class ValoresGameOver : MonoBehaviour {

	public TextMesh total;

	// Conexión al marcador, para poder actualizarlo
	public GameObject marcador;


	// Use this for initialization
	void Start ()
	{
		// Localizamos el objeto que contiene el marcador
		marcador = GameObject.Find ("Marcador");

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnEnable(){
	
		total.text = marcador.GetComponent<ControlMarcador> ().puntos.ToString();
	}
}
