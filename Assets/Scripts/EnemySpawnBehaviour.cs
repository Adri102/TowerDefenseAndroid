using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawnBehaviour : MonoBehaviour {

    [System.Serializable]public class Wave
    {
        public GameObject enemy;
        public float spawnInterval = 2;
        public int maxEnemies = 20;
    }

    public Wave[] waves;
    public float waitWavesTime = 5;

    private float waitWavesCounter;
    private int enemiesSpawned = 0;

    public GameObject enemy;
    public GameObject[] points;

    public bool gameOver;

    public Text waveText;
    public int currentWave;

    // Use this for initialization
    void Start ()
    {
        enemy.GetComponent<EnemyBehaviour>().points = points;
        waveText.text = 0 + "/" + waves.Length;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Space)) currentWave = 0;

        if(!gameOver)
        {
            if(currentWave < waves.Length && currentWave != -1)
            {
                waitWavesCounter += Time.deltaTime;
                float spawnInterval = waves[currentWave].spawnInterval;
                if(((enemiesSpawned == 0 && waitWavesCounter > waitWavesTime) || ((waitWavesCounter > spawnInterval) && enemiesSpawned < waves[currentWave].maxEnemies)))
                {
                    waitWavesCounter = 0;
                    GameObject newEnemy = Instantiate(waves[currentWave].enemy, this.transform);
                    enemiesSpawned++;
                }

                if(enemiesSpawned == waves[currentWave].maxEnemies && GameObject.FindGameObjectWithTag("Enemy") == null)
                {
                    currentWave++;
                    enemiesSpawned = 0;
                    waitWavesCounter = 0;
                }
            }

            waveText.text = (currentWave + 1) + "/" + waves.Length;
        }
    }
}
