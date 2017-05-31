using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globoFlip : MonoBehaviour {



	private int i ;

	// Use this for initialization
	void Start () {


	}

	// Update is called once per frame
	void Update(){
		

		i++;

			if (i > 30) {
				
			GetComponent<SpriteRenderer> ().flipX = !(GetComponent<SpriteRenderer> ().flipX); 

				

				i = 0;	
			}

	}
}
