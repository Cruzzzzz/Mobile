using UnityEngine;
using System.Collections;

public class FishSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] fishPrefabs;
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private Transform spawnPoint;

    private void Start()
    {
        StartCoroutine(SpawnFishRoutine());
    }

    private IEnumerator SpawnFishRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            int index = Random.Range(0, fishPrefabs.Length);
            Instantiate(fishPrefabs[index], spawnPoint.position, Quaternion.identity);
        }
    }
}

