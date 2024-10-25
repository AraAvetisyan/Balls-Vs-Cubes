using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class CubeScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] LevelsUIController _levelUIController;
    public int Health;
    public int HealthRandOne, HealthRandTwo;

    [SerializeField] private TextMeshProUGUI incomeTextPrefab;
    [SerializeField] private Transform incomeSpawnPos;
    private Coroutine enumerator;
    [SerializeField] private int damage;


    private Vector2 smollScale;
    private Vector2 originalScale;
    public bool StartScaling = false;
    public bool GetSmoller = false;


    [SerializeField] private Ease easeToBig;
    [SerializeField] private Ease easeToSmoll;

    [SerializeField] private GameObject hitBlockAudioPrefab;
    private void Start()
    {
        smollScale = new Vector2(0.9f, 0.9f);
        originalScale = transform.localScale;
        if (Geekplay.Instance.PlayerData.BallPower == 0)
        {
            Geekplay.Instance.PlayerData.BallPower = 1;
            Geekplay.Instance.Save();
        }
        Health = Random.Range(HealthRandOne, HealthRandTwo);
        healthText.text = FormatPrice(Health);
    }

    private void Update()
    {
       

        if (GetSmoller)
        {
            GetSmoller = false;
            transform.DOScale(smollScale, 0.2f).SetEase(easeToSmoll);
            StartCoroutine(FromeSmallToBig());
        }
        if (StartScaling)
        {
            StartScaling = false;
            transform.DOScale(originalScale, 0.2f).SetEase(easeToBig);
        }
    }
    public IEnumerator FromeSmallToBig()
    {
        yield return new WaitForSeconds(0.2f);
        StartScaling = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        damage = Geekplay.Instance.PlayerData.BallPower * BallSpawner.Instance.PowerBoostTenTimes * BallSpawner.Instance.ShopBallPower;
        if (collision.gameObject.CompareTag("Ball"))
        {
            AudioSource hitBlockAudio = Instantiate(hitBlockAudioPrefab.GetComponent<AudioSource>());
            hitBlockAudio.volume = Geekplay.Instance.PlayerData.SoundEffectsVolume;
            hitBlockAudio.Play();
            Destroy(hitBlockAudio.gameObject, 1f);
            GetSmoller = true;
            if (Health >= damage)
            {
                for (int i = 0; i < damage; i++)
                {
                    _levelUIController.ChangeValue(1);
                }
                Health = Health - damage;
                //_levelUIController.ChangeValue(damage);
            }
            else
            {
                for (int i = 0; i < Health; i++)
                {
                    _levelUIController.ChangeValue(1);
                }
                //_levelUIController.ChangeValue(Health);
                Health = 0;
            }

            StartShowCorutine();

            healthText.text = FormatPrice(Health);

            if (Health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    public void StartShowCorutine()
    {
        enumerator = StartCoroutine(ShowCorutine());
    }
    public void StopShowCorutine()
    {
        if (enumerator != null)
        {
            StopCoroutine(enumerator);
            enumerator = null;
        }
    }
    public IEnumerator ShowCorutine()
    {
        TextMeshProUGUI incomeText = Instantiate(incomeTextPrefab, incomeSpawnPos.transform);
        //incomeText.transform.SetParent(incomeSpawnPos.parent);
        incomeText.text = "$" + FormatPrice(((Geekplay.Instance.PlayerData.Income + Geekplay.Instance.PlayerData.RebornCount) * BallSpawner.Instance.IncomeBoost) * Geekplay.Instance.PlayerData.BallPower * BallSpawner.Instance.ShopBallPower * BallSpawner.Instance.PowerBoostTenTimes);
        yield return new WaitForSeconds(.1f);
        StopShowCorutine();
    }
    string FormatPrice(double value)
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

        return $"{value:0.##}{suffixes[suffixIndex]}";
    }
}
