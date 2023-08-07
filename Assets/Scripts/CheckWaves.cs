using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CheckWaves : MonoBehaviour
{
    private WaveSpawner _waveSpawner;
    public int enemiesLeft;
  

    private void Awake()
    {
        _waveSpawner = GameObject.Find("Wave Controller").GetComponent<WaveSpawner>();
    }

    private void OnDestroy()
    {
        enemiesLeft = 0;
        enemiesLeft = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (enemiesLeft == 0)
            _waveSpawner.LaunchWave();
    }
   
}
