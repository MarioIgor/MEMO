using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PontuacaoJogo3 : MonoBehaviour {

	public Text textPalavraEscrita;
	public Text textNota;
	// Use this for initialization
	void Start () {
		textPalavraEscrita.text = "Você acertou "+LogicaJogo3.contadorRespostasCertas+" de " + LogicaJogo3.quantidadePerguntasJogo + " palavra(s)";
		textNota.text = "NOTA " + ((10 * LogicaJogo3.contadorRespostasCertas) / LogicaJogo3.quantidadePerguntasJogo);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void onClickOk(){
	
		SceneManager.LoadScene("inicio"); 
	}
		
}
