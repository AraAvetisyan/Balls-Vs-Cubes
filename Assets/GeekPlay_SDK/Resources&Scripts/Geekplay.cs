using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.Events;
using TMPro;
using UnityEngine.UI;
using CrazyGames;
using GamePix;

[System.Serializable]
public class Rewards
{
    public string rewardName;
    public UnityEvent rewardEvent;
}

[System.Serializable]
public class Purchases
{
    public string itemName;
    public UnityEvent purchaseEvent;
}

public enum Platform 
{
    Editor,
    Yandex, 
    VK,
    GameArter,
    CrazyGames,
    VKPlay, 
    Kongregate,
    GameDistribution, 
    GamePix,
    OK
}

public class Geekplay : MonoBehaviour
{

    public string YanValueType;
    public string language; //язык
    public bool mobile; //Устройство игрока мобильное?
    public bool SoundOn = true; //Звук включен?
    public PlayerData PlayerData; //сохраняемые данные
    [SerializeField] private Rewards[] rewardsList; //список ревардов
    [SerializeField] private Purchases[] purchasesList; //список покупок

    [Space(50)]
    public Platform Platform; //Платформа
    [SerializeField] private GameObject gameArterPrefab; //Префаб площадки GameArter
    public GameObject leaderboardBtn; //КНОПКА, ОТКРЫВАЮЩАЯ ЛИДЕРБОРД
    public static Geekplay Instance;
    private bool canShowAd = true; //Можно ли проигрывать рекламу на вк?
    private string developerNameYandex = "GeeKid%20-%20школа%20программирования";

    private IEnumerator cor;
    private string rewardTag; //Тэг награды
    private bool adOpen; //Реклама открыта?
    private string purchasedTag; //Тэг покупки
    private bool wasLoad; //Игра загружалась?
    private bool canAd;
    string colorDebug = "yellow"; //Цвет Дебага

    public bool canReward;

    //ЗНАЧЕНИЯ ЛИДЕРБОРДА
    public List<string> lS;
    public List<string> lN;
    public int leaderNumber;
    public int leaderNumberN;
    //public LeaderboardInGame leaderboardInGame;
    public float remainingTimeUntilUpdateLeaderboard;
    public float timeToUpdateLeaderboard = 60;
    public string lastLeaderText;

    public event Action LeaderboardValuesReady;
    public event Action ShowedAdInEditor;
    public bool GameIsReady;

    public bool GameStoped;
    public void RunCoroutine(IEnumerator enumerator)
    {
        StartCoroutine(enumerator);
    }
    public void SubscribeOnReward(string idOrTags , UnityAction action)
    {
        for(int i = 0; i < rewardsList.Length; i++)
        {
            if (idOrTags == rewardsList[i].rewardName)
            {
                rewardsList[i].rewardEvent.AddListener(action);
            }
        }
    }

    public void SubscribeOnPurchase(string idOrTags, UnityAction action)
    {
        for (int i = 0; i < purchasesList.Length; i++)
        {
            if (idOrTags == purchasesList[i].itemName)
            {
                purchasesList[i].purchaseEvent.AddListener(action);
            }
        }
    }


    private void Start()
    {
        //GameReady();

        //ShowInterstitialAd();
        CheckBuysOnStart(PlayerData.lastBuy);
        Utils.GetValueCode();
    }
    public void OnRewarded() //ВОЗНАГРАЖДЕНИЕ ПОСЛЕ ПРОСМОТРА РЕКЛАМЫ
    {
        if (Platform == Platform.CrazyGames || Platform == Platform.GamePix)
            ResumeMusAndGame();

        for (int i = 0; i < rewardsList.Length; i++)
        {
            if (rewardTag == rewardsList[i].rewardName)
            {
                rewardsList[i].rewardEvent.Invoke();
                Save();
            }
        }
        if (cor != null)
            StopCoroutine(cor);
        cor = AdOff();
        StartCoroutine(cor);
    }
    public void GetLeadersScore(string valueAndName)
    {
        string[] parts = valueAndName.Split(',');
        string value = parts[0];
        string leaderboardName = parts[1];

        lS[leaderNumber] = value;

        if (leaderNumber < 5)
        {
            leaderNumber += 1;
            Utils.GetLeaderboard("score", leaderNumber, leaderboardName);
        }
    }

    public void GetLeadersName(string valueAndName)
    {
        string[] parts = valueAndName.Split(',');
        string value = parts[0];
        string leaderboardName = parts[1];

        lN[leaderNumberN] = value;

        if (leaderNumberN < 5)
        {
            leaderNumberN += 1;
            Utils.GetLeaderboard("name", leaderNumberN, leaderboardName);
        }
    }
    public void EndGetLeaderboardsValue()
    {
        LeaderboardValuesReady?.Invoke();
        lN.Clear();
        lS.Clear();
        //if (leaderboard == null) Debug.Log("Leaderboard is null");

        //leaderboard.SetLeadersView(lN.ToArray(), lS.ToArray(), lS.Count);
    }
    IEnumerator AdOff() //ТАЙМЕР С ВЫКЛЮЧЕНИЕМ РЕКЛАМЫ
    {
        canAd = false;
        yield return new WaitForSeconds(180);
        canAd = true;
    }

    IEnumerator AdOn() //ТАЙМЕР БЕЗ ВЫКЛЮЧЕНИЯ РЕКЛАМЫ
    {
        yield return new WaitForSeconds(180);
        canAd = true;
    }

    IEnumerator CanAdShow()
    {
        yield return new WaitForSeconds(60);
        canShowAd = true;
    }

    public void ShowInterstitialAd() //МЕЖСТРАНИЧНАЯ РЕКЛАМА - ПОКАЗАТЬ
    {
        switch (Platform)
        {
            case Platform.Editor:
                Debug.Log($"<color={colorDebug}>INTERSTITIAL SHOW</color>");
                ShowedAdInEditor?.Invoke();
                break;
            case Platform.Yandex:
                Utils.AdInterstitial();
                break;
            case Platform.VK:
                if (canShowAd)
                {
                    canShowAd = false;
                    StartCoroutine(CanAdShow());
                    ////Utils.VK_Interstitial();
                }
                break;
            case Platform.CrazyGames:
               // if (canAd)
               // {
                    CrazyAds.Instance.beginAdBreak(ResumeMusAndGame, ResumeMusAndGame);
                    StopMusAndGame();
                //}
                break;
            case Platform.GameDistribution:
                GameDistribution.Instance.ShowAd();
                break;
            case Platform.GamePix:
                StopMusAndGame();
                Gpx.Ads.InterstitialAd(ResumeMusAndGame);
                break;
            case Platform.OK:
                ////Utils.OK_Interstitial();
                break;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)) 
        {
            PlayerData = new PlayerData();
        }

        remainingTimeUntilUpdateLeaderboard -= Time.deltaTime;
    }

    IEnumerator CanReward()
    {
        yield return new WaitForSeconds(90);
        canReward = true;
    }

    public void ShowRewardedAd(string idOrTag) //РЕКЛАМА С ВОЗНАГРАЖДЕНИЕМ - ПОКАЗАТЬ
    {
        canReward = false;
        StartCoroutine(CanReward());
        switch (Platform)
        {
            case Platform.Editor:
                Debug.Log($"<color={colorDebug}>REWARD SHOW</color>");
                rewardTag = idOrTag;
                OnRewarded();
                break;
            case Platform.Yandex:
                rewardTag = idOrTag;
                Utils.AdReward();
                break;
            case Platform.VK:
                    canShowAd = false;
                    StartCoroutine(CanAdShow());
                    rewardTag = idOrTag;
                    //Utils.VK_Rewarded();
                break;
            case Platform.CrazyGames:
                rewardTag = idOrTag;
                CrazyAds.Instance.beginAdBreakRewarded(OnRewarded, ResumeMusAndGame);
                StopMusAndGame();
                break;
            case Platform.GameDistribution:
                rewardTag = idOrTag;
                GameDistribution.Instance.ShowRewardedAd();
                break;
            case Platform.GamePix:
                rewardTag = idOrTag;
                StopMusAndGame();
                Gpx.Ads.RewardAd(OnRewarded, OnRewarded);
                break;
            case Platform.OK:
                rewardTag = idOrTag;
                //Utils.OK_ShowRewardedAd();
                break;
        }
    }

    public void ShowBannerAd() 
    {
        switch (Platform)
        {
            case Platform.Editor:
#if INIT_DEBUG
                Debug.Log($"<color={colorDebug}>BANNER SHOW</color>");
#endif
                break;
            case Platform.VK:
                //Utils.VK_Banner();
                break;
            case Platform.OK:
                //Utils.OK_ShowBannerAds();
                break;
        }
    }

    //СОЦИАЛЬНЫЕ ФУНКЦИИ
    public void OpenOtherGames() //ССЫЛКА НА ДРУГИЕ ИГРЫ
    {
        switch (Platform)
        {
            case Platform.Editor:
#if INIT_DEBUG
                Debug.Log($"<color={colorDebug}>OPEN OTHER GAMES</color>");
#endif
                break;
            case Platform.Yandex:
                var domain = Utils.GetDomain();
                Application.OpenURL($"https://yandex.{domain}/games/developer?name=" + developerNameYandex);
                break;
            case Platform.VK:
                rewardTag = "Group";
                //Utils.VK_ToGroup();
                break;
        }
    }
    public void RateGameFunc() //ПРОСЬБА ОЦЕНИТЬ ИГРУ
    {
        switch (Platform)
        {
            case Platform.Editor:
                Debug.Log($"<color={colorDebug}>REWIEV GAME</color>");
                break;
            case Platform.Yandex:
                Utils.RateGame();
                break;
            case Platform.OK:
                //Utils.OK_ShowRating();
                break;
        }
    }

    public void Leaderboard(string leaderboardName, int value) //ЗАНЕСТИ В ЛИДЕРБОРД
    {
        switch (Platform)
        {
            case Platform.Editor:
                Debug.Log($"<color={colorDebug}>SET LEADERBOARD:</color> {value}");
                break;
            case Platform.Yandex:
                Utils.SetToLeaderboard(value, leaderboardName);
                break;
            //case Platform.VK:
            //    if (mobile)
                    //Utils.VK_OpenLeaderboard(value);
            //    break;
        }
    }

    public void ToStarGame() //ДОБАВИТЬ В ИЗБРАННОЕ (ВК)
    {
        switch (Platform)
        {
            case Platform.Editor:
                Debug.Log($"<color={colorDebug}>GAME TO STAR</color>");
                break;
            case Platform.Yandex:
                break;
            case Platform.VK:
                //Utils.VK_Star();
                break;
        }
    }

    public void ShareGame() //ПОДЕЛИТЬСЯ ИГРОЙ (ВК)
    {
        switch (Platform)
        {
            case Platform.Editor:
                Debug.Log($"<color={colorDebug}>SHARE</color>");
                break;
            case Platform.Yandex:
                break;
            case Platform.VK:
                //Utils.VK_Share();
                break;
        }
    }
    
    public void InvitePlayers() //ПРИГЛАСИТЬ ИГРОКОВ (ВК)
    {
        switch (Platform)
        {
            case Platform.Editor:
                Debug.Log($"<color={colorDebug}>INVITE</color>");
                break;
            case Platform.Yandex:
                break;
            case Platform.VK:
                //Utils.VK_Invite();
                break;
        }
    }

    public void LeaderboardBtn(int value) //Для кнопки лидерборда в VK
    {
        //value = playerData.Level;
        switch (Platform)
        {
            case Platform.Editor:
                Debug.Log($"<color={colorDebug}>SET LEADERBOARD:</color> {value}");
                break;
            case Platform.Yandex:
                break;
            case Platform.VK:
                //Utils.VK_OpenLeaderboard(value);
                break;
        }
    }

    //СОХАРЕНИЕ И ЗАГРУЗКА
    public void Save() //СОХРАНЕНИЕ
    {
        string jsonString = "";

        switch (Platform)
        {
            case Platform.Editor:
                jsonString = JsonUtility.ToJson(PlayerData);
                PlayerPrefs.SetString("PlayerData", jsonString);
                Debug.Log("SAVE: " + jsonString);
                break;
            case Platform.Yandex:
                jsonString = JsonUtility.ToJson(PlayerData);
                Utils.SaveExtern(jsonString);
                Debug.Log("SAVE: " + jsonString);
                break;
            case Platform.VK:
                if (wasLoad == false)
                {
                    break;
                }
                jsonString = JsonUtility.ToJson(PlayerData);
                //Utils.VK_Save(jsonString);
                break;
            case Platform.CrazyGames:
                jsonString = JsonUtility.ToJson(PlayerData);
                PlayerPrefs.SetString("PlayerData", jsonString);

                if (CrazyAvailableCheck())
                {
                	CrazyUser.Instance.SyncUnityGameData();
                }
                break;
            case Platform.Kongregate:
                jsonString = JsonUtility.ToJson(PlayerData);
                PlayerPrefs.SetString("PlayerData", jsonString);
                break;
        }
    }

    public void SetPlayerData(string value) //ЗАГРУЗКА
    {
        PlayerData = JsonUtility.FromJson<PlayerData>(value);
        Debug.Log("LOAD " + JsonUtility.ToJson(PlayerData));
    }

    //АВТОМАТИЧЕСКАЯ СМЕНА ПЛАТФОРМЫ
    public void ChangePlatform(string dom)
    {
        if (dom.Contains("yandex"))
        {
            Platform = Platform.Yandex;
            AfterPlatformChange();
            return;
        }
        else if (dom.Contains("vk") && dom.Contains("play"))
        {
            Platform = Platform.VKPlay;
            AfterPlatformChange();
            return;
        }
        else if (dom.Contains("vk"))
        {
            Platform = Platform.VK;
            AfterPlatformChange();
            return;
        }
        else if (dom.Contains("kongregate"))
        {
            Platform = Platform.Kongregate;
            AfterPlatformChange();
            return;
        }
        else if (dom.Contains("gamepix"))
        {
            Platform = Platform.GamePix;
            AfterPlatformChange();
            return;
        }

        Debug.Log("PLATFORM CHANGE: " + Platform);
        Debug.Log("PLATFORM DOMAIN: " + dom);
        AfterPlatformChange();
    }

    void AfterPlatformChange()
    {
        canAd = false;
        StartCoroutine(AdOn());
        //Старт площадок
        switch (Platform)
        {
            case Platform.Editor:
                if (PlayerPrefs.HasKey("PlayerData"))
                {
                    string jsonString = PlayerPrefs.GetString("PlayerData");
                    PlayerData =  JsonUtility.FromJson<PlayerData>(jsonString);     
                }
                else
                {
                    PlayerData = new PlayerData();
                }
              //  language = "ru"; //ВЫБРАТЬ ЯЗЫК ДЛЯ ТЕСТОВ. ru/en/tr/
                Localization();
                break;
            case Platform.Yandex:
                language = Utils.GetLang();
                Localization();
                break;
            /*case Platform.VK:
                language = "ru";
                Localization();
                StartCoroutine(BannerVK());
                StartCoroutine(RewardLoad());
                StartCoroutine(InterLoad());
                if (wasLoad)
                    //Utils.VK_Load();
                break;*/
            case Platform.CrazyGames:
                language = "en";
                Localization();
                if (PlayerPrefs.HasKey("PlayerData"))
                {
                    string jsonString = PlayerPrefs.GetString("PlayerData");
                    PlayerData =  JsonUtility.FromJson<PlayerData>(jsonString);     
                }
                else
                {
                    PlayerData = new PlayerData();
                }

                if (!CrazyAvailableCheck())
                	CrazyAuth();
                break;
            case Platform.Kongregate:
                PlayerData = new PlayerData();
                language = "en";
                Localization();
                if (PlayerPrefs.HasKey("PlayerData"))
                {
                    string jsonString = PlayerPrefs.GetString("PlayerData");
                    PlayerData =  JsonUtility.FromJson<PlayerData>(jsonString);     
                }
                else
                {
                    PlayerData = new PlayerData();
                }
                break;
            case Platform.GameDistribution:
                PlayerData = new PlayerData();
                language = "en";
                Localization();
                if (PlayerPrefs.HasKey("PlayerData"))
                {
                    string jsonString = PlayerPrefs.GetString("PlayerData");
                    PlayerData =  JsonUtility.FromJson<PlayerData>(jsonString);     
                }
                else
                {
                    PlayerData = new PlayerData();
                }
                GameDistribution.OnResumeGame += ResumeMusAndGame;
                GameDistribution.OnPauseGame += StopMusAndGame;
                GameDistribution.OnPreloadRewardedVideo += OnPreloadRewardedVideo;
                GameDistribution.OnRewardedVideoSuccess += OnRewardedVideoSuccess;
                GameDistribution.OnRewardedVideoFailure += OnRewardedVideoFailure;
                GameDistribution.OnRewardGame += OnRewarded;
                break;
            case Platform.GamePix:
                PlayerData = new PlayerData();
                language = "en";
                Localization();
                if (PlayerPrefs.HasKey("PlayerData"))
                {
                    string jsonString = PlayerPrefs.GetString("PlayerData");
                    PlayerData =  JsonUtility.FromJson<PlayerData>(jsonString);     
                }
                else
                {
                    PlayerData = new PlayerData();
                }
                break;
        }
    }

    protected void Awake()
    { 
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            //Destroy(gameObject);
        }

        if (Platform == Platform.GameDistribution || Platform == Platform.CrazyGames || Platform == Platform.Editor)
        {
            AfterPlatformChange();
        }

        canReward = true;

    }

    //ЗАГРУЗКА РЕКЛАМЫ
    void LoadBanner()
    {
        if (Platform == Platform.OK)
        {   
            //Utils.OK_RequestBannerAds();
        }
    }
    IEnumerator RewardLoad()
    {
        yield return new WaitForSeconds(15);
        switch (Platform)
        {
            case Platform.Editor:
                Debug.Log($"<color={colorDebug}>REWARD LOAD</color>");
                break;
            case Platform.VK:
                //Utils.VK_AdRewardCheck();
                break;
            case Platform.OK:
                //Utils.OK_LoadRewardedAd();
                break;
        }
    }

    IEnumerator InterLoad()
    {
        while (true)
        {   
            yield return new WaitForSeconds(15);
            switch (Platform)
            {
                case Platform.Editor:
                    Debug.Log($"<color={colorDebug}>INTERSTITIAL LOAD</color>");
                    break;
                case Platform.VK:
                    //Utils.VK_AdInterCheck();
                    break;
            }
        }
    }

    IEnumerator BannerVK()
    {
        yield return new WaitForSeconds(5);
        ShowBannerAd();
    }

    //ПЕРЕВОД
    public void Localization()
    {

    }

    //ВНУТРИИГРОВЫЕ ПОКУПКИ
    public void RealBuyItem(string idOrTag) //открыть окно покупки
    {
        switch (Platform)
        {
            case Platform.Editor:
                purchasedTag = idOrTag;
                OnPurchasedItem();
                Debug.Log($"<color={colorDebug}>PURCHASE: </color> {purchasedTag}");
                break;
            case Platform.Yandex:
                PlayerData.lastBuy = idOrTag;
                purchasedTag = idOrTag;
                string jsonString = "";
                jsonString = JsonUtility.ToJson(PlayerData);
                Utils.BuyItem(idOrTag, jsonString);
                break;
            case Platform.VK:
                purchasedTag = idOrTag;
                Debug.Log($"<color={colorDebug}>PURCHASE VK</color>");
                break;
            case Platform.Kongregate:
                purchasedTag = idOrTag;
                //Utils.Kongregate_InApp(idOrTag);
                break;
            /*case Platform.CrazyGames:
            	purchasedTag = idOrTag;

            	GetXsollaToken();

            	XsollaCatalog.Purchase(
					purchasedTag,
					onSuccess => OnPurchasedItem(),
					onError => OnPurchaseError());
            	break;*/
        }
    }

    private void OnPurchaseError()
	{

	}

    private void OnPurchasedItem() //начислить покупку (при удачной оплате)
    {
        PlayerData.lastBuy = "";
        for (int i = 0; i < purchasesList.Length; i++)
        {
            if (purchasedTag == purchasesList[i].itemName)
            {
                purchasesList[i].purchaseEvent.Invoke();
                Save();
            }
        }
    }

    public void CheckBuysOnStart(string idOrTag) //проверить покупки на старте
    {
        purchasedTag = idOrTag;
        Utils.CheckBuyItem(idOrTag);
    }

    public void SetPurchasedItem() //начислить уже купленные предметы на старте
    {
            for (int i = 0; i < purchasesList.Length; i++)
            {
                if (PlayerData.lastBuy == purchasesList[i].itemName)
                {
                    purchasesList[i].purchaseEvent.Invoke();
                    PlayerData.lastBuy = "";
                    Save();
                }
            }
    }

    //CRAZY GAMES ONLY
    public bool CrazyAvailableCheck()
    {
    	bool b = false;

    	CrazyUser.Instance.IsUserAccountAvailable(available =>
		{
		    if (available)
		    {
		        b = true;
		    }
		});

		return b;
    }

    public bool CrazyUserCheck()
    {
    	bool b = false;

    	CrazyUser.Instance.GetUser(user =>
		{
		    if (user != null)
		    {
		        b = true;
		    }
		});

		return b;
    }

    public void CrazyAuth()
    {
    	CrazyUser.Instance.ShowAuthPrompt((error, user) =>
		{
		    if (error != null)
		    {
		        return;
		    }
		});
    }

    public void GetXsollaToken()
    {
    	CrazyUser.Instance.GetXsollaUserToken((error, token) =>
		{
		    if (error != null)
		    {
		       // XsollaToken.Create(token);
		        return;
		    }
		});
    }

    //СОБЫТИЯ ДЛЯ GAMEDISTRIBUTION
    public void OnPreloadRewardedVideo(int loaded)
    {
        // Feedback about preloading ad after called GameDistribution.Instance.PreloadRewardedAd
        // 0: SDK couldn't preload ad
        // 1: SDK preloaded ad
    }
    public void OnRewardedVideoSuccess()
    {
        // Rewarded video succeeded/completed.;
    }

    public void OnRewardedVideoFailure()
    {
        // Rewarded video failed.;
    }




    //ПАУЗА И ПРОДОЛЖЕНИЕ ИГРЫ
    public void StopMusAndGame()
    {

        adOpen = true;
        canShowAd = false;
        StartCoroutine(CanAdShow());
        AudioListener.volume = 0;
        Time.timeScale = 0;
    }

    public void ResumeMusAndGame()
    {
        adOpen = false;
        AudioListener.volume = 1;
        Time.timeScale = 1;
        if (GameIsReady)
        {
            GameStart();
        }

        ////////////////
    }

    //ФОКУС И ЗВУК
    void OnApplicationFocus(bool hasFocus)
    {
        Silence(!hasFocus);
    }

    void OnApplicationPause(bool isPaused)
    {
        Silence(isPaused);
    }

    private void Silence(bool silence)
    {
        AudioListener.volume = silence ? 0 : 1;
        Time.timeScale = silence ? 0 : 1;

        if (adOpen)
        {
            Time.timeScale = 0;
            AudioListener.volume = 0;
        }

        if (GameStoped)
        {
            Time.timeScale = 0;
        }
        //////////
    }

    public void ItIsMobile()
    {
        mobile = true;
    }
    public void GameStart()
    {
        if (Platform == Platform.Yandex)
            Utils.GameStart();
    }
    public void GameReady()
    {
        GameIsReady = true;
        if (Platform == Platform.Yandex)
            Utils.GameReady();
    }
    public void GameStop()
    {
        GameIsReady = false;
        if (Platform == Platform.Yandex)
            Utils.GameStop();
    }


    public void ChangeYanType()
    {
        YanValueType = "TST";
        LocalisationScript.Instance.ChangeYan();
        //if (SceneManager.GetActiveScene().name != "MainMenu")
        //{
        //    LocalizationGameplay.lG.Localization();
        //}
        //if (LocalizationMenu.instance != null)
        //{
        //    LocalizationMenu.instance.YanLocalization();
        //}
        //if (GameplayLocalization.instance != null)
        //{
        //    GameplayLocalization.instance.YanLocalization();
        //}
    }
}
