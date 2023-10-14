using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [Header ("Spawn")]
    [SerializeField] float minSpawnDelay = 5f;
    [SerializeField] float maxSpawnDelay = 15f;
    [SerializeField] Attacker[] attackerPrefab;

    bool spawn = true;

    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    public void StopSpawning()
    {
        spawn = false;
    }

    private void SpawnAttacker()
    {
        Attacker newAttacker = Instantiate
            (attackerPrefab[Random.Range(0,attackerPrefab.Length)],
            transform.position, Quaternion.identity) as Attacker;
        newAttacker.transform.parent = transform;
    }

}
