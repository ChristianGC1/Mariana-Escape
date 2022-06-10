using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    public GameObject spawnerPrefab;

    [SerializeField]
    private float spawnerInterval = 3.5f;

    private void Start()
    {
        StartCoroutine(spawnEnemy(spawnerInterval, spawnerPrefab));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-100f, 100), Random.Range(-120f, 120f), 0), Quaternion.identity, GameObject.Find("Enemies").transform);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}