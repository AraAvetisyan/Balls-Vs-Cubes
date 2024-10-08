using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeaderButtonsScript : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject rebornPanel;
    [SerializeField] private GameObject passiveIncomePanel;
    [SerializeField] private TextMeshProUGUI permenantIncome, reachingLevel;



    [SerializeField] private GameObject powererButton;
    [SerializeField] private int randMax, randMin;
    private float randStart;
    private int randButton;

    private Coroutine buttonShowCorutine;
    private Coroutine buttonUnshowCorutine;
    private Coroutine pressedUnshowCorutine;
    public bool Pressed;
    void Start()
    {
        StartShowCorutine();
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
        powererButton.SetActive(true);
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
            powererButton.SetActive(false);
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
        powererButton.SetActive(false);
        StopPressedCorutine();
    }



    public void PressedClose()
    {
        settingsPanel.SetActive(false);
        rebornPanel.SetActive(false);
        passiveIncomePanel.SetActive(false);
    }
    public void PressedSettingsButton()
    {
        settingsPanel.SetActive(true);
    }

    public void PressedRebornButton()
    {
        permenantIncome.text = "CURRENT PERMENANT INCOME: " + "<color=green>" + (Geekplay.Instance.PlayerData.RebornCount + 1) + "</color>";

        reachingLevel.text = "YOU HAVE TO REACH <color=green>LEVEL" + " " + ((Geekplay.Instance.PlayerData.RebornCount + 1) * 10) + " </color>FOR REBIRTH";

        rebornPanel.SetActive(true);
    }

    public void PressedReborn()
    {
        if (Geekplay.Instance.PlayerData.Level >= ((Geekplay.Instance.PlayerData.RebornCount + 1) * 10))
        {
            Reset();
        }
        else if (Geekplay.Instance.PlayerData.Level < (Geekplay.Instance.PlayerData.RebornCount + 1) * 10)
        {
            rebornPanel.SetActive(false);
        }

    }
    public void Reset()
    {
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
        Geekplay.Instance.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ResetSettings()
    {
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
        Geekplay.Instance.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
