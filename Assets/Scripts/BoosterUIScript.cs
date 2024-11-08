using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BoosterUIScript : MonoBehaviour
{
    public Button incomeButton;
    public Button autoClickButton;
    public Button doubleBallButton;

    [SerializeField] private Image incomeImage;
    [SerializeField] private Image autoClickImage;
    [SerializeField] private Image doubleBallImage;

    [SerializeField] private TextMeshProUGUI doubleBallText;
    [SerializeField] private TextMeshProUGUI autoClickBallText;
    [SerializeField] private TextMeshProUGUI incomeBallText;

    private Coroutine foreverBallsBoost;
    private Coroutine foreverBallsBoostCoolDown;
    [SerializeField] private bool foreverBallCoolDown;

    private Coroutine foreverAutoClickBoost;
    private Coroutine foreverAutoClickBoostCoolDown;
    [SerializeField] private bool foreverAutoClickCoolDown;

    private Coroutine foreverIncomeBoost;
    private Coroutine foreverIncomeBoostCoolDown;
    [SerializeField] private bool foreverIncomeCoolDown;


    [SerializeField] private GameObject foreverBallBoostObject;
    [SerializeField] private GameObject foreverIncomeBoostObject;
    [SerializeField] private GameObject foreverAutoClickObject;


    private Coroutine doubleBallBoost;
    private Coroutine incomeBoost;
    private Coroutine autoClickBoost;

    [SerializeField] private GameObject ballBoostAdsIcon, incomeBoostAdsIcon, autoClickBoostAdsIcon;

    [SerializeField] private TextMeshProUGUI foreverBallBoostObjectText, foreverIncomeBoostObjectText, foreverAutoClickObjectText;

    private void Start()
    {
        BoosterStart();
    }
    public void BoosterStart()
    {
        if (Geekplay.Instance.PlayerData.ForeverAutoClickBoost)
        {
            autoClickButton.interactable = false;
            ForeverAutoClickBoostBought();
            foreverAutoClickObject.GetComponent<Button>().interactable = false;
            //   foreverAutoClickObject.SetActive(false);
            foreverAutoClickObjectText.gameObject.SetActive(true);
            if (Geekplay.Instance.language == "en")
            {
                foreverAutoClickObjectText.text = "BOUGHT";
            }
            else if (Geekplay.Instance.language == "ru")
            {
                foreverAutoClickObjectText.text = "КУПЛЕНО";
            }
            else if (Geekplay.Instance.language == "tr")
            {
                foreverAutoClickObjectText.text = "SATIN AL";
            }
            else if (Geekplay.Instance.language == "es")
            {
                foreverAutoClickObjectText.text = "COMPRADO";
            }
            else if (Geekplay.Instance.language == "de")
            {
                foreverAutoClickObjectText.text = "GEKAUFT";
            }
            else if (Geekplay.Instance.language == "ar")
            {
                foreverAutoClickObjectText.text = "تم الشراء";
            }
        }
        if (Geekplay.Instance.PlayerData.ForeverBallsBoost)
        {
            doubleBallButton.interactable = false;
            ForeverBallsBoostBought();
            foreverBallBoostObject.GetComponent<Button>().interactable = false;
            // foreverBallBoostObject.SetActive(false);
            foreverBallBoostObjectText.gameObject.SetActive(true);
            if (Geekplay.Instance.language == "en")
            {
                foreverBallBoostObjectText.text = "BOUGHT";
            }
            else if (Geekplay.Instance.language == "ru")
            {
                foreverBallBoostObjectText.text = "КУПЛЕНО";
            }
            else if (Geekplay.Instance.language == "tr")
            {
                foreverBallBoostObjectText.text = "SATIN AL";
            }
            else if (Geekplay.Instance.language == "es")
            {
                foreverBallBoostObjectText.text = "COMPRADO";
            }
            else if (Geekplay.Instance.language == "de")
            {
                foreverBallBoostObjectText.text = "GEKAUFT";
            }
            else if (Geekplay.Instance.language == "ar")
            {
                foreverBallBoostObjectText.text = "تم الشراء";
            }
        }
        if (Geekplay.Instance.PlayerData.ForeverIncomeBoost)
        {
            incomeButton.interactable = false;
            ForeveerIncomeBoostBought();
            foreverIncomeBoostObject.GetComponent<Button>().interactable = false;
            // foreverIncomeBoostObject.SetActive(false);
            foreverIncomeBoostObjectText.gameObject.SetActive(true);
            if (Geekplay.Instance.language == "en")
            {
                foreverIncomeBoostObjectText.text = "BOUGHT";
            }
            else if (Geekplay.Instance.language == "ru")
            {
                foreverIncomeBoostObjectText.text = "КУПЛЕНО";
            }
            else if (Geekplay.Instance.language == "tr")
            {
                foreverIncomeBoostObjectText.text = "SATIN AL";
            }
            else if (Geekplay.Instance.language == "es")
            {
                foreverIncomeBoostObjectText.text = "COMPRADO";
            }
            else if (Geekplay.Instance.language == "de")
            {
                foreverIncomeBoostObjectText.text = "GEKAUFT";
            }
            else if (Geekplay.Instance.language == "ar")
            {
                foreverIncomeBoostObjectText.text = "تم الشراء";
            }
        }
    }
  
    public void ForeveerIncomeBoostBought()
    {
        StartForeverIncomeBoostCorutine();
    }
    public void StartForeverIncomeBoostCorutine()
    {
        if (!foreverIncomeCoolDown)
        {
            if (foreverIncomeBoost == null)
            {
                BallSpawner.Instance.IncomeBoost = 5;
                foreverIncomeBoost = StartCoroutine(ForeverIncomeBoostCorutine());
            }
        }
    }
    public void StopForeverIncomeBoostCorutine()
    {
        BallSpawner.Instance.IncomeBoost = 1;
        incomeImage.fillAmount = 0f;
        incomeBallText.text = "0";
        incomeBallText.gameObject.SetActive(false);
        if (foreverIncomeBoost != null)
        {
            StopCoroutine(foreverIncomeBoost);
            foreverIncomeBoost = null;
            foreverIncomeCoolDown = true;
            StartForeverIncomeBoostCoolDownCorutine();
        }
    }
    public void StartForeverIncomeBoostCoolDownCorutine()
    {
        if (foreverIncomeCoolDown)
        {
            if (foreverIncomeBoostCoolDown == null)
            {
                foreverIncomeBoostCoolDown = StartCoroutine(ForeverIncomeBoostCoolDownCorutine());
            }
        }
    }
    public void StopForeverStopBoostCoolDownCorutine()
    {     
        incomeImage.fillAmount = 0f;
        incomeBallText.text = "0";
        incomeBallText.gameObject.SetActive(false);
        if (foreverIncomeBoostCoolDown != null)
        {
            StopCoroutine(foreverIncomeBoostCoolDown);
            foreverIncomeBoostCoolDown = null;
            foreverIncomeCoolDown = false;
            StartForeverIncomeBoostCorutine();
        }
    }
    public IEnumerator ForeverIncomeBoostCorutine()
    {
        float duration = 120f;
        float elapsed = 0f;
        incomeBallText.gameObject.SetActive(true);
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            incomeImage.fillAmount = (elapsed / duration);
            incomeBallText.text = Mathf.CeilToInt(duration - elapsed).ToString();
            yield return null;
        }
       
        StopForeverIncomeBoostCorutine();
    }
    public IEnumerator ForeverIncomeBoostCoolDownCorutine()
    {
        float duration = 30f;
        float elapsed = 0f;
        incomeBallText.gameObject.SetActive(true);
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            incomeImage.fillAmount = (elapsed / duration);
            incomeBallText.text = Mathf.CeilToInt(duration - elapsed).ToString();
            yield return null;
        }
        StopForeverStopBoostCoolDownCorutine();
    }
    public void ForeverAutoClickBoostBought()
    {
        StartForeverAutoClickBoostCorutine();
    }
    public void StartForeverAutoClickBoostCorutine()
    {
        if (!foreverAutoClickCoolDown)
        {
            if (foreverAutoClickBoost == null)
            {
                foreverAutoClickBoost = StartCoroutine(ForeverAutoClickBoostCorutine());
            }
        }
    }
    public void StopForeverAutoClickBoostCorutine()
    {
        autoClickImage.fillAmount = 0f;
        autoClickBallText.text = "0";
        autoClickBallText.gameObject.SetActive(false);
        if (foreverAutoClickBoost != null)
        {
            StopCoroutine(foreverAutoClickBoost);
            foreverAutoClickBoost = null;
            foreverAutoClickCoolDown = true;
            StartForeverAutoClickBoostCoolDownCorutine();
        }
    }
    public void StartForeverAutoClickBoostCoolDownCorutine()
    {
        if (foreverAutoClickCoolDown)
        {
            if (foreverAutoClickBoostCoolDown == null)
            {
                foreverAutoClickBoostCoolDown = StartCoroutine(ForeverAutoClickBoostCoolDownCorutine());
            }
        }
    }
    public void StopForeverAutoClickBoostCoolDownCorutine()
    {
        autoClickImage.fillAmount = 0f;
        autoClickBallText.text = "0";
        autoClickBallText.gameObject.SetActive(false);
        if (foreverAutoClickBoostCoolDown != null)
        {
            StopCoroutine(foreverAutoClickBoostCoolDown);
            foreverAutoClickBoostCoolDown = null;
            foreverAutoClickCoolDown = false;
            StartForeverAutoClickBoostCorutine();
        }
    }
    public IEnumerator ForeverAutoClickBoostCorutine()
    {
        float duration = 60f;
        float elapsed = 0f;
        int spawnInterval = 4;
        int spawnCounter = 0;
        autoClickBallText.gameObject.SetActive(true);
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            autoClickImage.fillAmount = (elapsed / duration);
            autoClickBallText.text = Mathf.CeilToInt(duration - elapsed).ToString();

            spawnCounter++;
            if (spawnCounter >= spawnInterval)
            {
                BallSpawner.Instance.SpawnBall();
                spawnCounter = 0;
            }
            yield return null;
        }
      
        StopForeverAutoClickBoostCorutine();
    }
    public IEnumerator ForeverAutoClickBoostCoolDownCorutine()
    {
        float duration = 30f;
        float elapsed = 0f;
        autoClickBallText.gameObject.SetActive(true);
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            autoClickImage.fillAmount = (elapsed / duration);
            autoClickBallText.text = Mathf.CeilToInt(duration - elapsed).ToString();
            yield return null;
        }
       
        StopForeverAutoClickBoostCoolDownCorutine();
    }
    public void ForeverBallsBoostBought()
    {
        StartForeverBallsBoostCorutine();
    }
    public void StartForeverBallsBoostCorutine()
    {
        if (!foreverBallCoolDown)
        {
            if (foreverBallsBoost == null)
            {
                BallSpawner.Instance.BallMaxCountBooster = 2;
                BallSpawner.Instance.SpawnCount += BallSpawner.Instance.MaximumBallCount;
                BallSpawner.Instance.MaximumBallCount = Geekplay.Instance.PlayerData.MaxSpawnCount * BallSpawner.Instance.BallMaxCountBooster;
                foreverBallsBoost = StartCoroutine(ForeverBallsBoostCorutine());
            }
        }
    }
    public void StopForeverBallsBoostCorutine()
    {
        BallSpawner.Instance.MaximumBallCount = Geekplay.Instance.PlayerData.MaxSpawnCount;
        BallSpawner.Instance.BallMaxCountBooster = 1;
        doubleBallImage.fillAmount = 0f;
        doubleBallText.text = "0";
        doubleBallText.gameObject.SetActive(false);
        if (foreverBallsBoost != null)
        {
            StopCoroutine(foreverBallsBoost);
            foreverBallsBoost = null;
            foreverBallCoolDown = true;
            StartForeverBallsBoostCoolDownCorutine();
        }
    }
    public void StartForeverBallsBoostCoolDownCorutine()
    {
        if (foreverBallCoolDown)
        {
            if (foreverBallsBoostCoolDown == null)
            {
                foreverBallsBoostCoolDown = StartCoroutine(ForeverBallsBoostCoolDownCorutine());
            }
        }
    }
    public void StopForeverBallsBoostCoolDownCorutine()
    {
        doubleBallImage.fillAmount = 0f;
        doubleBallText.text = "0";
        doubleBallText.gameObject.SetActive(false);
        if (foreverBallsBoostCoolDown != null)
        {
            StopCoroutine(foreverBallsBoostCoolDown);
            foreverBallsBoostCoolDown = null;
            foreverBallCoolDown = false;
            StartForeverBallsBoostCorutine();
        }
    }
    public IEnumerator ForeverBallsBoostCorutine()
    {
        float duration = 60f;
        float elapsed = 0f;
        doubleBallText.gameObject.SetActive(true);
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            doubleBallImage.fillAmount = (elapsed / duration);
            doubleBallText.text = Mathf.CeilToInt(duration - elapsed).ToString();
            yield return null;
        }
       
        StopForeverBallsBoostCorutine();
    }
    public IEnumerator ForeverBallsBoostCoolDownCorutine()
    {
        float duration = 30f;
        float elapsed = 0f;
        doubleBallText.gameObject.SetActive(true);
        while (elapsed < duration)
        {

            elapsed += Time.deltaTime;
            doubleBallImage.fillAmount = (elapsed / duration);
            doubleBallText.text = Mathf.CeilToInt(duration - elapsed).ToString();
            yield return null;
        }
        StopForeverBallsBoostCoolDownCorutine();
    }



    public void Pressed2XBall()
    {
        Geekplay.Instance.ShowRewardedAd("Ballx2");       
    }
    public void BallBoostReward()
    {
        BallSpawner.Instance.BallMaxCountBooster = 2;
        BallSpawner.Instance.SpawnCount += BallSpawner.Instance.MaximumBallCount;
        BallSpawner.Instance.MaximumBallCount = Geekplay.Instance.PlayerData.MaxSpawnCount * BallSpawner.Instance.BallMaxCountBooster;
        doubleBallButton.interactable = false;
        StartDoubleBallBoost();
    }
    public void StartDoubleBallBoost()
    {
        if (doubleBallBoost == null)
        {
            doubleBallBoost = StartCoroutine(DoubleBall());
        }
    }
    public void StopDoubleBallBoost()
    {
        BallSpawner.Instance.MaximumBallCount = Geekplay.Instance.PlayerData.MaxSpawnCount;
        BallSpawner.Instance.BallMaxCountBooster = 1;
        doubleBallImage.fillAmount = 0f;
        doubleBallText.text = "0";
        doubleBallText.gameObject.SetActive(false);
        doubleBallButton.interactable = true;
        if (doubleBallBoost != null)
        {
            StopCoroutine(doubleBallBoost);
            doubleBallBoost = null;
        }
    }
    public void Pressed5XIncome()
    {
        Geekplay.Instance.ShowRewardedAd("Incomex5");       
    }
    public void IncomeBoostReward()
    {
        BallSpawner.Instance.IncomeBoost = 5;
        incomeButton.interactable = false;
        StartIncomeBoost();
    }
    public void StartIncomeBoost()
    {
        if(incomeBoost == null)
        {
            incomeBoost = StartCoroutine(IncomeTimer());
        }
    }
    public void StopIncomeBoost()
    {
        BallSpawner.Instance.IncomeBoost = 1;
        incomeImage.fillAmount = 0f;
        incomeBallText.text = "0";
        incomeBallText.gameObject.SetActive(false);
        incomeButton.interactable = true;
        if (incomeBoost != null)
        {
            StopCoroutine(incomeBoost);
            incomeBoost = null;
        }
    }
    public void PressedAutoClick()
    {
        Geekplay.Instance.ShowRewardedAd("AutoClick");
    }
    public void AutoClickBoostReward()
    {
        StartAutoClickBoost();
        autoClickButton.interactable = false;
    }
    public void StartAutoClickBoost()
    {
        if(autoClickBoost == null)
        {
            autoClickBoost = StartCoroutine(AutoClickTimer());
        }
    }
    public void StopAutoClickBoost()
    {
        autoClickImage.fillAmount = 0f;
        autoClickBallText.text = "0";
        autoClickBallText.gameObject.SetActive(false);
        autoClickButton.interactable = true;
        if ( autoClickBoost != null)
        {
            StopCoroutine (autoClickBoost);
            autoClickBoost = null;
        }
    }
    public IEnumerator DoubleBall()
    {
        float duration = 60f;
        float elapsed = 0f;
        doubleBallText.gameObject.SetActive(true);
        ballBoostAdsIcon.SetActive(false);
        while (elapsed < duration)
        {

            elapsed += Time.deltaTime;
            doubleBallImage.fillAmount = (elapsed / duration);
            doubleBallText.text = Mathf.CeilToInt(duration - elapsed).ToString();
            yield return null;
        }

        ballBoostAdsIcon.SetActive(true);
        StopDoubleBallBoost();
    }
    public IEnumerator AutoClickTimer()
    {
        float duration = 60f;
        float elapsed = 0f;
        int spawnInterval = 4;
        int spawnCounter = 0;

        autoClickBallText.gameObject.SetActive(true);
        autoClickBoostAdsIcon.SetActive(false);
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            autoClickImage.fillAmount = (elapsed / duration);
            autoClickBallText.text = Mathf.CeilToInt(duration - elapsed).ToString();

            spawnCounter++;
            if (spawnCounter >= spawnInterval)
            {
                BallSpawner.Instance.SpawnBall();
                spawnCounter = 0;
            }

            yield return null;
        }

        autoClickBoostAdsIcon.SetActive(true);

        StopAutoClickBoost();
    }
    public IEnumerator IncomeTimer()
    {
        float duration = 120f;
        float elapsed = 0f;
        incomeBallText.gameObject.SetActive(true);
        incomeBoostAdsIcon.SetActive(false);
        while (elapsed < duration)
        {

            elapsed += Time.deltaTime;
            incomeImage.fillAmount = (elapsed / duration);
            incomeBallText.text = Mathf.CeilToInt(duration - elapsed).ToString();
            yield return null;
        }
        incomeBoostAdsIcon.SetActive(true);

        StopIncomeBoost();
    }
}
