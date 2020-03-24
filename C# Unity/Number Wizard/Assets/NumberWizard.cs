using UnityEngine; 
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NumberWizard : MonoBehaviour { 

	int max , min, chute, maxTentativa = 10; //variáveis utilizadas ao longo do código
	public Text text; //texto modificado no progama

	void Start () { //inicialização
		StartGame(); 
	}
	void StartGame () { //função inicial; os valores de max e min poderiam ter sido ditos antes
		max = 1000; 
		min = 1;
		chute = Random.Range (min, max);
		max = max + 1;
		text.text = chute.ToString ();
	}

	public void ChuteHiguer (){ //para valor maior, diz que a anterior é a "minima"
		min = chute; 
		ProxChute();
	}
	public void ChuteLower (){ //para valor menor, diz que a anterior era a "maxima"
		max = chute; 
		ProxChute(); 
	}
		
	void ProxChute () { //proxima tentativa. faz um chute entre a minima (incluindo ela) e a maxima (sem contar com ela) dadas e mostra na tela
		chute = Random.Range (min, max); 
		text.text = chute.ToString();
		maxTentativa = maxTentativa - 1; //vai diminuindo de acordo com as tentativas, até o numero limite
		if (maxTentativa <= 0) {
			SceneManager.LoadScene ("Win");
		}
		 
	}
}