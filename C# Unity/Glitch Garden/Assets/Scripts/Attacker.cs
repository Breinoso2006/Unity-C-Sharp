using UnityEngine;

public class Attacker : MonoBehaviour
{
    float movementSpeed;

    private void Awake()
    {
        //Serve para controle da quantidade de atacantes na fase (aumenta)
        FindObjectOfType<LevelController>().AttackerSpawned();
    }

    private void OnDestroy()
    {
        //Serve para controle de quantidade de atacantes na fase (decrementa)
        LevelController levelController = FindObjectOfType<LevelController>();
        if (levelController!= null)
        {
            levelController.AttackerKilled();
        }
    }

    void Update()
    {
        //Utilizado para determinar a velocidade de movimentação do atacante
        transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
    }

    public float SetMovementSpeed( float movementSpeed)
    {
        //Utlizado para setar a variável de velocidade do atacante
        this.movementSpeed = movementSpeed;
        return movementSpeed;
    }
}
