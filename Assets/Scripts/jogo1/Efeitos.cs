using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Efeitos : MonoBehaviour {

	public AudioClip acertou;
	public AudioClip errou;
	AudioSource audioRespostas;

	// Use this for initialization
	void Start () {
		audioRespostas = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
