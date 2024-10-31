using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FireBallScript : MonoBehaviour
{
    private Coroutine boosterCorutine;
    [SerializeField] private HeaderButtonsScript _headerButtonsScript;
    [SerializeField] private Image fillImage;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float corutineDuration;
    [SerializeField] private GameObject fireballAdsImage;
    public void StartFireCorutine()
    {
        Geekplay.Instance.ShowRewardedAd("FireBall");       
    }
    public void FireBallReward()
    {
        boosterCorutine = StartCoroutine(StartFireBallTimer());
        _headerButtonsScript.Pressed = true;
    }
    public void StopFireCorutine()
    {
        HeaderButtonsScript.Instance.ChangeMat = false;
        if(boosterCorutine != null)
        {
            StopCoroutine(boosterCorutine);
            boosterCorutine = null;
        }
        fireballAdsImage.SetActive(true);
    }
    public IEnumerator StartFireBallTimer()
    {
        float duration = corutineDuration;
        float elapsed = 0f;
        timerText.gameObject.SetActive(true);
        fireballAdsImage.SetActive(false);
        while (elapsed < duration)
        {
            HeaderButtonsScript.Instance.ChangeMat = true;
            elapsed += Time.deltaTime;
            BallSpawner.Instance.PowerBoostTenTimes = 10;
            BallSpawner.Instance.FireSpeedBoost = 1.5f;
            fillImage.fillAmount = (elapsed / duration);
            timerText.text = Mathf.CeilToInt(duration - elapsed).ToString();
            yield return null;
        }
        BallSpawner.Instance.PowerBoostTenTimes = 1;
        BallSpawner.Instance.FireSpeedBoost = 1;
        fillImage.fillAmount = 0f;
        timerText.text = "0";
        timerText.gameObject.SetActive(false);
        _headerButtonsScript.Pressed = false;

        StopFireCorutine();

    }
}
