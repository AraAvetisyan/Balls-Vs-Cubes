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

    private void Start()
    {
       StartCoroutine(WaitNextFrameForBoosters());
    }
    public IEnumerator WaitNextFrameForBoosters()
    {
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        if (Geekplay.Instance.PlayerData.ForeverAutoClickBoost)
        {
            autoClickButton.interactable = false;
            ForeverAutoClickBoostBought();
            foreverAutoClickObject.SetActive(false);
        }
        if (Geekplay.Instance.PlayerData.ForeverBallsBoost)
        {
            doubleBallButton.interactable = false;
            ForeverBallsBoostBought();
            foreverBallBoostObject.SetActive(false);
        }
        if (Geekplay.Instance.PlayerData.ForeverIncomeBoost)
        {
            incomeButton.interactable = false;
            ForeveerIncomeBoostBought();
            foreverIncomeBoostObject.SetActive(false);
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
            BallSpawner.Instance.IncomeBoost = 5;
            foreverIncomeBoost = StartCoroutine(ForeverIncomeBoostCorutine());
        }
    }
    public void StopForeverIncomeBoostCorutine()
    {
        if(foreverIncomeBoost != null)
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
            foreverIncomeBoostCoolDown = StartCoroutine(ForeverIncomeBoostCoolDownCorutine());
        }
    }
    public void StopForeverStopBoostCoolDownCorutine()
    {
        if(foreverIncomeBoostCoolDown != null)
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
        BallSpawner.Instance.IncomeBoost = 1;
        incomeImage.fillAmount = 0f;
        incomeBallText.text = "0";
        incomeBallText.gameObject.SetActive(false);
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
        incomeImage.fillAmount = 0f;
        incomeBallText.text = "0";
        incomeBallText.gameObject.SetActive(false);
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
            foreverAutoClickBoost = StartCoroutine(ForeverAutoClickBoostCorutine());
        }
    }
    public void StopForeverAutoClickBoostCorutine()
    {
        if(foreverAutoClickBoost != null)
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
            foreverAutoClickBoostCoolDown = StartCoroutine(ForeverAutoClickBoostCoolDownCorutine());
        }
    }
    public void StopForeverAutoClickBoostCoolDownCorutine()
    {
        if(foreverAutoClickBoostCoolDown != null)
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
        autoClickBallText.gameObject.SetActive(true);
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            autoClickImage.fillAmount = (elapsed / duration);
            autoClickBallText.text = Mathf.CeilToInt(duration - elapsed).ToString();
            BallSpawner.Instance.SpawnBall();
            yield return null;
        }
        autoClickImage.fillAmount = 0f;
        autoClickBallText.text = "0";
        autoClickBallText.gameObject.SetActive(false);
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
        autoClickImage.fillAmount = 0f;
        autoClickBallText.text = "0";
        autoClickBallText.gameObject.SetActive(false);
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
            BallSpawner.Instance.BallMaxCountBooster = 2;
            BallSpawner.Instance.SpawnCount += BallSpawner.Instance.MaximumBallCount;
            BallSpawner.Instance.MaximumBallCount = Geekplay.Instance.PlayerData.MaxSpawnCount * BallSpawner.Instance.BallMaxCountBooster;
            foreverBallsBoost = StartCoroutine(ForeverBallsBoostCorutine());
        }
    }
    public void StopForeverBallsBoostCorutine()
    {
        if(foreverBallsBoost != null)
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
            foreverBallsBoostCoolDown = StartCoroutine(ForeverBallsBoostCoolDownCorutine());
        }
    }
    public void StopForeverBallsBoostCoolDownCorutine()
    {
        if(foreverBallsBoostCoolDown != null)
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
        BallSpawner.Instance.MaximumBallCount = Geekplay.Instance.PlayerData.MaxSpawnCount;
        BallSpawner.Instance.BallMaxCountBooster = 1;
        doubleBallImage.fillAmount = 0f;
        doubleBallText.text = "0";
        doubleBallText.gameObject.SetActive(false);
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
        doubleBallImage.fillAmount = 0f;
        doubleBallText.text = "0";
        doubleBallText.gameObject.SetActive(false);
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
        StartCoroutine(DoubleBall());
    }
    public void Pressed5XIncome()
    {
        Geekplay.Instance.ShowRewardedAd("Incomex5");       
    }
    public void IncomeBoostReward()
    {
        BallSpawner.Instance.IncomeBoost = 5;
        incomeButton.interactable = false;
        StartCoroutine(IncomeTimer());
    }
    public void PressedAutoClick()
    {
        Geekplay.Instance.ShowRewardedAd("AutoClick");
    }
    public void AutoClickBoostReward()
    {
        StartCoroutine(AutoClickTimer());
        autoClickButton.interactable = false;
    }

    public IEnumerator DoubleBall()
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
        BallSpawner.Instance.MaximumBallCount = Geekplay.Instance.PlayerData.MaxSpawnCount;
        BallSpawner.Instance.BallMaxCountBooster = 1;
        doubleBallImage.fillAmount = 0f;
        doubleBallText.text = "0";
        doubleBallText.gameObject.SetActive(false);
        doubleBallButton.interactable = true;
    }
    public IEnumerator AutoClickTimer()
    {
        float duration = 60f;
        float elapsed = 0f;
        autoClickBallText.gameObject.SetActive(true);
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            autoClickImage.fillAmount = (elapsed / duration);
            autoClickBallText.text = Mathf.CeilToInt(duration - elapsed).ToString();
            BallSpawner.Instance.SpawnBall();
            yield return null;
        }
        autoClickImage.fillAmount = 0f;
        autoClickBallText.text = "0";
        autoClickBallText.gameObject.SetActive(false);
        autoClickButton.interactable = true;
    }
    public IEnumerator IncomeTimer()
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
        BallSpawner.Instance.IncomeBoost = 1;
        incomeImage.fillAmount = 0f;
        incomeBallText.text = "0";
        incomeBallText.gameObject.SetActive(false);
        incomeButton.interactable = true;
    }
}
