using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BallSpawner : MonoBehaviour
{
    public static BallSpawner Instance;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private TextMeshProUGUI[] spawnedTexts;
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

    public int MaximumBallCount;

    [SerializeField] ButtonPressPosiition _buttonPressPosiition;



    Vector2 clickPosition;
    [SerializeField] private GameObject cursorImage;
    [SerializeField] private Canvas canvas;
    private Coroutine mouseCorutine;
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
        if(Geekplay.Instance.PlayerData.Level == 0)
        {
            Geekplay.Instance.PlayerData.Level = 1;
        }
        Geekplay.Instance.PlayerData.MaxSpawnCount = Geekplay.Instance.PlayerData.MaxSpawnCount * BallMaxCountBooster;
        SpawnCount = Geekplay.Instance.PlayerData.MaxSpawnCount;
        MaximumBallCount = Geekplay.Instance.PlayerData.MaxSpawnCount;

        PowerBoostTenTimes = 1;
    }
    void Update()
    {
        spawnedTexts[Geekplay.Instance.PlayerData.Level].text = SpawnCount.ToString() + " / " + MaximumBallCount.ToString();
       
        speedSlider.value -= speedSliderValueMin;
        if(speedSlider.value > 20)
        {
            SpeedBoost = 1.85f;
        }
        if(speedSlider.value < 21)
        {
            SpeedBoost = 1;
        }
        if (SpawnCount > MaximumBallCount)
        {
            SpawnCount = MaximumBallCount;
        }
        if (SpawnCount < 0)
        {
            SpawnCount = 0;
        }
    }
    public void SpawnBall()
    {
       
        speedSlider.value += speedSliderValue;
        if (SpawnCount > 0)
        {
            if (SpawnedObjects.Count <= MaximumBallCount)
            {
                SpawnCount--; // = MaximumBallCount - SpawnedObjects.Count;
                SpawnedObjects.Add(Instantiate(ballPrefab, spawnPoints[Geekplay.Instance.PlayerData.Level].transform));
            }
        }
        ActivateCursorAtMousePosition();
    }


    public void ActivateCursorAtMousePosition()
    {
        // Получаем позицию курсора
        Vector2 cursorScreenPosition = Input.mousePosition;

        // Преобразуем экранные координаты в мировые, если нужно
        RectTransformUtility.ScreenPointToWorldPointInRectangle(canvas.transform as RectTransform, cursorScreenPosition, canvas.worldCamera, out Vector3 worldPosition);

        // Устанавливаем курсор в позицию мировых координат
        cursorImage.transform.position = worldPosition;

        // Активируем курсор
        cursorImage.SetActive(true);

        // Запускаем корутину для скрытия курсора
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
