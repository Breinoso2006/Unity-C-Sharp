using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // deve ser adicionado para o programa reconhecer o tipo "text"

public class TextController : MonoBehaviour {

	public Text text; 
	private enum Situacao {cela, espelho, folhas_0, porta_0, espelho_cela, folhas_1, porta_1, corredor_0, corredor_1, corredor_2, porta_armario, armario, armario_2, armario_3, escadas_0, escadas_1, escadas_2, liberdade, final}; //enumerador
	private Situacao atual;

	void situacao_cela(){
		text.text = "Você acorda em uma prisão.\nNo seu quarto só há uma cama, com algumas folhas de papel em cima, e um pequeno espelho na parede. " + // posso fazer isso para melhor me organizar
					"Além disso, a porta da cela está trancada pelo lado de fora.\n\nPressione E para analisar o espelho, F para ver as folhas ou " +
					"P para verificar a porta da cela.";
		if (Input.GetKeyDown (KeyCode.F)) {
			atual = Situacao.folhas_0;
		}
		if (Input.GetKeyDown (KeyCode.P)) {
			atual = Situacao.porta_0;
		}
		if (Input.GetKeyDown (KeyCode.E)) {
			atual = Situacao.espelho;
		}
	}

	void situacao_folhas_0(){
		text.text = "Você não acredita que conseguiu dormir em cima dessas folhas.\n'Certamente as coisas mudaram... Os prazeres da vida na prisão, eu acho.'\nÉ o que pensa." +
					"\n\nPressione R para retornar e continuar verificando a cela.";
		if (Input.GetKeyDown (KeyCode.R)) {
			atual = Situacao.cela;
		}
	}

	void situacao_folhas_1(){
		text.text = "Parece que não há como utilizar as folhas e o espelho em conjunto.\n\nPressione R para retornar e continuar verificando a cela.";
		if (Input.GetKeyDown (KeyCode.R)) {
			atual = Situacao.espelho_cela;
		}
	}

	void situacao_porta_0(){
		text.text = "A tranca é daquele tipo que precisa de uma senha. A única forma de sair seria com a combinação mestra de números." +
					"\n\nPressione R para retornar e continuar verificando a cela.";
		if (Input.GetKeyDown (KeyCode.R)) {
			atual = Situacao.cela;
		}
	}

	void situacao_porta_1(){
		text.text = "Você passa o espelho, cuidadosamente, entre as barras e o vira em sua direção. Pronto! Agora consegue enxergar o mecanismo.\n'Parece que alguns números estão desgastados...'" +
					"\n\nPressione A para tentar abrir a porta ou R para retornar à cela.";
		if (Input.GetKeyDown (KeyCode.A)) {
			atual = Situacao.corredor_0;
		}
		if (Input.GetKeyDown (KeyCode.R)){
			atual = Situacao.espelho_cela;
		}
	}

	void situacao_espelho(){
		text.text = "Esse velho espelho pode ser facilmente retirado da parede.\n\n Pressione P para pegá-lo ou R para retornar e continuar verificando a cela.";
		if (Input.GetKeyDown (KeyCode.P)) {
			atual = Situacao.espelho_cela;
		}
		if (Input.GetKeyDown (KeyCode.R)) {
			atual = Situacao.cela;
		}
	}

	void situacao_espelho_cela(){
		text.text = "Agora você tem um espelho em mãos.\n\nPressione F para verificar as folhas ou P para ver a porta.";
		if (Input.GetKeyDown (KeyCode.F)) {
			atual = Situacao.folhas_1;
		}
		if (Input.GetKeyDown (KeyCode.P)) {
			atual = Situacao.porta_1;
		}
	}

	void situacao_corredor_0(){
		text.text = "'Opa, há alguns botões mais apagados. Será que...'\nCLICK! A porta se abre inesperadamente!" +
					"Na sua esquerda há escadas para o andar de cima e, na sua direita, há um armário.\n\n" +
					"Aperte S para subir as escadas, A para verificar o armário ou C para continuar pelo corredor.";
		if (Input.GetKeyDown (KeyCode.S)) {
			atual = Situacao.escadas_0;
		}
		if (Input.GetKeyDown (KeyCode.A)) {
			atual = Situacao.porta_armario;
		}
		if (Input.GetKeyDown (KeyCode.C)) {
			atual = Situacao.corredor_1;
		}
	}

	void situacao_escadas_0(){
		text.text = "'Ok, apenas outras celas... Acho que não há nada para se fazer aqui.'" +
					"\n\nAperte R para retornar.";
		if (Input.GetKeyDown (KeyCode.R)) {
			atual = Situacao.corredor_0;
	}
}

	void situacao_porta_armario(){
		text.text = "'Hm... apenas um armário trancado. Não há como abrir de mãos vazias.'" +
					"\n\nAperte R para retornar.";
		if (Input.GetKeyDown (KeyCode.R)) {
			atual = Situacao.corredor_0;
		}
	}

	void situacao_corredor_1(){
		text.text = "'Aparentemente não há nada neste corredor também... Opa, acho que vejo algo...'" +
					"\nVocê avista uma presilha de cabelo no chão." +
					"\n\nAperte P para pegá-la.";
		if (Input.GetKeyDown (KeyCode.P)) {
			atual = Situacao.corredor_2;
		}
	}

	void situacao_corredor_2 (){
		text.text = "'Ok, agora eu tenho uma presilha de cabelo... uau...!'" +
					"\n\nAperte S para subir as escadas ou A para verificar o armário.";
		if (Input.GetKeyDown (KeyCode.S)) {
			atual = Situacao.escadas_1;
		}
		if (Input.GetKeyDown (KeyCode.A)) {
			atual = Situacao.armario;
		}
	}

	void situacao_escadas_1 () {
		text.text = "'Mesmo com essa presilha, não há o que fazer por aqui.'" +
					"\n\nAperte R para retornar.";
		if (Input.GetKeyDown (KeyCode.R)) {
			atual = Situacao.corredor_2;
		}
	}

	void situacao_armario () {
		text.text = "'Parece que minha antiga vida de stalker vai servir para algo...'" +
					"\n\nAperte A para abrir o armário ou R para retornar.";
		if (Input.GetKeyDown (KeyCode.A)) {
			atual = Situacao.armario_2;
		}
		if (Input.GetKeyDown (KeyCode.R)) {
			atual = Situacao.corredor_2;
		}
	}

	void situacao_armario_2 () {
		text.text = "Há um túnel na parte de baixo do armário." +
					"\n\nAperte S para seguir em diante.";
		if (Input.GetKeyDown (KeyCode.S)) {
			atual = Situacao.liberdade;
		}
	}

	void situacao_liberdade () {
		text.text = "Você seguiu o caminho até o final e escapou da prisão! " +
					"Entretanto, ainda se pergunta quem cavou aquele túnel e como você foi parar ali. " +
					"\n\nAperte C para continuar.";
		if (Input.GetKeyDown (KeyCode.C)) {
			atual = Situacao.final;
		}
	}

	void situacao_final () {
		text.text = "Esse é apenas o fim de um novo começo..." +
			"\n\n\nUm jogo de Bruno Reinoso";
		}

	// Use this for initialization
	void Start () {
		atual = Situacao.cela;
	}

	// Update is called once per frame
	void Update () 
	{
		print (atual);
		if (atual == Situacao.cela) {
			situacao_cela ();
		} else if (atual == Situacao.folhas_0) {
			situacao_folhas_0 ();
		} else if (atual == Situacao.porta_0) {
			situacao_porta_0 ();
		} else if (atual == Situacao.folhas_1) {
			situacao_folhas_1 ();
		} else if (atual == Situacao.porta_1) {
			situacao_porta_1 ();
		} else if (atual == Situacao.espelho) {
			situacao_espelho ();
		} else if (atual == Situacao.espelho_cela) {
			situacao_espelho_cela ();
		} else if (atual == Situacao.corredor_0) {
			situacao_corredor_0 ();
		} else if (atual == Situacao.escadas_0) {
			situacao_escadas_0 ();
		} else if (atual == Situacao.porta_armario) {
			situacao_porta_armario ();
		} else if (atual == Situacao.corredor_1) {
			situacao_corredor_1 ();
		} else if (atual == Situacao.corredor_2) {
			situacao_corredor_2 ();
		} else if (atual == Situacao.escadas_1) {
			situacao_escadas_1 ();
		} else if (atual == Situacao.armario) {
			situacao_armario ();
		} else if (atual == Situacao.armario_2) {
			situacao_armario_2 ();
		} else if (atual == Situacao.liberdade) {
			situacao_liberdade ();
		} else if (atual == Situacao.final) {
			situacao_final ();
		}
	}
}

//if (Input.GetKeyDown(KeyCode.Space)) // serve para mudar algo quando a tecla é pressionada. Note que há diferenças entre GetKey, GetKeyDown e GetKeyUp
