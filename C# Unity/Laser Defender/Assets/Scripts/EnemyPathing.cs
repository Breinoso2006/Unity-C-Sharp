using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    WaveConfig waveConfig; //this
    List<Transform> waypoints; //lista de pontos para movimento
    int waypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig; //linka a variavel usada nesta classe com a deste metodo
    }

    private void Move()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            var targetPosition = waypoints[waypointIndex].transform.position; //proximo alvo
            var movementThisFrame = waveConfig.GetMoveSpeed() * Time.deltaTime; //garante a veloc q eu quero
            transform.position = Vector2.MoveTowards
                (transform.position, targetPosition, movementThisFrame); //faz a movimentação

            if (transform.position == targetPosition)
            {
                waypointIndex++; //quando o alvo for atingido, garante a movimentacao para o proximo
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
