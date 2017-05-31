using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorJogo2 : MonoBehaviour {
	public GameObject Pergunta;

	public GameObject Imagem1, Imagem2, Imagem3, Imagem4, Imagem5;

	public GameObject Va, Vb, Vc, Vd;
	public GameObject Xa, Xb, Xc, Xd;

	public GameObject OpcaoA, OpcaoB, OpcaoC, OpcaoD;

	public GameObject ImagemA1, ImagemA2, ImagemA3, ImagemA4, ImagemA5;
	public GameObject ImagemB1, ImagemB2, ImagemB3, ImagemB4, ImagemB5;
	public GameObject ImagemC1, ImagemC2, ImagemC3, ImagemC4, ImagemC5;
	public GameObject ImagemD1, ImagemD2, ImagemD3, ImagemD4, ImagemD5;

	public string[] respostaCerta;

	private int idPergunta = 0;
	private float contadorTempo = 1;			
	private bool acertouResposta = false;
	private bool errouResposta = false;

	void Start () {
		inicializar();        
	}

	void Update () {
		processarTempo();
	}		

	public void processarResposta(string opcaoSelecionada) {
		ImagensFeedback imagensFeedback = identificarImagensDeFeedbackBaseadoNaOpcaoSelecionada (opcaoSelecionada);
		int indiceRespostaCorreta = idPergunta - 1;
		if (respostaCerta[indiceRespostaCorreta] == opcaoSelecionada) {
			imagensFeedback.V.SetActive(true);
			acertouResposta = true;  
		} else {
			imagensFeedback.X.SetActive(true);
			errouResposta = true;
		}					     
		contadorTempo = 180;
	}

	private ImagensFeedback identificarImagensDeFeedbackBaseadoNaOpcaoSelecionada(string opcaoSelecionada) {
		ImagensFeedback imagensFeedback = null;

		switch (opcaoSelecionada)
		{
		case "A":
			{
				imagensFeedback = new ImagensFeedback (Va, Xa);
				break;
			}
		case "B":
			{
				imagensFeedback = new ImagensFeedback (Vb, Xb);
				break;
			}
		case "C":
			{
				imagensFeedback = new ImagensFeedback (Vc, Xc);
				break;
			}
		case "D":
			{
				imagensFeedback = new ImagensFeedback (Vd, Xd);
				break;
			}
		}

		return imagensFeedback;
	}

	private void processarTempo(){
		if (contadorTempo > 280) {
			return;
		}

		contadorTempo++;

		switch (idPergunta)
		{
		case 0:
			{
				processarTempoParaTelaInicial();
				break;
			}
		case 1:
			{
				processarTempoParaPrimeiraImagem();
				break;
			}
		case 2:
			{
				processarTempoParaSegundaImagem();
				break;
			}
		case 3:
			{
				processarTempoParaTerceiraImagem();
				break;
			}
		case 4:
			{
				processarTempoParaQuartaImagem();
				break;
			}
		case 5:
			{
				processarTempoParaQuintaImagem();
				break;
			}
		}                    
	}

	private void processarTempoParaTelaInicial() {
		if (contadorTempo == 200)
		{
			Pergunta.SetActive(false);
			Imagem5.SetActive(true);
		}
		else if (contadorTempo == 220)
		{
			OpcaoA.SetActive(true);
			ImagemA1.SetActive(true);
		}
		else if (contadorTempo == 240)
		{
			OpcaoB.SetActive(true);
			ImagemB1.SetActive(true);
		}
		else if (contadorTempo == 260)
		{
			OpcaoC.SetActive(true);
			ImagemC1.SetActive(true);
		}
		else if (contadorTempo == 280)
		{
			OpcaoD.SetActive(true);
			ImagemD1.SetActive(true);
			idPergunta++;
		}
	}

	private void processarTempoParaPrimeiraImagem() {
		if (acertouResposta)
		{
			if (contadorTempo == 280)
			{
				alterarVisibilidadeImagensFeedback(false);

				idPergunta++;
				Imagem5.SetActive(false);
				Imagem4.SetActive(true);
				acertouResposta = false;
				errouResposta = false;

				OpcaoA.SetActive(false);
				ImagemA1.SetActive(false);
				OpcaoB.SetActive(false);
				ImagemB1.SetActive(false);
				OpcaoC.SetActive(false);
				ImagemC1.SetActive(false);
				OpcaoD.SetActive(false);
				ImagemD1.SetActive(false);

				contadorTempo = 100;
			}
		}
		else if (errouResposta)
		{
			if (contadorTempo == 280)
			{
				alterarVisibilidadeImagensX(false);
				acertouResposta = false;
				errouResposta = false;
			}                        
		}
	}

	private void processarTempoParaSegundaImagem() {
		if (acertouResposta)
		{
			if (contadorTempo == 280)
			{
				alterarVisibilidadeImagensFeedback(false);

				idPergunta++;
				Imagem4.SetActive(false);
				Imagem3.SetActive(true);
				acertouResposta = false;
				errouResposta = false;

				OpcaoA.SetActive(false);
				ImagemA2.SetActive(false);
				OpcaoB.SetActive(false);
				ImagemB2.SetActive(false);
				OpcaoC.SetActive(false);
				ImagemC2.SetActive(false);
				OpcaoD.SetActive(false);
				ImagemD2.SetActive(false);

				contadorTempo = 100;
			}
		}
		else if (errouResposta)
		{
			if (contadorTempo == 280)
			{
				alterarVisibilidadeImagensX(false);
				errouResposta = false;
			}
		}
		else
		{
			if (contadorTempo == 220)
			{
				OpcaoA.SetActive(true);
				ImagemA2.SetActive(true);
			}
			else if (contadorTempo == 240)
			{
				OpcaoB.SetActive(true);
				ImagemB2.SetActive(true);
			}
			else if (contadorTempo == 260)
			{
				OpcaoC.SetActive(true);
				ImagemC2.SetActive(true);
			}
			else if (contadorTempo == 280)
			{
				OpcaoD.SetActive(true);
				ImagemD2.SetActive(true);                            
			}
		}                   
	}

	private void processarTempoParaTerceiraImagem() {
		if (acertouResposta)
		{
			if (contadorTempo == 280)
			{
				alterarVisibilidadeImagensFeedback(false);
				idPergunta++;
				Imagem3.SetActive(false);
				Imagem2.SetActive(true);
				acertouResposta = false;
				errouResposta = false;

				OpcaoA.SetActive(false);
				ImagemA3.SetActive(false);
				OpcaoB.SetActive(false);
				ImagemB3.SetActive(false);
				OpcaoC.SetActive(false);
				ImagemC3.SetActive(false);
				OpcaoD.SetActive(false);
				ImagemD3.SetActive(false);

				contadorTempo = 100;
			}
		}
		else if (errouResposta)
		{
			if (contadorTempo == 280)
			{
				alterarVisibilidadeImagensX(false);
				errouResposta = false;
			}
		}
		else
		{
			if (contadorTempo == 220)
			{
				OpcaoA.SetActive(true);
				ImagemA3.SetActive(true);
			}
			else if (contadorTempo == 240)
			{
				OpcaoB.SetActive(true);
				ImagemB3.SetActive(true);
			}
			else if (contadorTempo == 260)
			{
				OpcaoC.SetActive(true);
				ImagemC3.SetActive(true);
			}
			else if (contadorTempo == 280)
			{
				OpcaoD.SetActive(true);
				ImagemD3.SetActive(true);
			}
		}
	}

	private void processarTempoParaQuartaImagem() {
		if (acertouResposta)
		{
			if (contadorTempo == 280)
			{
				alterarVisibilidadeImagensFeedback(false);

				idPergunta++;
				Imagem2.SetActive(false);
				Imagem1.SetActive(true);
				acertouResposta = false;
				errouResposta = false;

				OpcaoA.SetActive(false);
				ImagemA4.SetActive(false);
				OpcaoB.SetActive(false);
				ImagemB4.SetActive(false);
				OpcaoC.SetActive(false);
				ImagemC4.SetActive(false);
				OpcaoD.SetActive(false);
				ImagemD4.SetActive(false);

				contadorTempo = 100;
			}
		}
		else if (errouResposta)
		{
			if (contadorTempo == 280)
			{
				alterarVisibilidadeImagensX(false);
				errouResposta = false;
			}
		}
		else
		{
			if (contadorTempo == 220)
			{
				OpcaoA.SetActive(true);
				ImagemA4.SetActive(true);
			}
			else if (contadorTempo == 240)
			{
				OpcaoB.SetActive(true);
				ImagemB4.SetActive(true);
			}
			else if (contadorTempo == 260)
			{
				OpcaoC.SetActive(true);
				ImagemC4.SetActive(true);
			}
			else if (contadorTempo == 280)
			{
				OpcaoD.SetActive(true);
				ImagemD4.SetActive(true);
			}
		}
	}

	private void processarTempoParaQuintaImagem() {
		if (acertouResposta)
		{
			if (contadorTempo == 280)
			{
				carregarProximoJogo();
			}
		}
		else if (errouResposta)
		{
			if (contadorTempo == 280)
			{
				alterarVisibilidadeImagensX(false);
				errouResposta = false;
			}
		}
		else
		{
			if (contadorTempo == 220)
			{
				OpcaoA.SetActive(true);
				ImagemA4.SetActive(true);
			}
			else if (contadorTempo == 240)
			{
				OpcaoB.SetActive(true);
				ImagemB4.SetActive(true);
			}
			else if (contadorTempo == 260)
			{
				OpcaoC.SetActive(true);
				ImagemC4.SetActive(true);
			}
			else if (contadorTempo == 280)
			{
				OpcaoD.SetActive(true);
				ImagemD4.SetActive(true);
			}
		}
	}				

	private void carregarProximoJogo (){				
		Application.LoadLevel("JOGO1");        
	}

	private void alterarVisibilidadeImagensX(bool visivel) {
		Xa.SetActive(visivel);
		Xb.SetActive(visivel);
		Xc.SetActive(visivel);
		Xd.SetActive(visivel);
	}

	private void alterarVisiblidadeImagensV(bool visivel) {
		Va.SetActive(visivel);
		Vb.SetActive(visivel);
		Vc.SetActive(visivel);
		Vd.SetActive(visivel);
	}

	private void alterarVisibilidadeImagensFeedback(bool visivel) {
		alterarVisibilidadeImagensX(visivel);
		alterarVisiblidadeImagensV (visivel);
	}

	private void alterarVisibilidade(ArrayList elementos, bool visivel) {
		foreach (GameObject elemento in elementos) {
			elemento.SetActive(visivel);
		}
	}

	private void inicializar() {
		Pergunta.SetActive(true);

		ArrayList elementos = new ArrayList();
		elementos.Add(Imagem1);
		elementos.Add(Imagem2);
		elementos.Add(Imagem3);
		elementos.Add(Imagem4);
		elementos.Add(Imagem5);
		elementos.Add(OpcaoA);
		elementos.Add(OpcaoB);
		elementos.Add(OpcaoC);
		elementos.Add(OpcaoD);
		elementos.Add(ImagemA1);
		elementos.Add(ImagemA2);
		elementos.Add(ImagemA3);
		elementos.Add(ImagemA4);
		elementos.Add(ImagemA5);
		elementos.Add(ImagemB1);
		elementos.Add(ImagemB2);
		elementos.Add(ImagemB3);
		elementos.Add(ImagemB4);
		elementos.Add(ImagemB5);
		elementos.Add(ImagemC1);
		elementos.Add(ImagemC2);
		elementos.Add(ImagemC3);
		elementos.Add(ImagemC4);
		elementos.Add(ImagemC5);
		elementos.Add(ImagemD1);
		elementos.Add(ImagemD2);
		elementos.Add(ImagemD3);
		elementos.Add(ImagemD4);
		elementos.Add(ImagemD5);
		elementos.Add(Xa);
		elementos.Add(Xb);
		elementos.Add(Xc);
		elementos.Add(Xd);
		elementos.Add(Va);
		elementos.Add(Vb);
		elementos.Add(Vc);
		elementos.Add(Vd);

		alterarVisibilidade (elementos, false);
	}				
}

