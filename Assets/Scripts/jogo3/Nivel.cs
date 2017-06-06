using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nivel{

	private int id;
	private string descricao;
	private int peso;

	public Nivel(){}

	public Nivel(string dificuldade){
		switch(dificuldade)
		{
		case "facil":
			setId(1);
			break;
		case "medio":
			setId(2);
			break;
		case "dificil":
			setId(3);
			break;
		default:
			break;
		}
		this.descricao = dificuldade;
		this.peso = 0;
	}

	public Nivel(int idNivelJogador){
		switch(idNivelJogador)
		{	
		case 1://INICIANTE
			setPeso(1);
			setDescricao("INICIANTE");
			break;
		case 2://COMEÇANDO A CAMINHAR
			setPeso(2);
			setDescricao("COMEÇANDO A CAMINHAR");
			break;
		case 3://PREPARADO PARA OUTRA
			setPeso(3);
			setDescricao("PREPARADO PARA OUTRA");
			break;
		case 4://ARRASANDO NA PISTA
			setPeso (4);
			setDescricao("ARRASANDO NA PISTA");
			break;
		default:
			break;
		}
		setId(idNivelJogador);
	}

		
	public void setId(int id){
		this.id = id;
	}

	public int getId(){
		return id;
	}

	public void setDescricao(string descricao){
		this.descricao = descricao;
	}

	public string getDescricao(){
		return descricao;
	}

	public void setPeso(int peso){
		this.peso = peso;
	}

	public int getPeso(){
		return peso;
	}
}

