using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BallSpawner : MonoBehaviour
{
    public static BallSpawner Instance;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private TextMeshProUGUI spawnedText;
    public List<GameObject> SpawnedObjects;
    public int SpawnCount = 0;
    public float SpeedBoost = 1;
    public int IncomeBoost = 1;
    [SerializeField] private Slider speedSlider;
    [SerializeField] private float speedSliderValue;
    [SerializeField] private float speedSliderValueMin;
    public int BallMaxCountBooster = 1;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        
        if (Geekplay.Instance.PlayerData.MaxSpawnCount == 0)
        {
            Geekplay.Instance.PlayerData.MaxSpawnCount = 1;
            Geekplay.Instance.Save();
        }
        if (Geekplay.Instance.PlayerData.BallSpeed == 0)
        {
            Geekplay.Instance.PlayerData.BallSpeed = 3.5f;
            Geekplay.Instance.Save();
        }
        Geekplay.Instance.PlayerData.MaxSpawnCount = Geekplay.Instance.PlayerData.MaxSpawnCount * BallMaxCountBooster;
        SpawnCount = Geekplay.Instance.PlayerData.MaxSpawnCount;
    }
    void Update()
    {
        spawnedText.text = SpawnCount.ToString() + " / " + Geekplay.Instance.PlayerData.MaxSpawnCount.ToString();
        //if (Input.GetMouseButtonDown(0))
        //{
        //    if (EventSystem.current.IsPointerOverGameObject())
        //    {
        //        return;
        //    }
        //   SpawnBall();
        // }
        speedSlider.value -= speedSliderValueMin;
        if(speedSlider.value > 21)
        {
            SpeedBoost = 1.85f;
        }
        if(speedSlider.value < 21)
        {
            SpeedBoost = 1;
        }
    }
    public void SpawnBall()
    {
        speedSlider.value += speedSliderValue;
        if (SpawnCount > 0)
        {
            SpawnCount--;
            SpawnedObjects.Add(Instantiate(ballPrefab, spawnPoint.transform));
        }
    }
}
