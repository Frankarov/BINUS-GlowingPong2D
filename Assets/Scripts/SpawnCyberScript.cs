using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCyberScript : MonoBehaviour
{
    [SerializeField] GameObject[] powerPrefab;
    [SerializeField] float secondSpawn = 0.5f;
    [SerializeField] float MinTras;
    [SerializeField] float MaxTras;

    void Start()
    {
        StartCoroutine(PowerSpawn());
    }

    IEnumerator PowerSpawn()
    {
        while (true)
        {
            var wanted = Random.Range(MinTras, MaxTras);
            var position = new Vector3(wanted, transform.position.y);
            GameObject gameObject = Instantiate(powerPrefab[Random.Range(0, powerPrefab.Length)], position, Quaternion.identity);
            yield return new WaitForSeconds(secondSpawn);


            Destroy(gameObject, 2f);
        }
    }
}
