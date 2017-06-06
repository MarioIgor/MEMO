using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util{

	//returna -1, caso nao seja encontrada. Senao, retorna a posicao dentro da palavra
	public  static bool[] contemLetra(string letraDigitada, Pergunta p){
		char[] letras = p.getPalavra ().ToUpper().ToCharArray ();
		bool[] value = new bool[letras.Length];
		bool isContemLetra = false;
		string element="";
		for (int i = 0; i < letras.Length; i++) {
			element = letras [i].ToString();
			if (element.Equals (letraDigitada)){
				isContemLetra = true;
				value [i] = true;
			} else {
				value [i] = false;
			}
		}	

		if (isContemLetra) {
			return value; 
		}

		return null;

	}
}
