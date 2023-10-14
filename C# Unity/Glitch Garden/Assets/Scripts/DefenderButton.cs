using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab;

    private void OnMouseDown()
    {
        //Procura-se todos aqueles com esse script e, quando clicarmos em um determinado,
        //a cor dos outros objetos com esse script é alterada para uma mais escura (inclusive deste)
        //Entretanto, ao sair foreach, a cor deste defensor em questão é alterada para a padrão e
        // o defensor é passado para classe de spawn
        var buttons = FindObjectsOfType<DefenderButton>();
        foreach(DefenderButton button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(156, 156, 156, 255);
        }
        GetComponent<SpriteRenderer>().color = Color.white;
        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab);
    }
}
