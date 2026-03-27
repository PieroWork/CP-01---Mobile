using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{

    [SerializeField] private GameObject[] plataformaPrefab;

    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    private float spawnTempo = 3f;

    
    void Start()
    {
        StartCoroutine(plataformaSpawn());
    }

    IEnumerator plataformaSpawn()
    {
        while (true)
        {
            var local = Random.Range(minX, maxX);
            var position = new Vector3(local, transform.position.y);

            GameObject gameObject = GameObject.Instantiate(plataformaPrefab[Random.Range(0, plataformaPrefab.Length)], position, Quaternion.identity);

            yield return new WaitForSeconds(spawnTempo);

            Destroy(gameObject, 0.75f);
        }

    }

}
