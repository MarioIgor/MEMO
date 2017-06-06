using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class Pergunta {

	private string palavra;
	//NÍVEL 1 - (FACIL);NÍVEL 2 - (MEDIO);NÍVEL 3 – (DIFICIL)
	private Nivel dificuldade;
	private int pontuacao;
	private string dica;

	public Pergunta(string palavra,Nivel dificuldade, string dica){
		setPalavra(palavra);
		setNivel(dificuldade);
		setDica (dica);
		switch(dificuldade.getDescricao())
		{
		case "facil":
			setPontuacao (5);
			break;
		case "medio":
			setPontuacao (10);
			break;
		case "dificil":
			setPontuacao (15);
			break;
		default:
			break;
		}

	}


	public void setPalavra(string palavra){
		this.palavra = palavra.ToUpper();
	}

	public string getPalavra(){
		return palavra;
	}

	public void setNivel(Nivel dificuldade){
		this.dificuldade = dificuldade;
	}

	public Nivel getNivel(){
		return dificuldade;
	}

	public void setPontuacao(int pontuacao){
		this.pontuacao = pontuacao;
	}

	public int getPontuacao(){
		return pontuacao;
	}

	public void setDica(string dica){
		this.dica = dica;
	}

	public string getDica(){
		return dica;
	}




}
