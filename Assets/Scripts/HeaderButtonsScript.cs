using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class HeaderButtonsScript : MonoBehaviour
{
    public static HeaderButtonsScript Instance;
    [SerializeField] private int[] rebornOfflineIncome;

    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject rebornPanel;
    [SerializeField] private GameObject passiveIncomePanel;
    [SerializeField] private GameObject marketPanel;
    [SerializeField] private TextMeshProUGUI permenantIncome, reachingLevel, passiveIncome;


    [Header("Reborn")]
    [SerializeField] private GameObject powererButton;
    [SerializeField] private int randMax, randMin;
    private float randStart;
    private int randButton;
    [SerializeField] private GameObject canRebornObject;
    [SerializeField] private Transform logStartPos, logEndPos;
    [SerializeField] private GameObject headerLog;
    [SerializeField] private TextMeshProUGUI headerLogText;

    [Header("")]
    private Coroutine buttonShowCorutine;
    private Coroutine buttonUnshowCorutine;
    private Coroutine pressedUnshowCorutine;
    public bool Pressed;

    [SerializeField] private MarketScript _marketScript;
    [SerializeField] private UpgradesScript _upgradesScript;
    [SerializeField] private MoneyScript _moneyScript;
    [SerializeField] private BoosterUIScript _bosterUIScript;

    [Header("Sounds")]
    [SerializeField] private GameObject buttonSoundPrefab;
    [SerializeField] private AudioSource musicAudio;
    public Slider musicVolumeSlider;
    public Slider soundEffectsVolumeSlider;

    [SerializeField] private GameObject FireBallAudioPrefab;

    [Header("Trails")]
    public bool ChangeMat;

    [Header("FireBallTransforms")]
    [SerializeField] private Transform startPosition;
    [SerializeField] private Transform endPosition;

    [Header("LeaderBoard")]
    [SerializeField] private GameObject leaderBoard;


    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        StartShowCorutine();
    }

    private void Update()
    {
        musicAudio.volume = musicVolumeSlider.value;
        if(Geekplay.Instance.PlayerData.Level >= ((Geekplay.Instance.PlayerData.RebornCount + 1) * 10))
        {
            canRebornObject.SetActive(true);
        }
    }
    public void PressedLeaderBoardButton()
    {
        leaderBoard.SetActive(true);
        BallSpawner.Instance.PanelIsActive = true;
    }
    public void StartShowCorutine()
    {
        buttonShowCorutine = StartCoroutine(ShowButton());
    }
    public void StopShowCorutine()
    {
        if (buttonShowCorutine != null)
        {
            StopCoroutine(buttonShowCorutine);
            buttonShowCorutine = null;
        }
        StartUnshowCorutine();
    }
    public void StartUnshowCorutine()
    {
        buttonUnshowCorutine = StartCoroutine(UnshowButton());
    }
    public void StopUnshowCorutine()
    {
        if (buttonUnshowCorutine != null)
        {
            StopCoroutine(buttonUnshowCorutine);
            buttonUnshowCorutine = null;
        }
        StartShowCorutine();
    }
    public IEnumerator ShowButton()
    {
        randStart = Random.Range(randMax, randMin);
        float duration = randStart;
        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            yield return null;
        }

        powererButton.transform.DOMove(endPosition.position, 0.5f);
        yield return new WaitForSeconds(0.5f);
        AudioSource fireballAudio = Instantiate(FireBallAudioPrefab.GetComponent<AudioSource>());
        fireballAudio.volume = Geekplay.Instance.PlayerData.SoundEffectsVolume;
        fireballAudio.Play();
        Destroy(fireballAudio.gameObject, 1f);
        StopShowCorutine();
    }
    public IEnumerator UnshowButton()
    {
        float duration = 10;
        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            yield return null;
        }
        if (!Pressed)
        {
            powererButton.transform.DOMove(startPosition.position, 0.5f);
        }
        else
        {
            StartPressedCorutine();
        }
        StopUnshowCorutine();
    }
    public void StartPressedCorutine()
    {
        pressedUnshowCorutine = StartCoroutine(UnshowAfterBoost());
    }
    public void StopPressedCorutine()
    {
        if(pressedUnshowCorutine != null)
        {
            StopCoroutine(pressedUnshowCorutine);
            pressedUnshowCorutine = null;
        }
    }
    public IEnumerator UnshowAfterBoost()
    {
        while (Pressed)
        {
            yield return null;
        }
        powererButton.transform.DOMove(startPosition.position, 0.5f);
        StopPressedCorutine();
    }



    public void PressedClose()
    {
        AudioSource spawnedSoundEffect = Instantiate(buttonSoundPrefab.GetComponent<AudioSource>());
        spawnedSoundEffect.volume = soundEffectsVolumeSlider.value;
        spawnedSoundEffect.Play();
        Destroy(spawnedSoundEffect.gameObject, 1f);

        Geekplay.Instance.PlayerData.MusicVolume = musicVolumeSlider.value;
        Geekplay.Instance.PlayerData.SoundEffectsVolume = soundEffectsVolumeSlider.value;

        settingsPanel.SetActive(false);
        rebornPanel.SetActive(false);
        passiveIncomePanel.SetActive(false);
        marketPanel.SetActive(false);
        leaderBoard.SetActive(false);
        BallSpawner.Instance.PanelIsActive = false;
    }
    public void PressedSettingsButton()
    {
        AudioSource spawnedSoundEffect = Instantiate(buttonSoundPrefab.GetComponent<AudioSource>());
        spawnedSoundEffect.volume = soundEffectsVolumeSlider.value;
        spawnedSoundEffect.Play();
        Destroy(spawnedSoundEffect.gameObject, 1f);

        settingsPanel.SetActive(true);
        BallSpawner.Instance.PanelIsActive = true;
    }
    public void PressedMarketButton()
    {
        BallSpawner.Instance.PanelIsActive = true;
        AudioSource spawnedSoundEffect = Instantiate(buttonSoundPrefab.GetComponent<AudioSource>());
        spawnedSoundEffect.volume = soundEffectsVolumeSlider.value;
        spawnedSoundEffect.Play();
        Destroy(spawnedSoundEffect.gameObject, 1f);

        marketPanel.SetActive(true);
        StartCoroutine(_marketScript.WaitAFrameForMarket());
       // StartCoroutine(_marketScript.WaitAFrameForMarket());

    }
    public void PressedRebornButton()
    {
        rebornPanel.SetActive(true);
        BallSpawner.Instance.PanelIsActive = true;
        AudioSource spawnedSoundEffect = Instantiate(buttonSoundPrefab.GetComponent<AudioSource>());
        spawnedSoundEffect.volume = soundEffectsVolumeSlider.value;
        spawnedSoundEffect.Play();
        Destroy(spawnedSoundEffect.gameObject, 1f);

        if (Geekplay.Instance.language == "en")
        {
            permenantIncome.text = "EARNING FOR THE HIT: " + "<color=green>" + (Geekplay.Instance.PlayerData.RebornCount + 1) + "</color>" + " => " + "<color=green>" + (Geekplay.Instance.PlayerData.RebornCount + 2) + "</color>";
            reachingLevel.text = "YOU HAVE TO REACH <color=green>LEVEL" + " " + ((Geekplay.Instance.PlayerData.RebornCount + 1) * 10) + " </color>FOR REBIRTH";
            passiveIncome.text = "OFFLINE INCOME: " + "<color=green>" + rebornOfflineIncome[Geekplay.Instance.PlayerData.RebornCount] + "</color>" + " => " + "<color=green>" + rebornOfflineIncome[Geekplay.Instance.PlayerData.RebornCount+1] + "</color>";
        }
        else if (Geekplay.Instance.language == "ru")
        {
            
            permenantIncome.text = "ДОХОД ЗА УДАР: " + "<color=green>" + (Geekplay.Instance.PlayerData.RebornCount + 1) + "</color>" + " => " + "<color=green>" + (Geekplay.Instance.PlayerData.RebornCount + 2) + "</color>";
            reachingLevel.text = "ВЫ ДОЛЖНЫ ДОСТИЧЬ <color=green>УРОВНЯ" + " " + ((Geekplay.Instance.PlayerData.RebornCount + 1) * 10) + " </color>ДЛЯ ВОЗРОЖДЕНИЯ";
            passiveIncome.text = "ОФФЛАЙН ДОХОД: " + "<color=green>" + rebornOfflineIncome[Geekplay.Instance.PlayerData.RebornCount] + "</color>" + " => " + "<color=green>" + rebornOfflineIncome[Geekplay.Instance.PlayerData.RebornCount+1] + "</color>";
        }
        else if (Geekplay.Instance.language == "tr")
        {
            permenantIncome.text = "VURUŞ IÇIN KAZANÇ: " + "<color=green>" + (Geekplay.Instance.PlayerData.RebornCount + 1) + "</color>" + " => " + "<color=green>" + (Geekplay.Instance.PlayerData.RebornCount + 2) + "</color>";
            reachingLevel.text = "ULAŞMAK ZORUNDASIN <color=green>SEVİYE" + " " + ((Geekplay.Instance.PlayerData.RebornCount + 1) * 10) + " </color>YENİDEN DOĞUŞ İÇİN";
            passiveIncome.text = "OFFLINE GELİR: " + "<color=green>" + rebornOfflineIncome[Geekplay.Instance.PlayerData.RebornCount] + "</color>" + " => " + "<color=green>" + rebornOfflineIncome[Geekplay.Instance.PlayerData.RebornCount+1] + "</color>";
        }
        else if(Geekplay.Instance.language == "es")
        {
            permenantIncome.text = "GANANDO PARA EL GOLPE: " + "<color=green>" + (Geekplay.Instance.PlayerData.RebornCount + 1) + "</color>" + " => " + "<color=green>" + (Geekplay.Instance.PlayerData.RebornCount + 2) + "</color>";
            reachingLevel.text = "TIENES QUE ALCANZAR <color=green>EL NIVEL" + " " + ((Geekplay.Instance.PlayerData.RebornCount + 1) * 10) + " </color>PARA RENACER";
            passiveIncome.text = "OFFLINE RENTA: " + "<color=green>" + rebornOfflineIncome[Geekplay.Instance.PlayerData.RebornCount] + "</color>" + " => " + "<color=green>" + rebornOfflineIncome[Geekplay.Instance.PlayerData.RebornCount+1] + "</color>";
        }
        else if(Geekplay.Instance.language == "de")
        {
            permenantIncome.text = "VERDIENST FÜR DEN HIT: " + "<color=green>" + (Geekplay.Instance.PlayerData.RebornCount + 1) + "</color>" + " => " + "<color=green>" + (Geekplay.Instance.PlayerData.RebornCount + 2) + "</color>";
            reachingLevel.text = "MÜSSEN SIE DIE <color=green>STUFE" + " " + ((Geekplay.Instance.PlayerData.RebornCount + 1) * 10) + " </color>FÜR DIE WIEDERGEBURT";
            passiveIncome.text = "OFFLINE-EINKOMMEN: " + "<color=green>" + rebornOfflineIncome[Geekplay.Instance.PlayerData.RebornCount] + "</color>" + " => " + "<color=green>" + rebornOfflineIncome[Geekplay.Instance.PlayerData.RebornCount+1] + "</color>";
        }
        else if(Geekplay.Instance.language == "ar")
        {
            permenantIncome.text = "الكسب مقابل الضربة: " + (Geekplay.Instance.PlayerData.RebornCount + 1) + " =< " + (Geekplay.Instance.PlayerData.RebornCount + 1);
            reachingLevel.text = "عليك أن تصل إى المستوى" + " " + ((Geekplay.Instance.PlayerData.RebornCount + 1) * 10) + "من أجل العودة إى الحياة";
            passiveIncome.text = "الدخل غير المباشر: " + rebornOfflineIncome[Geekplay.Instance.PlayerData.RebornCount] + " =< " + rebornOfflineIncome[Geekplay.Instance.PlayerData.RebornCount+1];
        }
    }

    public void PressedReborn()
    {
        AudioSource spawnedSoundEffect = Instantiate(buttonSoundPrefab.GetComponent<AudioSource>());
        spawnedSoundEffect.volume = soundEffectsVolumeSlider.value;
        spawnedSoundEffect.Play();
        Destroy(spawnedSoundEffect.gameObject, 1f);

        if (Geekplay.Instance.PlayerData.Level >= ((Geekplay.Instance.PlayerData.RebornCount + 1) * 10))
        {
            canRebornObject.SetActive(false);
            Reset();
            rebornPanel.SetActive(false);
        }
        else if (Geekplay.Instance.PlayerData.Level < (Geekplay.Instance.PlayerData.RebornCount + 1) * 10)
        {
            rebornPanel.SetActive(false);
            headerLog.transform.DOMove(logEndPos.position, 1f);
            if(Geekplay.Instance.language == "en")
                headerLogText.text = "REACH LEVEL: " + ((Geekplay.Instance.PlayerData.RebornCount + 1) * 10).ToString();
            if(Geekplay.Instance.language == "ru")
                headerLogText.text = "ДОСТИГНИТЕ УРОВНЯ: " + ((Geekplay.Instance.PlayerData.RebornCount + 1) * 10).ToString();
            if(Geekplay.Instance.language == "tr")
                headerLogText.text = "ULAŞIM SEVİYESİ: " + ((Geekplay.Instance.PlayerData.RebornCount + 1) * 10).ToString();
            if (Geekplay.Instance.language == "ar")
                headerLogText.text = "مستوى الوصول إلى المستوى: " + ((Geekplay.Instance.PlayerData.RebornCount + 1) * 10).ToString();
            if (Geekplay.Instance.language == "de")
                headerLogText.text = "REACH-EBENE: " + ((Geekplay.Instance.PlayerData.RebornCount + 1) * 10).ToString();
            if (Geekplay.Instance.language == "es")
                headerLogText.text = "NIVEL DE ALCANCE: " + ((Geekplay.Instance.PlayerData.RebornCount + 1) * 10).ToString();
            BallSpawner.Instance.PanelIsActive = false;
            StartCoroutine(WaitForHeaderLog());
        }

    }
    public IEnumerator WaitForHeaderLog()
    {
        yield return new WaitForSeconds(2f);
        headerLog.transform.DOMove(logStartPos.position, 1f);
    }
    public void Reset()
    {
        _bosterUIScript.StopDoubleBallBoost();
        _bosterUIScript.StopAutoClickBoost();
        _bosterUIScript.StopIncomeBoost();

        if (Geekplay.Instance.PlayerData.ForeverAutoClickBoost)
            _bosterUIScript.StopForeverAutoClickBoostCorutine();
        if (Geekplay.Instance.PlayerData.ForeverBallsBoost)
            _bosterUIScript.StopForeverBallsBoostCorutine();
        if (Geekplay.Instance.PlayerData.ForeverIncomeBoost)
            _bosterUIScript.StopForeverIncomeBoostCorutine();

        for (int i = 0; i < BallSpawner.Instance.SpawnedObjects.Count; i++)
        {
            Destroy(BallSpawner.Instance.SpawnedObjects[i]);
        }
        BallSpawner.Instance.SpawnedObjects.Clear();

        Geekplay.Instance.PlayerData.Income = 0;
        Geekplay.Instance.PlayerData.BallHealth = 0;
        Geekplay.Instance.PlayerData.MaxSpawnCount = 0;
        Geekplay.Instance.PlayerData.BallSpeed = 0;
        Geekplay.Instance.PlayerData.BallPower = 0;
        Geekplay.Instance.PlayerData.HealthPrice = 0;
        Geekplay.Instance.PlayerData.PowerPrice = 0;
        Geekplay.Instance.PlayerData.CountPrice = 0;
        Geekplay.Instance.PlayerData.IncomePrice = 0;
        Geekplay.Instance.PlayerData.MoneyToAdd = 0;
        Geekplay.Instance.PlayerData.Level = 0;


        Geekplay.Instance.PlayerData.RebornCount += 1;
        Geekplay.Instance.PlayerData.IsNotFirstTime = false;

        StartCoroutine(BallSpawner.Instance.WaitAFrameForSpawner());
        StartCoroutine(LevelChooser.Instance.WaitAFrame());
        StartCoroutine(_upgradesScript.WaitAFrameForUpgrates());
        StartCoroutine(_moneyScript.WaitAFrameForMoney());
        StartCoroutine(_bosterUIScript.WaitNextFrameForBoosters());
        _marketScript.PressedDollarsButton();
        StartCoroutine(_marketScript.WaitAFrameForMarket());


        Geekplay.Instance.Save();


        BallSpawner.Instance.PanelIsActive = false;

    }
    public void ResetSettings()
    {

        _bosterUIScript.StopDoubleBallBoost();
        _bosterUIScript.StopAutoClickBoost();
        _bosterUIScript.StopIncomeBoost();

        if (Geekplay.Instance.PlayerData.ForeverAutoClickBoost)
            _bosterUIScript.StopForeverAutoClickBoostCorutine();
        if (Geekplay.Instance.PlayerData.ForeverBallsBoost)
            _bosterUIScript.StopForeverBallsBoostCorutine();
        if (Geekplay.Instance.PlayerData.ForeverIncomeBoost)
            _bosterUIScript.StopForeverIncomeBoostCorutine();

        for(int i = 0; i < BallSpawner.Instance.SpawnedObjects.Count; i++)
        {
            Destroy(BallSpawner.Instance.SpawnedObjects[i]);
        }
        BallSpawner.Instance.SpawnedObjects.Clear();

        Geekplay.Instance.PlayerData.Income = 0;
        Geekplay.Instance.PlayerData.BallHealth = 0;
        Geekplay.Instance.PlayerData.MaxSpawnCount = 0;
        Geekplay.Instance.PlayerData.BallSpeed = 0;
        Geekplay.Instance.PlayerData.BallPower = 0;
        Geekplay.Instance.PlayerData.HealthPrice = 0;
        Geekplay.Instance.PlayerData.PowerPrice = 0;
        Geekplay.Instance.PlayerData.CountPrice = 0;
        Geekplay.Instance.PlayerData.IncomePrice = 0;
        Geekplay.Instance.PlayerData.MoneyToAdd = 0;
        Geekplay.Instance.PlayerData.Level = 0;
        Geekplay.Instance.PlayerData.RebornCount = 0;
        Geekplay.Instance.PlayerData.BallsBought[1] = false;
        Geekplay.Instance.PlayerData.BallsBought[2] = false;
        Geekplay.Instance.PlayerData.BallsBought[3] = false;
        Geekplay.Instance.PlayerData.BallsBought[4] = false;

        Geekplay.Instance.PlayerData.BallEnabled[1] = false;
        Geekplay.Instance.PlayerData.BallEnabled[2] = false;
        Geekplay.Instance.PlayerData.BallEnabled[3] = false;
        Geekplay.Instance.PlayerData.BallEnabled[4] = false;

        Geekplay.Instance.PlayerData.BallEnabled[0] = true;
        Geekplay.Instance.PlayerData.IsNotFirstTime = false;
        Geekplay.Instance.Save();


        StartCoroutine(BallSpawner.Instance.WaitAFrameForSpawner());
        StartCoroutine(LevelChooser.Instance.WaitAFrame());
        StartCoroutine(_upgradesScript.WaitAFrameForUpgrates());
        StartCoroutine(_moneyScript.WaitAFrameForMoney());
        StartCoroutine(_bosterUIScript.WaitNextFrameForBoosters());
        _marketScript.PressedDollarsButton();
        StartCoroutine(_marketScript.WaitAFrameForMarket());

        BallSpawner.Instance.PanelIsActive = false;

        
        settingsPanel.SetActive(false);
    }
}
