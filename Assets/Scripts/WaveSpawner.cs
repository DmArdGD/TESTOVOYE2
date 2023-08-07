using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private Waves[] _waves;
    private int _currentEnemyIndex;
    private int _currentWaveIndex;
    public int _enemiesLeftToSpawn;
    public GameObject YouWinPanel;
    private int EnemiesLeft;


    private void Start()
    {
        _enemiesLeftToSpawn = _waves[0].WaveSettings.Length;
        LaunchWave();
        
    }

    private IEnumerator SpawnEnemyInWave()
    {
        if(_enemiesLeftToSpawn > 0)
        {
            yield return new WaitForSeconds(_waves[_currentWaveIndex].WaveSettings[_currentEnemyIndex].SpawnDelay);
            Instantiate(_waves[_currentWaveIndex].WaveSettings[_currentEnemyIndex].Enemy,_waves[_currentWaveIndex].WaveSettings[_currentEnemyIndex].NeededSpawner.transform.position, Quaternion.identity);
            _enemiesLeftToSpawn--;
            _currentEnemyIndex++;
            StartCoroutine(SpawnEnemyInWave());
        }
        else
        {
            if (_currentWaveIndex < _waves.Length - 1)
            {
                _currentWaveIndex++;
                _enemiesLeftToSpawn = _waves[_currentWaveIndex].WaveSettings.Length;
                _currentEnemyIndex = 0;
            }
        }
       
    }
    private void Update()
    {
        YouWIN();
    }
    public void YouWIN()
    {
        EnemiesLeft = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (_enemiesLeftToSpawn == 0 && EnemiesLeft == 0)
        {
            YouWinPanel.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    public void LaunchWave()
    {
        StartCoroutine(SpawnEnemyInWave());
    }
}

[System.Serializable]
public class Waves 
{
    [SerializeField] private WaveSettings[] _waveSettings;
    public WaveSettings[] WaveSettings { get => _waveSettings; }
}

[System.Serializable]
public class WaveSettings
{
    [SerializeField] private GameObject _enemy;
    public GameObject Enemy { get => _enemy; }
    [SerializeField] private GameObject _neededSpawner;
    public GameObject NeededSpawner { get => _neededSpawner; }
    [SerializeField] private float _spawnDelay;
    public float SpawnDelay { get => _spawnDelay; }
}
