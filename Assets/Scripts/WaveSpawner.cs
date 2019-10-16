using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public float waveSpawnTimer = 5.5f;
    public float countDown = 2f;
    private int waveNumber = 0;
   // public Text countDownText;
    private void Update()
    {
        if (waveNumber == 5)
            return;
        if (countDown <= 0)
        {
            StartCoroutine(spawnWave());

            countDown = waveSpawnTimer;
        }
        countDown -= Time.deltaTime;
        //countDownText.text = Mathf.Round(countDown).ToString();
    }

    IEnumerator spawnWave()
    {
        waveNumber++;
        //Debug.Log("Wave Incoming");
        for (int i = 0; i < waveNumber; i++)
        {
            Instantiate(enemyPrefab);
            yield return new WaitForSeconds(0.5f);
        }
    }
}