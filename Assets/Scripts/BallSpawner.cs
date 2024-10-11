using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BallSpawner : MonoBehaviour
{
    public bool LevelStarts;
    public static BallSpawner Instance;
    public Transform spawnPoints;
    [SerializeField] private GameObject ballPrefab;
    public TextMeshProUGUI  spawnedTexts;
    public List<GameObject> SpawnedObjects;
    public int SpawnCount = 0;
    public float SpeedBoost = 1;
    public float FireSpeedBoost = 1;
    public int IncomeBoost = 1;
    public int PowerBoostTenTimes;
    [SerializeField] private Slider speedSlider;
    [SerializeField] private float speedSliderValue;
    [SerializeField] private float speedSliderValueMin;
    public int BallMaxCountBooster = 1;


    public int ShopBallPower;

    public int MaximumBallCount;

    public bool PanelIsActive;
    

    [SerializeField] ButtonPressPosiition _buttonPressPosiition;



    Vector2 clickPosition;
    [SerializeField] private GameObject cursorImage;
    [SerializeField] private Canvas canvas;
    private Coroutine mouseCorutine;


    public Color[] BallColors;
    public Color[] TrailColors;
    public int ColorIndex;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {

        Geekplay.Instance.GameStart();
        Geekplay.Instance.GameReady();
        StartCoroutine(WaitAFrameForSpawner());
    }
    public IEnumerator WaitAFrameForSpawner()
    {
        if (Geekplay.Instance.PlayerData.MaxSpawnCount == 0)
        {
            Geekplay.Instance.PlayerData.MaxSpawnCount = 1;
        }
        if (Geekplay.Instance.PlayerData.BallSpeed == 0)
        {
            Geekplay.Instance.PlayerData.BallSpeed = 3f;
        }
        if (Geekplay.Instance.PlayerData.Level == 0)
        {
            Geekplay.Instance.PlayerData.Level = 1;
        }
        if (Geekplay.Instance.PlayerData.BallsBought == null)
        {
            Geekplay.Instance.PlayerData.BallsBought = new bool[9];
            Geekplay.Instance.PlayerData.BallsBought[0] = true;
        }
        if (Geekplay.Instance.PlayerData.BallEnabled == null)
        {
            Geekplay.Instance.PlayerData.BallEnabled = new bool[9];
            Geekplay.Instance.PlayerData.BallEnabled[0] = true;
        }

        yield return new WaitForEndOfFrame();
        // Geekplay.Instance.PlayerData.MaxSpawnCount = Geekplay.Instance.PlayerData.MaxSpawnCount * BallMaxCountBooster;
       
        SpawnCount = Geekplay.Instance.PlayerData.MaxSpawnCount;
        MaximumBallCount = Geekplay.Instance.PlayerData.MaxSpawnCount;

        PowerBoostTenTimes = 1;


        yield return new WaitForEndOfFrame();
        Geekplay.Instance.Save();
    }

    void Update()
    {
        if (LevelStarts)
        {
            spawnedTexts.text = SpawnCount.ToString() + " / " + MaximumBallCount.ToString();
        }
        speedSlider.value -= speedSliderValueMin;
        if(speedSlider.value >= 2)
        {
            SpeedBoost = 2f;
        }
        if(speedSlider.value < 2)
        {
            SpeedBoost = speedSlider.value;
        }
        if (SpawnCount > MaximumBallCount)
        {
            SpawnCount = MaximumBallCount;
        }
        if (SpawnCount < 0)
        {
            SpawnCount = 0;
        }


        if (Geekplay.Instance.PlayerData.BallEnabled[8])
        {
            ShopBallPower = 2;
        }
        else if (Geekplay.Instance.PlayerData.BallEnabled[7])
        {
            ShopBallPower = 2;
        }
        else if (Geekplay.Instance.PlayerData.BallEnabled[6])
        {
            ShopBallPower = 2;
        }
        else if (Geekplay.Instance.PlayerData.BallEnabled[5])
        {
            ShopBallPower = 2;
        }
        else
        {
            ShopBallPower = 1;
        }
    }

    public void SetSpawnPoint()
    {
        spawnPoints = LevelChooser.Instance.SpawnPoint;
        spawnedTexts = LevelChooser.Instance.SpawnedText;
        
    }
    public void SpawnBall()
    {
       
        speedSlider.value += speedSliderValue;
        if (SpawnCount > 0)
        {
            if (SpawnedObjects.Count <= MaximumBallCount)
            {
                SpawnCount--; // = MaximumBallCount - SpawnedObjects.Count;
                SpawnedObjects.Add(Instantiate(ballPrefab, spawnPoints.transform));
            }
        }
        ActivateCursorAtMousePosition();
    }


    public void ActivateCursorAtMousePosition()
    {
        Vector2 cursorScreenPosition = Input.mousePosition;

        RectTransformUtility.ScreenPointToWorldPointInRectangle(canvas.transform as RectTransform, cursorScreenPosition, canvas.worldCamera, out Vector3 worldPosition);

        cursorImage.transform.position = worldPosition;

        // ���������� ������
        cursorImage.SetActive(true);

        StartMouseCorutine();
    }
    public void StartMouseCorutine()
    {

        mouseCorutine = StartCoroutine(MousePosition());
    }
    public void StopMouseCorutine()
    {
        if (mouseCorutine != null)
        {
            mouseCorutine = null;
            StopCoroutine(MousePosition());
        }
    }
    public IEnumerator MousePosition()
    {
        yield return new WaitForSeconds(0.08f);
        cursorImage.SetActive(false);
    }
}
