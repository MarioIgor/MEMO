
using UnityEngine.UI;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perguntas : MonoBehaviour {

	public float contador = 1;
	public GameObject painel;
	public GameObject painelChiado;

	private Animator anim;
	public GameObject painelAnimacao;

	public Image pergunta;
	public Text respostasA;
	public Text respostasB;
	public Text respostasC;
	public Text respostasD;
	public Text questoes;

	public Image[] perguntas; 
	private int idPerguntas;


	public string[] letraA;
	public string[] letraB;
	public string[] letraC;
	public string[] letraD;
	public string[] respostaCerta;



	void Start () {

		idPerguntas = 0;
		painel.SetActive (true);
		painelChiado.SetActive (false);
		anim = painelAnimacao.GetComponent<Animator> ();
		anim.SetBool ("acertou", false);

		//pergunta.sprite = perguntas [idPerguntas];
		//pergunta = GameObject.GetComponent<Image>();
		//GetComponent<Image>() = perguntas[idPerguntas];

		questoes.text = (idPerguntas + 1).ToString() + " de " + (perguntas.Length).ToString() + " perguntas";


	}

	void Update () {

		tempo ();

	}


	void tempo(){
		if (contador < 301) {
			contador++;
		}

		if (contador > 290) {
			painelChiado.SetActive (true);
		}

		if (contador > 300) {

			respostasA.text = letraA [idPerguntas];
			respostasB.text = letraB [idPerguntas];
			respostasC.text = letraC [idPerguntas];
			respostasD.text = letraD [idPerguntas];
			contador = 301;
		}
	}

	void mostraOpcoes(){			

		respostasA.text = letraA [idPerguntas];
		respostasB.text = letraB [idPerguntas];
		respostasC.text = letraC [idPerguntas];
		respostasD.text = letraD [idPerguntas];

	}


	public void compararResposta(string opcaoSelecionada){

		if (opcaoSelecionada == "A") {
			if (letraA [idPerguntas] == respostaCerta [idPerguntas]) {				
				anim.SetBool ("acertou", true);
				proxima ();

			} else {
				proxima ();
			}
		} else if (opcaoSelecionada == "B") {
			if (letraB [idPerguntas] == respostaCerta [idPerguntas]) {
				proxima ();
			} else {
				proxima ();
			}

		} else if (opcaoSelecionada == "C") {
			if (letraC [idPerguntas] == respostaCerta [idPerguntas]) {
				proxima ();
			} else {
				proxima ();
			}

		} else if (opcaoSelecionada == "D") {
			if (letraD [idPerguntas] == respostaCerta [idPerguntas]) {
				proxima ();
			} else {
				proxima ();
			}

		}

	}

	void proxima (){
		if (idPerguntas < (perguntas.Length) - 2){

			if (idPerguntas == 0) {
				painelChiado.SetActive (false);
				Destroy (perguntas [idPerguntas]);
			} else if (idPerguntas == 1) {
				painelChiado.SetActive (false);
				Destroy (perguntas [idPerguntas]);
			}else if (idPerguntas == 2) {
				painelChiado.SetActive (false);
				Destroy (perguntas [idPerguntas]);
			}else if (idPerguntas == 3) {
				painelChiado.SetActive (false);
				Destroy (perguntas [idPerguntas]);
			}else if (idPerguntas == 4) {
				painelChiado.SetActive (false);
				Destroy (perguntas [idPerguntas]);
			}

			respostasA.text = "";
			respostasB.text = "";
			respostasC.text = "";
			respostasD.text = "";
			contador = 1;
			idPerguntas++;

			questoes.text = (idPerguntas + 1).ToString () + " de " + (perguntas.Length).ToString () + " perguntas";

			if (contador > 300) {
				mostraOpcoes ();
				contador = 301;
			}

		}else{

			Application.LoadLevel("JOGO3");


		}
	}

}
