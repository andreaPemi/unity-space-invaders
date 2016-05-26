using UnityEngine;
using System.Collections;

public class ControlNave : MonoBehaviour
{

	// Velocidad a la que se desplaza la nave (medido en u/s)
	private float velocidad = 20f;

	// Fuerza de lanzamiento del disparo
	private float fuerza = 0.5f;

	// Acceso al prefab del disparo
	public Rigidbody2D disparo;
	public Rigidbody2D disparo1;

	// Use this for initialization
	void Start ()
	{
		//saber si hay 1 jugador o 2 jugadores
		GameObject nave1 = GameObject.Find ("Nave1");

		if (Opciones.jugadores == 2) {
			nave1.SetActive (true);
		} else {
			nave1.GetComponent<Renderer> ().enabled = false;
					
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Calculamos la anchura visible de la cámara en pantalla
		float distanciaHorizontal = Camera.main.orthographicSize * Screen.width / Screen.height;

		// Calculamos el límite izquierdo y el derecho de la pantalla
		float limiteIzq = -1.0f * distanciaHorizontal;
		float limiteDer = 1.0f * distanciaHorizontal;

		// Tecla: Izquierda
		if (Input.GetKey (KeyCode.LeftArrow)) {

			// Nos movemos a la izquierda hasta llegar al límite para entrar por el otro lado
			if (transform.position.x > limiteIzq) {
				transform.Translate (Vector2.left * velocidad * Time.deltaTime);
			} else {
				transform.position = new Vector2 (limiteDer, transform.position.y);			
			}
		}

		// Tecla: Derecha
		if (Input.GetKey (KeyCode.RightArrow)) {

			// Nos movemos a la derecha hasta llegar al límite para entrar por el otro lado
			if (transform.position.x < limiteDer) {
				transform.Translate (Vector2.right * velocidad * Time.deltaTime);
			} else {
				transform.position = new Vector2 (limiteIzq, transform.position.y);			
			}
		}

		// Disparo normal
		if (Input.GetKeyDown (KeyCode.Space)) {
			disparar ();
		}

		// DisparoBomba
		if (Input.GetKeyDown (KeyCode.B)) {
			dispararBomba ();
		}

	
	}


	//disparo normal
	void disparar ()
	{
		// Hacemos copias del prefab del disparo y las lanzamos
		Rigidbody2D d = (Rigidbody2D)Instantiate (disparo, transform.position, transform.rotation);

		// Desactivar la gravedad para este objeto, si no, ¡se cae!
		d.gravityScale = 0;

		// Posición de partida, en la punta de la nave
		d.transform.Translate (Vector2.up * 0.7f);

		// Lanzarlo
		d.AddForce (Vector2.up * fuerza, ForceMode2D.Impulse);	
	}


	//disparo bomba
	void dispararBomba ()
	{
		// Hacemos copias del prefab del disparo y las lanzamos
		Rigidbody2D b = (Rigidbody2D)Instantiate (disparo1, transform.position, transform.rotation);

		// Desactivar la gravedad para este objeto, si no, ¡se cae!
		b.gravityScale = 0;

		// Posición de partida, en la punta de la nave
		b.transform.Translate (Vector2.up * 0.7f);

		// Lanzarlo
		b.AddForce (Vector2.up * fuerza, ForceMode2D.Impulse);	
	}

}
