using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class LocalisationScript : MonoBehaviour
{
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



    void Start()
    {
        StartCoroutine(WaitAFrameForLocalisation());
    }

    public IEnumerator WaitAFrameForLocalisation()
    {
        yield return new WaitForEndOfFrame();
        if (Geekplay.Instance.language == "en")
        {
            upgradesTitleText.text = "UPGRADES";
            upgradesHealthText.text = "HEALTH";
            upgradesPowerText.text = "POWER";
            upgradesIncomeText.text = "INCOME";
            upgradesBallsText.text = "BALLS";

            boostsTitleText.text = "BOOSTS";
            ballsBoostText.text = "BALLS";
            incomeBoostText.text = "INCOME";
            autoBoostText.text = "AUTO";
            clickBoostText.text = "CLICK";
            fireBallText.text = "FIREBALL";

            ballForeverText.text = "FOREVER";
            incomeForeverText.text = "FOREVER";
            autoClickForeverText.text = "FOREVER";

            settingsHeaderText.text = "SETTINGS";
            marketHeaderText.text = "MARKET";
            rebornHeaderText.text = "REBIRTH";

            settingsTitleText.text = "SETTINGS";
            soundEffectsVolumeText.text = "SOUND EFFECTS VOLUME";
            musicVolumeText.text = "MUSIC VOLUME";
            resetGameText.text = "RESET GAME";

            rebornTitleText.text = "REBIRTH";
            acceptRebornText.text = "ACCEPT";

            offlineIncomeTitleText.text = "OFFLINE INCOME";
            acceptOfflineIncomeText.text = "ACCEPT";

            buyHealthAddText.text = "BUY";
            buyPowerAddText.text = "BUY";
            buyIncomeAddText.text = "BUY";
            buyBallAddText.text = "BUY";
        }
        else if (Geekplay.Instance.language == "ru")
        {
            upgradesTitleText.text = "УЛУЧШЕНИЯ";
            upgradesHealthText.text = "ЗДОРОВЬЕ";
            upgradesPowerText.text = "СИЛА";
            upgradesIncomeText.text = "ДОХОД";
            upgradesBallsText.text = "ШАРИКИ";

            boostsTitleText.text = "УСИЛЕНИЯ";
            ballsBoostText.text = "ШАРИКИ";
            incomeBoostText.text = "ДОХОД";
            autoBoostText.text = "АВТО";
            clickBoostText.text = "КЛИК";
            fireBallText.text = "ОГНЕННЫЙ ШАР";

            ballForeverText.text = "НАВСЕГДА";
            incomeForeverText.text = "НАВСЕГДА";
            autoClickForeverText.text = "НАВСЕГДА";

            settingsHeaderText.text = "НАСТРОЙКИ";
            marketHeaderText.text = "МАГАЗИН";
            rebornHeaderText.text = "ПЕРЕРОЖДЕНИЕ";

            settingsTitleText.text = "НАСТРОЙКИ";
            soundEffectsVolumeText.text = "ГРОМКОСТЬ ЗВУКОВЫХ ЭФФЕКТОВ";
            musicVolumeText.text = "ГРОМКОСТЬ МУЗЫКИ";
            resetGameText.text = "СБРОС ИГРЫ";

            rebornTitleText.text = "ПЕРЕРОЖДЕНИЕ";
            acceptRebornText.text = "ПРИНЯТЬ";

            offlineIncomeTitleText.text = "ОФЛАЙН ДОХОД";
            acceptOfflineIncomeText.text = "ПРИНЯТЬ";

            buyHealthAddText.text = "КУПИТЬ";
            buyPowerAddText.text = "КУПИТЬ";
            buyIncomeAddText.text = "КУПИТЬ";
            buyBallAddText.text = "КУПИТЬ";
        }
        else if (Geekplay.Instance.language == "tr")
        {
            upgradesTitleText.text = "YÜKSELTMELER";
            upgradesHealthText.text = "SAĞLIK";
            upgradesPowerText.text = "GÜÇ";
            upgradesIncomeText.text = "GELİR";
            upgradesBallsText.text = "TOPLAR";

            boostsTitleText.text = "BOOSTLAR";
            ballsBoostText.text = "TOPLAR";
            incomeBoostText.text = "GELİR";
            autoBoostText.text = "OTOMATİK";
            clickBoostText.text = "TIKLAMA";
            fireBallText.text = "ATEŞ TOPU";

            ballForeverText.text = "SONSUZA KADAR";
            incomeForeverText.text = "SONSUZA KADAR";
            autoClickForeverText.text = "SONSUZA KADAR";

            settingsHeaderText.text = "AYARLAR";
            marketHeaderText.text = "PAZAR";
            rebornHeaderText.text = "YENİDEN DOĞUŞ";

            settingsTitleText.text = "AYARLAR";
            soundEffectsVolumeText.text = "SES EFEKTLERI SES SEVIYESI";
            musicVolumeText.text = "MÜZİK SESİ";
            resetGameText.text = "OYUNU SIFIRLA";

            rebornTitleText.text = "YENİDEN DOĞUŞ";
            acceptRebornText.text = "KABUL";

            offlineIncomeTitleText.text = "OFFLINE GELİR";
            acceptOfflineIncomeText.text = "KABUL";

            buyHealthAddText.text = "SATIN AL";
            buyPowerAddText.text = "SATIN AL";
            buyIncomeAddText.text = "SATIN AL";
            buyBallAddText.text = "SATIN AL";
        }
        else if (Geekplay.Instance.language == "pr")
        {
            upgradesTitleText.text = "ACTUALIZAÇÕES";
            upgradesHealthText.text = "SAÚDE";
            upgradesPowerText.text = "PODER";
            upgradesIncomeText.text = "RENDIMENTO";
            upgradesBallsText.text = "BOLAS";

            boostsTitleText.text = "BOOSTS";
            ballsBoostText.text = "BOLAS";
            incomeBoostText.text = "RENDIMENTO";
            autoBoostText.text = "AUTOMÁTICO";
            clickBoostText.text = "CLIQUE";
            fireBallText.text = "BOLA DE FOGO";

            ballForeverText.text = "PARA SEMPRE";
            incomeForeverText.text = "PARA SEMPRE";
            autoClickForeverText.text = "PARA SEMPRE";

            settingsHeaderText.text = "DEFINIÇÕES";
            marketHeaderText.text = "MERCADO";
            rebornHeaderText.text = "RENASCER";

            settingsTitleText.text = "DEFINIÇÕES";
            soundEffectsVolumeText.text = "VOLUME DOS EFEITOS SONOROS";
            musicVolumeText.text = "VOLUME DA MÚSICA";
            resetGameText.text = "REINICIAR O JOGO";

            rebornTitleText.text = "RENASCER";
            acceptRebornText.text = "ACEITO";

            offlineIncomeTitleText.text = "FORA DE LINHA RENDIMENTO";
            acceptOfflineIncomeText.text = "ACEITO";

            buyHealthAddText.text = "COMPRAR";
            buyPowerAddText.text = "COMPRAR";
            buyIncomeAddText.text = "COMPRAR";
            buyBallAddText.text = "COMPRAR";
        }
        else if (Geekplay.Instance.language == "gr")
        {
            upgradesTitleText.text = "UPGRADEN";
            upgradesHealthText.text = "GESUNDHEIT";
            upgradesPowerText.text = "LEISTUNG";
            upgradesIncomeText.text = "EINKOMMEN";
            upgradesBallsText.text = "KUGELN";

            boostsTitleText.text = "BOOSTEN";
            ballsBoostText.text = "KUGELN";
            incomeBoostText.text = "EINKOMMEN";
            autoBoostText.text = "AUTO";
            clickBoostText.text = "CLICK";
            fireBallText.text = "FEUERKUGELN";

            ballForeverText.text = "FÜR IMMER";
            incomeForeverText.text = "FÜR IMMER";
            autoClickForeverText.text = "FÜR IMMER";

            settingsHeaderText.text = "EINSTELLUNGEN";
            marketHeaderText.text = "MÄRKTE";
            rebornHeaderText.text = "WIEDERGEBURT";

            settingsTitleText.text = "EINSTELLUNGEN";
            soundEffectsVolumeText.text = "LAUTSTÄRKE DER SOUNDEFFEKTE ";
            musicVolumeText.text = "MUSIK LAUTSTÄRKE";
            resetGameText.text = "SPIEL ZURÜCKSETZEN";

            rebornTitleText.text = "WIEDERGEBURT";
            acceptRebornText.text = "AKZEPT";

            offlineIncomeTitleText.text = "OFFLINE-EINKOMMEN";
            acceptOfflineIncomeText.text = "AKZEPT";

            buyHealthAddText.text = "KAUFEN";
            buyPowerAddText.text = "KAUFEN";
            buyIncomeAddText.text = "KAUFEN";
            buyBallAddText.text = "KAUFEN";
        }
        else if (Geekplay.Instance.language == "ar")
        {
            upgradesTitleText.text = "الترقيات";
            upgradesHealthText.text = "الصحة";
            upgradesPowerText.text = "الطاقة";
            upgradesIncomeText.text = "الدخل";
            upgradesBallsText.text = "البالونات";

            boostsTitleText.text = "التعزيزات";
            ballsBoostText.text = "البالونات";
            incomeBoostText.text = "الدخل";
            autoBoostText.text = "التلقائي";
            clickBoostText.text = "النقر";
            fireBallText.text = "كرة النار";

            ballForeverText.text = "إلى الأبد";
            incomeForeverText.text = "إلى الأبد";
            autoClickForeverText.text = "إلى الأبد";

            settingsHeaderText.text = "الإعدادات";
            marketHeaderText.text = "السوق";
            rebornHeaderText.text = "ريبيرث";

            settingsTitleText.text = "الإعدادات";
            soundEffectsVolumeText.text = "حجم المؤثرات الصوتية";
            musicVolumeText.text = "صوت الموسيقى";
            resetGameText.text = "إعادة ضبط اللعبة";

            rebornTitleText.text = "ريبيرث";
            acceptRebornText.text = "قبول";

            offlineIncomeTitleText.text = "الدخل غير المباشر";
            acceptOfflineIncomeText.text = "قبول";

            buyHealthAddText.text = "الشراء";
            buyPowerAddText.text = "الشراء";
            buyIncomeAddText.text = "الشراء";
            buyBallAddText.text = "الشراء";
        }
    }
}
