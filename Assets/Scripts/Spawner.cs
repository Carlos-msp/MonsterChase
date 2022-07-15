using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] spawnTarget;
    private int randomIndex;


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

        randomIndex = Random.Range(0, spawnTarget.Length);
    }
}
