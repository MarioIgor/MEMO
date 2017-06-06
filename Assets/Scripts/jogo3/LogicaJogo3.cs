using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class LogicaJogo3 : MonoBehaviour{

	private Pergunta[] perguntas;
	public static int quantidadeTentativas; 
	public static Pergunta perguntaAtual;
	public static int quantidadeLetrasAcertadas;
	public static int iteracoesDoJogo;
	public static int quantidadePerguntasJogo;
	public static int contadorRespostasCertas;

	void Start(){
		iniciarJogo ();
	}

	void Update () {
		if (isTerminouRodada ()) {
			proximaRodada ();
		}
	}	

	public void iniciarJogo(){
		Jogador j1 = new Jogador ();
		quantidadeTentativas = 10;
		perguntas= criarPerguntas(j1.getNivel ().getId());
		iteracoesDoJogo = 0;
		contadorRespostasCertas = 0;
		perguntaAtual = perguntas[iteracoesDoJogo];
		quantidadeLetrasAcertadas = 0;
		quantidadePerguntasJogo = perguntas.Length;


	}

	public void proximaRodada(){
		quantidadeTentativas = 10;
		quantidadeLetrasAcertadas = 0;
		iteracoesDoJogo++;
		if (iteracoesDoJogo < perguntas.Length) {
			perguntaAtual = perguntas [iteracoesDoJogo];
		} else {
			SceneManager.LoadScene("pontuacaoJogo3"); 
		}
	}

	public bool isTerminouRodada(){
		if (quantidadeTentativas == 0 || jogadorAcertouPergunta ())
			return true;
		return false;
	}

	public Boolean jogadorAcertouPergunta(){
		if (perguntaAtual.getPalavra ().Length == quantidadeLetrasAcertadas) {
			contadorRespostasCertas++;
			return true;
		}	
		return false;
	}

	 public Pergunta[] criarPerguntas(int idNivelJogador){
		Pergunta[] perguntas = new Pergunta[3];
		Pergunta p1=null,p2=null,p3=null;
		switch(idNivelJogador)
		{
		case 1://INICIANTE
			p1 = new Pergunta("banana",new Nivel("facil"),"Macaco gosta de Comer");
			p2 = new Pergunta("carro",new Nivel("facil"),"Dirigivel");
			p3 = new Pergunta("casa",new Nivel("facil"),"Moradia");
			break;
		case 2://COMEÇANDO A CAMINHAR
			p1 = new Pergunta("palavra1",new Nivel("facil"),"dica1");
			p2 = new Pergunta("palavra2",new Nivel("medio"),"dica2");
			p3 = new Pergunta("casa",new Nivel("facil"),"Moradia");
			break;
		case 3://PREPARADO PARA OUTRA
			p1 = new Pergunta("palavra1",new Nivel("medio"),"dica1");
			p2 = new Pergunta("palavra2",new Nivel("dificil"),"dica2");
			p3 = new Pergunta("casa",new Nivel("facil"),"Moradia");
			break;
		case 4://ARRASANDO NA PISTA
			p1 = new Pergunta("palavra1",new Nivel("dificil"),"dica1");
			p2 = new Pergunta("palavra2",new Nivel("dificil"),"dica2");
			p3 = new Pergunta("casa",new Nivel("facil"),"Moradia");
			break;
		default:
			break;
		}
		perguntas [0] = p1;
		perguntas [1] = p2;
		perguntas [2] = p3;
		return perguntas;
	}

}
