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
    public Color[] LightColors;
    public int ColorIndex;

    public Color FireBallColor;
    [SerializeField] private GameObject ballSpawnEffect;

    [SerializeField] private TextMeshProUGUI sliderText;
    [SerializeField] private float StopValue;

    [Header("Tutorial")]
    [SerializeField] private GameObject tutorImage;


    [Header("Scripts")]
    [SerializeField] private LevelChooser _levelChooser;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {

        Geekplay.Instance.GameStart();
        Geekplay.Instance.GameReady();
        SpawnerStart();
    }
    public void SpawnerStart()
    {
        if (Geekplay.Instance.PlayerData.MaxSpawnCount == 0)
        {
            Geekplay.Instance.PlayerData.MaxSpawnCount = 1;
        }
        if (Geekplay.Instance.PlayerData.BallSpeed == 0)
        {
            Geekplay.Instance.PlayerData.BallSpeed = 2f;
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
        if(Geekplay.Instance.PlayerData.SoundEffectsVolume == 0)
        {
            Geekplay.Instance.PlayerData.SoundEffectsVolume = 1;
        }
        if (Geekplay.Instance.PlayerData.MusicVolume == 0)
        {
            Geekplay.Instance.PlayerData.MusicVolume = 0.35f;
        }
        if(!Geekplay.Instance.PlayerData.UnshowTutor)
        {
            tutorImage.SetActive(true);
        }
        else
        {
            tutorImage.SetActive(false);
        }

        MaximumBallCount = Geekplay.Instance.PlayerData.MaxSpawnCount * BallMaxCountBooster;
        SpawnCount = Geekplay.Instance.PlayerData.MaxSpawnCount * BallMaxCountBooster;

        PowerBoostTenTimes = 1;

        Geekplay.Instance.Save();

        HeaderButtonsScript.Instance.soundEffectsVolumeSlider.value = Geekplay.Instance.PlayerData.SoundEffectsVolume;
        HeaderButtonsScript.Instance.musicVolumeSlider.value = Geekplay.Instance.PlayerData.MusicVolume;

        _levelChooser.LevelChooserStart();
        MoneyScript.Instance.MoneyText.text = "$" + FormatMoney(Geekplay.Instance.PlayerData.MoneyToAdd);
        MoneyScript.Instance.MoneyStart();
        
    }

    void Update()
    {
        if (Geekplay.Instance.GameStoped)
        {
            cursorImage.SetActive(false);
        }
        if (!Geekplay.Instance.GameStoped)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ActivateCursorAtMousePosition();
            }
        }

        if (LevelStarts)
        {
            spawnedTexts.text = SpawnCount.ToString() + " / " + MaximumBallCount.ToString();
        }
        if (!Geekplay.Instance.GameStoped)
        {
            speedSlider.value -= speedSliderValueMin;
            StopValue = speedSlider.value;
        }
        if (Geekplay.Instance.GameStoped)
        {
            speedSlider.value = StopValue;
        }

        if (speedSlider.value >= 2.06f)
        {
            sliderText.text = "x2";
            SpeedBoost = 2f;
        }
        if (speedSlider.value < 2f)
        {
            sliderText.text = "x1";
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnBall();
        }
    }

    public void SetSpawnPoint()
    {
        spawnPoints = LevelChooser.Instance.SpawnPoint;
        spawnedTexts = LevelChooser.Instance.SpawnedText;
        
    }
    public void SpawnBall()
    {
        if (!Geekplay.Instance.GameStoped)
        {
            if (tutorImage.activeSelf)
            {
                tutorImage.SetActive(false);
                Geekplay.Instance.PlayerData.UnshowTutor = true;
            }
           

            speedSlider.value += speedSliderValue;
            if (SpawnCount > 0)
            {
                if (SpawnedObjects.Count <= MaximumBallCount)
                {
                    SpawnCount--; // = MaximumBallCount - SpawnedObjects.Count;
                    SpawnedObjects.Add(Instantiate(ballPrefab, spawnPoints.transform));
                }
            }
        }
        //ActivateCursorAtMousePosition();
    }


    public void ActivateCursorAtMousePosition()
    {
        Vector2 cursorScreenPosition = Input.mousePosition;

        RectTransformUtility.ScreenPointToWorldPointInRectangle(canvas.transform as RectTransform, cursorScreenPosition, canvas.worldCamera, out Vector3 worldPosition);

        cursorImage.transform.position = worldPosition;

        cursorImage.SetActive(true);

        AudioSource ballSpawnAudio = Instantiate(ballSpawnEffect.GetComponent<AudioSource>());
        ballSpawnAudio.volume = Geekplay.Instance.PlayerData.SoundEffectsVolume;
        ballSpawnAudio.Play();
        Destroy(ballSpawnAudio.gameObject, 1f);

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

    string FormatMoney(double value)
    {
        string[] suffixes = { "", "k", "m", "b", "t", "aa", "ab", "ac", "ad", "ae", "af", "ag", "ah", "ai", "aj", "ak", "al", "am", "an", "ao", "ap", "aq", "ar", "as", "at", "au", "av", "aw", "ax", "ay", "az" };
        int suffixIndex = 0;

        while (value >= 1000 && suffixIndex < suffixes.Length - 1)
        {
            value /= 1000;
            suffixIndex++;
        }

        if (value >= 1000)
        {
            value = 999.99;
        }

        return $"{value:0.#}{suffixes[suffixIndex]}";
    }
}
