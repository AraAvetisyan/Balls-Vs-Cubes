using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using JetBrains.Annotations;
public class InterstitialAdLogic : MonoBehaviour
{
    [SerializeField] private BoosterUIScript _boosterUIScript;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject textBG;
    private Coroutine minuteTimer;
    private Coroutine secondTimer;
    [SerializeField] private Button[] allButtons;
    [SerializeField] private AudioSource music;

    [SerializeField] private Button foreverDoubleButton, foreverIncomeButton, foreveerAutoButton;
    [SerializeField] private Button doubleButton, incomeButton, autoButton;


    void Start()
    {
        StartMinutesCoroutine();
    }
    private void Update()
    {
      
    }
    public void StartMinutesCoroutine()
    {
        if(minuteTimer == null)
        {
            minuteTimer = StartCoroutine(MinutesCoroutine());
        }
    }
    public void StopMinutesCoroutine()
    {
        if(minuteTimer != null)
        {
            StopCoroutine(minuteTimer);
            minuteTimer = null;
        }
    }
    public IEnumerator MinutesCoroutine()
    {
        float duration = 65f;
        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            yield return null;
        }
        textBG.SetActive(true);
        StartSecondsCoroutine();
        StopMinutesCoroutine();
    }
    public void StartSecondsCoroutine()
    {
        if (secondTimer == null)
        {
            secondTimer = StartCoroutine(SecondsCoroutine());
        }

        for (int i = 0; i < allButtons.Length; i++)
        {
            allButtons[i].interactable = false;
        }
    }
    public void StopSecondsCoroutine()
    {
        if(secondTimer != null)
        {
            StopCoroutine(secondTimer);
            secondTimer = null;
        }
    }
    public IEnumerator SecondsCoroutine()
    {

        Geekplay.Instance.GameStoped = true;
        Time.timeScale = 0;
        music.volume = 0;
        music.Pause();

      
        if (Geekplay.Instance.language == "en")
            timerText.text = "AD AFTER: 2";
        if (Geekplay.Instance.language == "ru")
            timerText.text = "РЕКЛАМА ЧЕРЕЗ: 2";
        if (Geekplay.Instance.language == "de")
            timerText.text = "WERBUNG NACH: 2";
        if (Geekplay.Instance.language == "es")
            timerText.text = "ANUNCIO DESPUÉS: 2";
        if (Geekplay.Instance.language == "tr")
            timerText.text = "REKLAMDAN SONRA: 2";
        if (Geekplay.Instance.language == "ar")
            timerText.text = "الإعلان بعد: 2";
        yield return new WaitForSecondsRealtime(1);
        if (Geekplay.Instance.language == "en")
            timerText.text = "AD AFTER: 1";
        if (Geekplay.Instance.language == "ru")
            timerText.text = "РЕКЛАМА ЧЕРЕЗ: 1";
        if (Geekplay.Instance.language == "de")
            timerText.text = "WERBUNG NACH: 1";
        if (Geekplay.Instance.language == "es")
            timerText.text = "ANUNCIO DESPUÉS: 1";
        if (Geekplay.Instance.language == "tr")
            timerText.text = "REKLAMDAN SONRA: 1";
        if (Geekplay.Instance.language == "ar")
            timerText.text = "الإعلان بعد: 1";

        yield return new WaitForSecondsRealtime(1);

        ShowAd();
        StopSecondsCoroutine();
    }
    public void ShowAd()
    {
        Geekplay.Instance.ShowInterstitialAd();
        Geekplay.Instance.GameStoped = false;

        music.volume = 0.35f;
        music.Play();
        for (int i = 0; i < allButtons.Length; i++)
        {
            allButtons[i].interactable = true;
        }

        if (_boosterUIScript.ForeverDoubleBttonInteractible)
        {
            foreverDoubleButton.interactable = true;
        }
        else
        {
            foreverDoubleButton.interactable = false;
        }

        if (_boosterUIScript.ForeverIncomeButtonInteractible)
        {
            foreverIncomeButton.interactable = true;
        }
        else
        {
            foreverIncomeButton.interactable = false;
        }

        if (_boosterUIScript.ForeverAutoclickButtonInteractible)
        {
            foreveerAutoButton.interactable = true;
        }
        else
        {
            foreveerAutoButton.interactable = false;
        }

        if (_boosterUIScript.DoubleBttonInteractible)
        {
            doubleButton.interactable = true;
        }
        else
        {
            doubleButton.interactable = false;
        }

        if (_boosterUIScript.IncomeButtonInteractible)
        {
            incomeButton.interactable = true;
        }
        else
        {
            incomeButton.interactable = false;
        }

        if (_boosterUIScript.AutoclickButtonInteractible)
        {
            autoButton.interactable = true;
        }
        else
        {
            autoButton.interactable = false;
        }

        textBG.SetActive(false);
        StartMinutesCoroutine();
    }
}
