using System.Collections;
using UnityEngine;


public class Pisos : MonoBehaviour
{

    [SerializeField] private GameObject[] floorPrefab;
    [SerializeField] private float spawnLocationMin;
    [SerializeField] private float spawnLocationMax;
    private float SpawnTimer = 0.75f;

    void Start()
    {
        StartCoroutine(FloorSpawn());
    }

    IEnumerator FloorSpawn()
    {
        while (true)
        {
            var local = Random.Range(spawnLocationMin, spawnLocationMax);
            var position = new Vector3(local, transform.position.y);

            GameObject gameObject = GameObject.Instantiate(floorPrefab[Random.Range(0, floorPrefab.Length)], position, Quaternion.identity);

            yield return new WaitForSeconds(SpawnTimer);

            Destroy(gameObject, 0.75f);
        }
    }
}
