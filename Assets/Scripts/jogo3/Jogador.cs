using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador {
	//1 - “INICIANTE“;2-“COMEÇANDO A CAMINHAR”;3–“PREPARADO PARA OUTRA”;4–“ARRASANDO NA PISTA”
	private Nivel nivel;
	private float pontuacaoTotal;

	public Jogador(){
		setNivel(new Nivel(1));
		setPontuacaoTotal(0);
	}

	public void setNivel(Nivel nivel){
		this.nivel = nivel;
	}

	public Nivel getNivel(){
		return nivel;
	}

	public void setPontuacaoTotal(float pontuacaoTotal){
		this.pontuacaoTotal = pontuacaoTotal;
	}

	public float getPontuacaoTotal(){
		return pontuacaoTotal;
	}
}
