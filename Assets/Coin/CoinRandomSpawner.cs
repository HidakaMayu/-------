using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRandomSpawner : MonoBehaviour
{
    [SerializeField] Vector4 randomRange;
    [SerializeField] GameObject coinPrefab;
    [SerializeField] int SpawnCount;

    private Vector3 pos;

    [ContextMenu("ExecuteTestCoin")]
    private void CoinSpawn()
    {
        StartCoroutine(Spawn());
    }

    void Start()
    {
        pos = this.transform.position;
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        for (int i = 0; i < SpawnCount; i++)
        {
            Instantiate(coinPrefab,
                pos + new Vector3(Random.Range(randomRange.x, randomRange.y), Random.Range(randomRange.x, randomRange.y), Random.Range(randomRange.z, randomRange.w)),
                Random.rotation);
            yield return null;
        }
    }
}
