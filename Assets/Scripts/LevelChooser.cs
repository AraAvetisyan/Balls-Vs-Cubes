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
       // LevelChooserStart();
    }
    public void LevelChooserStart()
    {
        if(Geekplay.Instance.PlayerData.MaxLevel == 0)
        {
            Geekplay.Instance.PlayerData.MaxLevel = 1;
        }
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
        }
        else
        {
            int randLevel = Random.Range(0, higherLevels.Count);
            CurrentLevel = Instantiate(higherLevels[randLevel], levelsPosition);
            Debug.Log(CurrentLevelCount);
        }

        _levelsUIController = CurrentLevel.GetComponent<LevelsUIController>();
        SpawnPoint = _levelsUIController.SpawnPoint;
        SpawnedText = _levelsUIController.SpawnText;
        BallSpawner.Instance.SetSpawnPoint();
        BallSpawner.Instance.LevelStarts = true;
        if(Geekplay.Instance.PlayerData.MaxLevel < Geekplay.Instance.PlayerData.Level)
        {
            Geekplay.Instance.PlayerData.MaxLevel = Geekplay.Instance.PlayerData.Level;            
            Geekplay.Instance.Leaderboard("Levels", Geekplay.Instance.PlayerData.MaxLevel);
            if (Geekplay.Instance.PlayerData.Level == 3 && Geekplay.Instance.PlayerData.MaxLevel == 3)
            {
                Geekplay.Instance.RateGameFunc();
            }
            else if (Geekplay.Instance.PlayerData.Level == 6 && Geekplay.Instance.PlayerData.MaxLevel == 6)
            {
                Geekplay.Instance.RateGameFunc();
            }
            else if (Geekplay.Instance.PlayerData.Level == 9 && Geekplay.Instance.PlayerData.MaxLevel == 9)
            {
                Geekplay.Instance.RateGameFunc();
            }
            else if (Geekplay.Instance.PlayerData.Level == 12 && Geekplay.Instance.PlayerData.MaxLevel == 12)
            {
                Geekplay.Instance.RateGameFunc();
            }
            else if (Geekplay.Instance.PlayerData.Level == 15 && Geekplay.Instance.PlayerData.MaxLevel == 15)
            {
                Geekplay.Instance.RateGameFunc();
            }
            else if (Geekplay.Instance.PlayerData.Level == 18 && Geekplay.Instance.PlayerData.MaxLevel == 18)
            {
                Geekplay.Instance.RateGameFunc();
            }
            else if (Geekplay.Instance.PlayerData.Level == 21 && Geekplay.Instance.PlayerData.MaxLevel == 21)
            {
                Geekplay.Instance.RateGameFunc();
            }
            else if (Geekplay.Instance.PlayerData.Level == 24 && Geekplay.Instance.PlayerData.MaxLevel == 24)
            {
                Geekplay.Instance.RateGameFunc();
            }
            else if (Geekplay.Instance.PlayerData.Level == 27 && Geekplay.Instance.PlayerData.MaxLevel == 27)
            {
                Geekplay.Instance.RateGameFunc();
            }
            else if (Geekplay.Instance.PlayerData.Level == 30 && Geekplay.Instance.PlayerData.MaxLevel == 30)
            {
                Geekplay.Instance.RateGameFunc();
            }
            else if (Geekplay.Instance.PlayerData.Level == 33 && Geekplay.Instance.PlayerData.MaxLevel == 33)
            {
                Geekplay.Instance.RateGameFunc();
            }
            else if (Geekplay.Instance.PlayerData.Level == 36 && Geekplay.Instance.PlayerData.MaxLevel == 36)
            {
                Geekplay.Instance.RateGameFunc();
            }
            else if (Geekplay.Instance.PlayerData.Level == 39 && Geekplay.Instance.PlayerData.MaxLevel == 39)
            {
                Geekplay.Instance.RateGameFunc();
            }
            else if (Geekplay.Instance.PlayerData.Level == 42 && Geekplay.Instance.PlayerData.MaxLevel == 42)
            {
                Geekplay.Instance.RateGameFunc();
            }
            else if (Geekplay.Instance.PlayerData.Level == 45 && Geekplay.Instance.PlayerData.MaxLevel == 45)
            {
                Geekplay.Instance.RateGameFunc();
            }
            else if (Geekplay.Instance.PlayerData.Level == 48 && Geekplay.Instance.PlayerData.MaxLevel == 48)
            {
                Geekplay.Instance.RateGameFunc();
            }
            else if (Geekplay.Instance.PlayerData.Level == 51 && Geekplay.Instance.PlayerData.MaxLevel == 51)
            {
                Geekplay.Instance.RateGameFunc();
            }
            else if (Geekplay.Instance.PlayerData.Level == 54 && Geekplay.Instance.PlayerData.MaxLevel == 54)
            {
                Geekplay.Instance.RateGameFunc();
            }
            else if (Geekplay.Instance.PlayerData.Level == 57 && Geekplay.Instance.PlayerData.MaxLevel == 57)
            {
                Geekplay.Instance.RateGameFunc();
            }
            else if (Geekplay.Instance.PlayerData.Level == 60 && Geekplay.Instance.PlayerData.MaxLevel == 60)
            {
                Geekplay.Instance.RateGameFunc();
            }
        }
        Geekplay.Instance.Save();
        _levelsUIController.LevelsUIStart();
    }
}
