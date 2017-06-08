using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class pontuacaoJogo2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void onClickOK(){
		SceneManager.LoadScene("InstrucoesJogo3");   
	}

	public void onClickInicio(){
		SceneManager.LoadScene("inicio"); 
	}
}
