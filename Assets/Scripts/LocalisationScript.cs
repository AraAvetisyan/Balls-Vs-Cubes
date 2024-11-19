using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class LocalisationScript : MonoBehaviour
{
    public static LocalisationScript Instance;

    [SerializeField] private TextMeshProUGUI newBoostText;
    [Header("Upgrades")]
    [SerializeField] private TextMeshProUGUI upgradesTitleText;

    [SerializeField] private TextMeshProUGUI upgradesHealthText;
    [SerializeField] private TextMeshProUGUI upgradesPowerText;
    [SerializeField] private TextMeshProUGUI upgradesIncomeText;
    [SerializeField] private TextMeshProUGUI upgradesBallsText;

    [Header("Boosts")]
    [SerializeField] private TextMeshProUGUI boostsTitleText;

    [SerializeField] private TextMeshProUGUI ballsBoostText;
    [SerializeField] private TextMeshProUGUI incomeBoostText;
    [SerializeField] private TextMeshProUGUI autoBoostText;
    [SerializeField] private TextMeshProUGUI clickBoostText;

    [SerializeField] private TextMeshProUGUI fireBallText;

    [Header("InAppBoosts")]
    [SerializeField] private TextMeshProUGUI ballForeverText;
    [SerializeField] private TextMeshProUGUI incomeForeverText;
    [SerializeField] private TextMeshProUGUI autoClickForeverText;

    [Header("Header")]
    [SerializeField] private TextMeshProUGUI settingsHeaderText;
    [SerializeField] private TextMeshProUGUI marketHeaderText;
    [SerializeField] private TextMeshProUGUI rebornHeaderText;
    [SerializeField] private TextMeshProUGUI leaderboardHeaderText;
    [SerializeField] private TextMeshProUGUI rebornGameWillStart;

    [Header("Settings")]
    [SerializeField] private TextMeshProUGUI settingsTitleText;
    [SerializeField] private TextMeshProUGUI soundEffectsVolumeText;
    [SerializeField] private TextMeshProUGUI musicVolumeText;
    [SerializeField] private TextMeshProUGUI resetGameText;

    [Header("Reborn")]
    [SerializeField] private TextMeshProUGUI rebornTitleText;
    [SerializeField] private TextMeshProUGUI acceptRebornText;

    [Header("OfflineIncome")]
    [SerializeField] private TextMeshProUGUI offlineIncomeTitleText;
    [SerializeField] private TextMeshProUGUI acceptOfflineIncomeText;

    [Header("ADDS")]
    [SerializeField] private TextMeshProUGUI buyHealthAddText;
    [SerializeField] private TextMeshProUGUI buyPowerAddText;
    [SerializeField] private TextMeshProUGUI buyIncomeAddText;
    [SerializeField] private TextMeshProUGUI buyBallAddText;

    [Header("BallsPower")]
    [SerializeField] private TextMeshProUGUI ball6power;
    [SerializeField] private TextMeshProUGUI ball7power;
    [SerializeField] private TextMeshProUGUI ball8power;
    [SerializeField] private TextMeshProUGUI ball9power;

    [Header("LeaderBoard")]
    [SerializeField] private TextMeshProUGUI leadersText;

    [Header("Yan")]
    [SerializeField] private TextMeshProUGUI[] yans;
    [SerializeField] private int[] prices;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        if (Geekplay.Instance.language == "en")
        {
            upgradesTitleText.text = "UPGRADES";
            upgradesHealthText.text = "HEALTH";
            upgradesPowerText.text = "POWER";
            upgradesIncomeText.text = "INCOME";
            upgradesBallsText.text = "BALLS";

            boostsTitleText.text = "BOOSTS (AD)";
            newBoostText.text = "BOOSTS (FOREVER)";
            ballsBoostText.text = "BALLS";
            incomeBoostText.text = "INCOME";
            autoBoostText.text = "AUTO";
            clickBoostText.text = "CLICK";
            fireBallText.text = "FIREBALL";

            settingsHeaderText.text = "SETTINGS";
            marketHeaderText.text = "MARKET";
            rebornHeaderText.text = "REBIRTH";

            settingsTitleText.text = "SETTINGS";
            soundEffectsVolumeText.text = "SOUND EFFECTS VOLUME";
            musicVolumeText.text = "MUSIC VOLUME";
            resetGameText.text = "RESET GAME";

            rebornTitleText.text = "REBIRTH";
            acceptRebornText.text = "ACCEPT";
            rebornGameWillStart.text = "GAME WILL START AT LEVEL 1";

            offlineIncomeTitleText.text = "OFFLINE INCOME";
            acceptOfflineIncomeText.text = "ACCEPT";

            buyHealthAddText.text = "BUY x3";
            buyPowerAddText.text = "BUY x3";
            buyIncomeAddText.text = "BUY x3";
            buyBallAddText.text = "BUY x3";

            ball6power.text = "x2 POWER";
            ball7power.text = "x2 POWER";
            ball8power.text = "x2 POWER";
            ball9power.text = "x2 POWER";

            leaderboardHeaderText.text = "LEADER BOARD";

            leadersText.text = "LEADERS";
        }
        else if (Geekplay.Instance.language == "ar")
        {
            upgradesTitleText.text = "الترقيات";
            upgradesHealthText.text = "الصحة";
            upgradesPowerText.text = "الطاقة";
            upgradesIncomeText.text = "الدخل";
            upgradesBallsText.text = "البالونات";

            boostsTitleText.text = "التعزيزات";
            newBoostText.text = "يعزز (للأبد)";
            ballsBoostText.text = "البالونات";
            incomeBoostText.text = "الدخل";
            autoBoostText.text = "التلقائي";
            clickBoostText.text = "النقر";
            fireBallText.text = "كرة النار";

            settingsHeaderText.text = "الإعدادات";
            marketHeaderText.text = "السوق";
            rebornHeaderText.text = "ريبيرث";

            settingsTitleText.text = "الإعدادات";
            soundEffectsVolumeText.text = "حجم المؤثرات الصوتية";
            musicVolumeText.text = "صوت الموسيق";
            resetGameText.text = "إعادة ضبط اللعبة";

            rebornTitleText.text = "ريبيرث";
            acceptRebornText.text = "قبول";
            rebornGameWillStart.text = "ستبدأ اللعبة من المستوى 1";

            offlineIncomeTitleText.text = "الدخل غير المباشر";
            acceptOfflineIncomeText.text = "قبول";

            buyHealthAddText.text = "الشراء x3";
            buyPowerAddText.text = "الشراء x3";
            buyIncomeAddText.text = "الشراء x3";
            buyBallAddText.text = "الشراء x3";

            ball6power.text = "x2 الطاقة";
            ball7power.text = "x2 الطاقة";
            ball8power.text = "x2 الطاقة";
            ball9power.text = "x2 الطاقة";

            leaderboardHeaderText.text = "مجلس القيادة";

            leadersText.text = "القادة";
        }
        else if (Geekplay.Instance.language == "es")
        {
            upgradesTitleText.text = "ACTUALIZACIONES";
            upgradesHealthText.text = "SALUD";
            upgradesPowerText.text = "PODER";
            upgradesIncomeText.text = "INGRESOS";
            upgradesBallsText.text = "BOLAS";

            boostsTitleText.text = "AUMENTA (AD)";
            newBoostText.text = "IMPULSORES (PARA SIEMPRE)";
            ballsBoostText.text = "BOLAS";
            incomeBoostText.text = "INGRESOS";
            autoBoostText.text = "AUTO";
            clickBoostText.text = "CLICK";
            fireBallText.text = "BOLA DE FUEGO";

            settingsHeaderText.text = "AJUSTES";
            marketHeaderText.text = "MERCADO";
            rebornHeaderText.text = "RENACIMIENTO";
            rebornGameWillStart.text = "EL JUEGO COMENZARÁ EN EL NIVEL 1";

            settingsTitleText.text = "AJUSTES";
            soundEffectsVolumeText.text = "VOLUMEN DE LOS EFECTOS DE SONIDO";
            musicVolumeText.text = "VOLUMEN DE LA MÚSICA";
            resetGameText.text = "REINICIAR EL JUEGO";

            rebornTitleText.text = "RENACIMIENTO";
            acceptRebornText.text = "ACEPTAR";

            offlineIncomeTitleText.text = "OFFLINE INGRESOS";
            acceptOfflineIncomeText.text = "ACEPTAR";

            buyHealthAddText.text = "COMPRAR x3";
            buyPowerAddText.text = "COMPRAR x3";
            buyIncomeAddText.text = "COMPRAR x3";
            buyBallAddText.text = "COMPRAR x3";

            ball6power.text = "x2 PODER";
            ball7power.text = "x2 PODER";
            ball8power.text = "x2 PODER";
            ball9power.text = "x2 PODER";

            leaderboardHeaderText.text = "TABLA DE LÍDERES";

            leadersText.text = "LÍDERES";
        }
        else if (Geekplay.Instance.language == "ru")
        {
            upgradesTitleText.text = "УЛУЧШЕНИЯ";
            upgradesHealthText.text = "ЗДОРОВЬЕ";
            upgradesPowerText.text = "СИЛА";
            upgradesIncomeText.text = "ДОХОД";
            upgradesBallsText.text = "ШАРИКИ";

            boostsTitleText.text = "УСИЛЕНИЯ (AD)";
            newBoostText.text = "УСИЛЕНИЯ (НАВСЕГДА)";
            ballsBoostText.text = "ШАРИКИ";
            incomeBoostText.text = "ДОХОД";
            autoBoostText.text = "АВТО";
            clickBoostText.text = "КЛИК";
            fireBallText.text = "ОГНЕННЫЙ ШАР";

            settingsHeaderText.text = "НАСТРОЙКИ";
            marketHeaderText.text = "МАГАЗИН";
            rebornHeaderText.text = "ПЕРЕРОЖДЕНИЕ";
            rebornGameWillStart.text = "ИГРА НАЧНЕТСЯ С УРОВНЯ 1";

            settingsTitleText.text = "НАСТРОЙКИ";
            soundEffectsVolumeText.text = "ГРОМКОСТЬ ЗВУКОВЫХ ЭФФЕКТОВ";
            musicVolumeText.text = "ГРОМКОСТЬ МУЗЫКИ";
            resetGameText.text = "СБРОС ИГРЫ";

            rebornTitleText.text = "ПЕРЕРОЖДЕНИЕ";
            acceptRebornText.text = "ПРИНЯТЬ";

            offlineIncomeTitleText.text = "ОФЛАЙН ДОХОД";
            acceptOfflineIncomeText.text = "ПРИНЯТЬ";

            buyHealthAddText.text = "КУПИТЬ x3";
            buyPowerAddText.text = "КУПИТЬ x3";
            buyIncomeAddText.text = "КУПИТЬ x3";
            buyBallAddText.text = "КУПИТЬ x3";

            ball6power.text = "x2 СИЛА";
            ball7power.text = "x2 СИЛА";
            ball8power.text = "x2 СИЛА";
            ball9power.text = "x2 СИЛА";

            leaderboardHeaderText.text = "ТАБЛИЦА ЛИДЕРОВ";

            leadersText.text = "ЛИДЕРЫ";
        }
        else if (Geekplay.Instance.language == "tr")
        {
            upgradesTitleText.text = "YÜKSELTMELER";
            upgradesHealthText.text = "SAĞLIK";
            upgradesPowerText.text = "GÜÇ";
            upgradesIncomeText.text = "GELİR";
            upgradesBallsText.text = "TOPLAR";

            boostsTitleText.text = "BOOSTLAR (AD)";
            newBoostText.text = "ARTIRMALAR (SONSUZA KADAR)";
            ballsBoostText.text = "TOPLAR";
            incomeBoostText.text = "GELİR";
            autoBoostText.text = "OTOMATİK";
            clickBoostText.text = "TIKLAMA";
            fireBallText.text = "ATEŞ TOPU";

            settingsHeaderText.text = "AYARLAR";
            marketHeaderText.text = "PAZAR";
            rebornHeaderText.text = "YENİDEN DOĞUŞ";
            rebornGameWillStart.text = "OYUN 1. SEVIYEDE BAŞLAYACAK";

            settingsTitleText.text = "AYARLAR";
            soundEffectsVolumeText.text = "SES EFEKTLERI SES SEVIYESI";
            musicVolumeText.text = "MÜZİK SESİ";
            resetGameText.text = "OYUNU SIFIRLA";

            rebornTitleText.text = "YENİDEN DOĞUŞ";
            acceptRebornText.text = "KABUL";

            offlineIncomeTitleText.text = "OFFLINE GELİR";
            acceptOfflineIncomeText.text = "KABUL";

            buyHealthAddText.text = "SATIN AL x3";
            buyPowerAddText.text = "SATIN AL x3";
            buyIncomeAddText.text = "SATIN AL x3";
            buyBallAddText.text = "SATIN AL x3";

            ball6power.text = "x2 GÜÇ";
            ball7power.text = "x2 GÜÇ";
            ball8power.text = "x2 GÜÇ";
            ball9power.text = "x2 GÜÇ";

            leaderboardHeaderText.text = "LİDER KURULU";

            leadersText.text = "LİDERLER";
        }
        
        else if (Geekplay.Instance.language == "de")
        {
            upgradesTitleText.text = "UPGRADEN";
            upgradesHealthText.text = "GESUNDHEIT";
            upgradesPowerText.text = "LEISTUNG";
            upgradesIncomeText.text = "EINKOMMEN";
            upgradesBallsText.text = "KUGELN";

            boostsTitleText.text = "BOOSTEN (AD)";
            newBoostText.text = "STEIGERT (FUR IMMER)";
            ballsBoostText.text = "KUGELN";
            incomeBoostText.text = "EINKOMMEN";
            autoBoostText.text = "AUTO";
            clickBoostText.text = "CLICK";
            fireBallText.text = "FEUERKUGELN";

            settingsHeaderText.text = "EINSTELLUNGEN";
            marketHeaderText.text = "MÄRKTE";
            rebornHeaderText.text = "WIEDERGEBURT";
            rebornGameWillStart.text = "DAS SPIEL BEGINNT AUF STUFE 1";

            settingsTitleText.text = "EINSTELLUNGEN";
            soundEffectsVolumeText.text = "LAUTSTÄRKE DER SOUNDEFFEKTE ";
            musicVolumeText.text = "MUSIK LAUTSTÄRKE";
            resetGameText.text = "SPIEL ZURÜCKSETZEN";

            rebornTitleText.text = "WIEDERGEBURT";
            acceptRebornText.text = "AKZEPT";

            offlineIncomeTitleText.text = "OFFLINE-EINKOMMEN";
            acceptOfflineIncomeText.text = "AKZEPT";

            buyHealthAddText.text = "KAUFEN x3";
            buyPowerAddText.text = "KAUFEN x3";
            buyIncomeAddText.text = "KAUFEN x3";
            buyBallAddText.text = "KAUFEN x3";

            ball6power.text = "x2 LEISTUNG";
            ball7power.text = "x2 LEISTUNG";
            ball8power.text = "x2 LEISTUNG";
            ball9power.text = "x2 LEISTUNG";

            leaderboardHeaderText.text = "LEADER BOARD";

            leadersText.text = "FÜHRER";
        }

    }

    public void ChangeYan()
    {
        for(int i = 0; i < yans.Length; i++)
        {
            yans[i].text = prices[i].ToString() + " " + Geekplay.Instance.YanValueType;
        }
    }
}
