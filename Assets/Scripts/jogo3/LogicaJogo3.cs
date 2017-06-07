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
	public static ArrayList listLetrasJaEncontradas;


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
		listLetrasJaEncontradas = new ArrayList();
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
		listLetrasJaEncontradas.Clear();
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
		Pergunta[] perguntas = new Pergunta[6];
		Pergunta p1=null,p2=null,p3=null,p4=null,p5=null,p6=null;
		switch(idNivelJogador)
		{
		case 1://INICIANTE
			p1 = new Pergunta("banana",new Nivel("facil"),"Macado adora comer");
			p2 = new Pergunta("carro",new Nivel("facil"),"Dirigível");
			p3 = new Pergunta("casa",new Nivel("facil"),"Moradia");
			p4 = new Pergunta("giz",new Nivel("facil"),"Serve para escrever");
			p5 = new Pergunta("acerola",new Nivel("facil"),"Fruta que tem sabor azedinho");
			p6 = new Pergunta("cuca",new Nivel("facil"),"Sinônimo de cabeça");

			break;
		case 2://COMEÇANDO A CAMINHAR
			p1 = new Pergunta("palavra",new Nivel("facil"),"dica1");
			p2 = new Pergunta("palavra",new Nivel("medio"),"dica2");
			p3 = new Pergunta("palavra",new Nivel("medio"),"dica3");
			p4 = new Pergunta("casa",new Nivel("facil"),"Moradia");
			p5 = new Pergunta("palavra",new Nivel("medio"),"dica5");
			p6 = new Pergunta("palavra",new Nivel("medio"),"dica6");
			break;
		case 3://PREPARADO PARA OUTRA
			p1 = new Pergunta("palavra",new Nivel("facil"),"dica1");
			p2 = new Pergunta("palavra",new Nivel("medio"),"dica2");
			p3 = new Pergunta("palavra",new Nivel("medio"),"dica3");
			p4 = new Pergunta("casa",new Nivel("facil"),"Moradia");
			p5 = new Pergunta("palavra",new Nivel("medio"),"dica5");
			p6 = new Pergunta("palavra",new Nivel("medio"),"dica6");
			break;
		case 4://ARRASANDO NA PISTA
			p1 = new Pergunta("palavra",new Nivel("facil"),"dica1");
			p2 = new Pergunta("palavra",new Nivel("medio"),"dica2");
			p3 = new Pergunta("palavra",new Nivel("medio"),"dica3");
			p4 = new Pergunta("casa",new Nivel("facil"),"Moradia");
			p5 = new Pergunta("palavra",new Nivel("medio"),"dica5");
			p6 = new Pergunta("palavra",new Nivel("medio"),"dica6");
			break;
		default:
			break;
		}
		perguntas [0] = p1;
		perguntas [1] = p2;
		perguntas [2] = p3;
		perguntas [3] = p4;
		perguntas [4] = p5;
		perguntas [5] = p6;
		return perguntas;
	}

}
