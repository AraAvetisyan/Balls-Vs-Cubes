using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelChooser : MonoBehaviour
{
    public static LevelChooser Instance;
    [SerializeField] private GameObject[] levels;
    [SerializeField] private List<GameObject> levelPrefabs;
    [SerializeField] private List<GameObject> higherLevels;
    [SerializeField] private Transform levelsPosition;
    public GameObject CurrentLevel;
    public int CurrentLevelCount;
    public Transform SpawnPoint;
    public TextMeshProUGUI SpawnedText;
    private LevelsUIController _levelsUIController;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        StartCoroutine(WaitAFrame());
    }
    public IEnumerator WaitAFrame()
    {
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        //CurrentLevelCount = Geekplay.Instance.PlayerData.Level;
        //CurrentLevel = Instantiate(levelPrefabs[Geekplay.Instance.PlayerData.Level], levelsPosition);
        //_levelsUIController = CurrentLevel.GetComponent<LevelsUIController>();
        //SpawnPoint = _levelsUIController.SpawnPoint;
        //SpawnedText = _levelsUIController.SpawnText;
        
        //BallSpawner.Instance.SetSpawnPoint();
        //BallSpawner.Instance.LevelStarts = true;
        SpawnNewLevel();
    }

    public void SpawnNewLevel()
    {
        Destroy(CurrentLevel);
        BallSpawner.Instance.LevelStarts = false;
        CurrentLevel = null;
        SpawnPoint = null;
        SpawnedText = null;
        BallSpawner.Instance.spawnedTexts = null;
        BallSpawner.Instance.spawnPoints = null;       
        
        CurrentLevelCount = Geekplay.Instance.PlayerData.Level;

        if (CurrentLevelCount <= 45)
        {
            CurrentLevel = Instantiate(levelPrefabs[Geekplay.Instance.PlayerData.Level], levelsPosition);
            _levelsUIController = CurrentLevel.GetComponent<LevelsUIController>();
        }
        else
        {

            int randLevel = Random.Range(0, higherLevels.Count);
            CurrentLevel = Instantiate(higherLevels[randLevel], levelsPosition);
        }

        SpawnPoint = _levelsUIController.SpawnPoint;
        SpawnedText = _levelsUIController.SpawnText;
        BallSpawner.Instance.SetSpawnPoint();
        BallSpawner.Instance.LevelStarts = true;
    }
}
