using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemyTypes;

    private List<Transform> spawnPositions;


    // Start is called before the first frame update
    void Start()
    {
        spawnPositions = new List<Transform>();
        foreach (Transform childTransform in transform)
        {
            spawnPositions.Add(childTransform);
        }
        StartCoroutine(SpawnMonsters());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnMonsters()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));

            int randomIndex = Random.Range(0, enemyTypes.Length);
            GameObject spawnedMonster = Instantiate(enemyTypes[randomIndex]);
            randomIndex = Random.Range(0, spawnPositions.Count);
            Transform spawnPos = spawnPositions[randomIndex];
            Debug.Log("Spawned at {x: " + spawnPos.position.x + "y: " + spawnPos.position.y + "z: " + spawnPos.position.z + "}");

            spawnedMonster.transform.position = spawnPos.position;
            spawnedMonster.GetComponent<Enemy>().speed = Random.Range(1f, 3f);
        }
    }
}
