using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class ViewJogo3 : MonoBehaviour {

	public Text infoCaixa00;
	public Text infoCaixa01;
	public Text infoCaixa02;
	public Text infoCaixa03;
	public Text infoCaixa04;
	public Text infoCaixa10;
	public Text infoCaixa11;
	public Text infoCaixa12;
	public Text infoCaixa13;
	public Text infoCaixa14;
	public Text textQtdeTentativa;
	public Text textDica;
	public Text textResultado;
	public Text textAcertos;
	private GameObject InfoCaixa00;
	private GameObject InfoCaixa01;
	private GameObject InfoCaixa02;
	private GameObject InfoCaixa03;
	private GameObject InfoCaixa04;
	private GameObject InfoCaixa10;
	private GameObject InfoCaixa11;
	private GameObject InfoCaixa12;
	private GameObject InfoCaixa13;
	private GameObject InfoCaixa14;
	public GameObject dialogEscrever;
	public GameObject jornal;
	public GameObject imagemAcertou;
	public GameObject imagemErrou;
	public GameObject audioAcertou;
	public GameObject audioErrou;
	public Text textPalavraEscrita;
	private bool isJaSeiClicked;
	private string palavraEscrita;
	private bool isImagemCertoErradoVisible;




	// Use this for initialization
	void Start () {
		palavraEscrita = "";
		dialogEscrever.SetActive (false);
		inicializarGameObject ();
	}
	
	// Update is called once per frame
	void Update () {
		if (textDica != null) {
			textDica.text = LogicaJogo3.perguntaAtual.getDica ();
		}
		if ( LogicaJogo3.perguntaAtual!=null) {
			AtivarDesativarInfoCaixas(LogicaJogo3.perguntaAtual.getPalavra().Length);
		}
		if (isImagemCertoErradoVisible) {
			imagemErrou.SetActive (false);
			imagemAcertou.SetActive (false);
			isImagemCertoErradoVisible = false;
		}
			textAcertos.text = "Acertou "+LogicaJogo3.contadorRespostasCertas+" de " + LogicaJogo3.quantidadePerguntasJogo + " palavra(s)";
			textResultado.text = "Faltam "+ (LogicaJogo3.quantidadePerguntasJogo-LogicaJogo3.iteracoesDoJogo) + " palavra(s)";
	}

	public void onClickLetra(string letraDigitada){
		if (!isJaSeiClicked) {
			Pergunta p = LogicaJogo3.perguntaAtual;
			if(!LogicaJogo3.listLetrasJaEncontradas.Contains(letraDigitada)){
				bool[] indexVetor = Util.contemLetra (letraDigitada, p);
				if (indexVetor != null) {//Caso encontre a(s) letra(s)
					for (int i = 0; i < indexVetor.Length; i++) {
						if (indexVetor[i]==true) {
							LogicaJogo3.listLetrasJaEncontradas.Add(letraDigitada);
							LogicaJogo3.quantidadeLetrasAcertadas++;
							preencherInfoCaixas (i, letraDigitada);
						}	
					}
					//toca  musica de acerto

	//				audioAcertou.GetComponent<AudioSource>().Play();
				} else {//Caso nao encontre a(s) letra(s)
					//toca  musica de erro
	//				audioErrou.GetComponent<AudioSource>().Play();
				}
			}
			LogicaJogo3.quantidadeTentativas = LogicaJogo3.quantidadeTentativas - 1; 
			textQtdeTentativa.text = "" + LogicaJogo3.quantidadeTentativas;
			if (LogicaJogo3.quantidadeTentativas == 0 || p.getPalavra ().Length == LogicaJogo3.quantidadeLetrasAcertadas) {
				limparInfoCaixas ();
				textQtdeTentativa.text = "10";
			}	
		} else {
			palavraEscrita = palavraEscrita + letraDigitada;
			textPalavraEscrita.text = palavraEscrita;
		}

	}
	public void onClickButtonJaSei(){
		isJaSeiClicked = true;
		jornal.SetActive (false);
		dialogEscrever.SetActive (true);

	}

	public void onClickFecharDialog(){
		isJaSeiClicked = false;
		jornal.SetActive (true);
		dialogEscrever.SetActive (false);
		palavraEscrita = "";
		textPalavraEscrita.text = "";

	}
	public void onClickDialogConfirmar(){
		verificarPalavraEscrita (palavraEscrita);
		isJaSeiClicked = false;
		jornal.SetActive (true);
		dialogEscrever.SetActive (false);
		palavraEscrita = "";
		textPalavraEscrita.text = "";
		LogicaJogo3.quantidadeTentativas = 0;
		limparInfoCaixas ();
		textQtdeTentativa.text = "10";
	}
	public void onClickDialogApagar(){
		if (!palavraEscrita.Equals("")) {
			palavraEscrita=palavraEscrita.Substring (0, palavraEscrita.Length - 1);
			textPalavraEscrita.text = palavraEscrita;
		}

	}


	void preencherInfoCaixas(int i, string letraDigitada){
		switch(i)
		{	
		case 0:
			infoCaixa00.text = letraDigitada;
			break;
		case 1:
			infoCaixa01.text = letraDigitada;
			break;
		case 2:
			infoCaixa02.text = letraDigitada;
			break;
		case 3:
			infoCaixa03.text = letraDigitada;
			break;
		case 4:
			infoCaixa04.text = letraDigitada;
			break;
		case 5:
			infoCaixa10.text = letraDigitada;
			break;
		case 6:
			infoCaixa11.text = letraDigitada;
			break;
		case 7:
			infoCaixa12.text = letraDigitada;
			break;
		case 8:
			infoCaixa13.text = letraDigitada;
			break;
		case 9:
			infoCaixa14.text = letraDigitada;
			break;
		default:
			break;
		}
	}
	void limparInfoCaixas (){
		infoCaixa00.text = "";infoCaixa01.text = "";
		infoCaixa02.text = "";infoCaixa03.text = "";
		infoCaixa04.text = "";infoCaixa10.text = "";
		infoCaixa11.text = "";infoCaixa12.text = "";
		infoCaixa13.text = "";infoCaixa14.text = "";
	}
	void inicializarGameObject(){
		InfoCaixa00 = GameObject.Find ("InfoCaixa00");
		InfoCaixa01 = GameObject.Find ("InfoCaixa01");
		InfoCaixa02 = GameObject.Find ("InfoCaixa02");
		InfoCaixa03 = GameObject.Find ("InfoCaixa03");
		InfoCaixa04 = GameObject.Find ("InfoCaixa04");
		InfoCaixa10 = GameObject.Find ("InfoCaixa10");
		InfoCaixa11 = GameObject.Find ("InfoCaixa11");
		InfoCaixa12 = GameObject.Find ("InfoCaixa12");
		InfoCaixa13 = GameObject.Find ("InfoCaixa13");
		InfoCaixa14 = GameObject.Find ("InfoCaixa14");
	}
	void AtivarDesativarInfoCaixas(int lenghtPergunta){
		if (InfoCaixa00 != null) {
			if (1 > lenghtPergunta)
				InfoCaixa00.SetActive (false);
			else
				InfoCaixa00.SetActive (true);
		}	
		if (InfoCaixa01 != null) {
			if (2 > lenghtPergunta)
				InfoCaixa01.SetActive (false);
			else
				InfoCaixa01.SetActive (true);

		}
		if (InfoCaixa02 != null) {
			
			if (3 > lenghtPergunta)
				InfoCaixa02.SetActive (false);
			else
				InfoCaixa02.SetActive (true);	
		}
		if (InfoCaixa03 != null) {
			if (4 > lenghtPergunta)
				InfoCaixa03.SetActive (false);
			else
				InfoCaixa03.SetActive (true);
		}
		if (InfoCaixa04 != null) {
			if (5 > lenghtPergunta)
				InfoCaixa04.SetActive (false);
			else
				InfoCaixa04.SetActive (true);

		}
		if (InfoCaixa10 != null) {
			if (6 > lenghtPergunta)
				InfoCaixa10.SetActive (false);
			else
				InfoCaixa10.SetActive (true);
		}
		if (InfoCaixa11 != null) {
			if (7 > lenghtPergunta)
				InfoCaixa11.SetActive (false);
			else
				InfoCaixa11.SetActive (true);
		}
		if (InfoCaixa12 != null) {
			if (8 > lenghtPergunta)
				InfoCaixa12.SetActive (false);
			else
				InfoCaixa12.SetActive (true);
		}
		if (InfoCaixa13 != null) {
			if (9 > lenghtPergunta)
				InfoCaixa13.SetActive (false);
			else
				InfoCaixa13.SetActive (true);
		}
		if (InfoCaixa14 != null) {
			if (10 > lenghtPergunta)
				InfoCaixa14.SetActive (false);
			else
				InfoCaixa14.SetActive (true);
		}
	}
	void verificarPalavraEscrita (string palavraEscrita){
		if (LogicaJogo3.perguntaAtual.getPalavra ().Equals (palavraEscrita)) {
			imagemAcertou.SetActive (true);
			LogicaJogo3.contadorRespostasCertas++;
			//acertou palavra - colocar som
		} else {
			imagemErrou.SetActive (true);
			//errou palavra - colocar som
		}
		new Thread (delegate() {
			Thread.Sleep(1000);
			isImagemCertoErradoVisible=true;
		}).Start();
	}




}
