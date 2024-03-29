﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class WaveSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float waveSpawnTimer = 5.5f;
    public float countDown = 2f;
    private int waveNumber = 0;
    //public Monster monster;
    public List<Monster> monsters=new List<Monster>();
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
            GameObject enemyGO =Instantiate(enemyPrefab);
            enemyGO.GetComponent<Enemy>().monsterinfo=monsters[0];
            
            
            yield return new WaitForSeconds(0.5f);
        }
    }
}