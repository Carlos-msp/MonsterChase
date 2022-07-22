using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemyTypes;
    [SerializeField]
    private Transform[] spawnPositions;


    // Start is called before the first frame update
    void Start()
    {
         StartCoroutine(SpawnMonsters());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnMonsters() {
        yield return new WaitForSeconds(Random.Range(1,5));

        int randomIndex = Random.Range(0, enemyTypes.Length);
        GameObject spawnedMonster = Instantiate(enemyTypes[randomIndex]);
        randomIndex = Random.Range(0, spawnPositions.Length);
        Transform spawnPos = spawnPositions[randomIndex];

        spawnedMonster.transform.position = spawnPos.position;
        spawnedMonster.GetComponent<Enemy>().speed = Random.Range(1f, 3f);
    }
}
