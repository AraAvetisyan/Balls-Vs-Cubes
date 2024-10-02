using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoosterUIScript : MonoBehaviour
{
    [SerializeField] private Button incomeButton;
    [SerializeField] private Button autoClickButton;
    [SerializeField] private Button doubleBallButton;
    public void Pressed2XBall()
    {
        BallSpawner.Instance.BallMaxCountBooster = 2;
        BallSpawner.Instance.SpawnCount += Geekplay.Instance.PlayerData.MaxSpawnCount;
        Geekplay.Instance.PlayerData.MaxSpawnCount = Geekplay.Instance.PlayerData.MaxSpawnCount * BallSpawner.Instance.BallMaxCountBooster;
        doubleBallButton.interactable = false;
        StartCoroutine(DoubleBall());
    }

    public void Pressed5XIncome()
    {
        Geekplay.Instance.PlayerData.Income = 5;
        incomeButton.interactable = false;
        StartCoroutine(IncomeTimer());
    }

    public void PressedAutoClick()
    {
        StartCoroutine(AutoClickTimer());
        autoClickButton.interactable = false;
    }

    public IEnumerator DoubleBall()
    {
        yield return new WaitForSecondsRealtime(60);
        Geekplay.Instance.PlayerData.MaxSpawnCount = Geekplay.Instance.PlayerData.MaxSpawnCount / BallSpawner.Instance.BallMaxCountBooster;
        BallSpawner.Instance.SpawnCount = Geekplay.Instance.PlayerData.MaxSpawnCount;
        BallSpawner.Instance.BallMaxCountBooster = 1;
        doubleBallButton.interactable = true;
    }
    public IEnumerator AutoClickTimer()
    {
        float elapsedTime = 0f;

        while (elapsedTime < 60f)
        {
            BallSpawner.Instance.SpawnBall();
            elapsedTime += 0.1f;
            yield return new WaitForSecondsRealtime(0.1f);
        }
        if (elapsedTime >= 60)
        {
            autoClickButton.interactable = true;
        }
    }

    public IEnumerator IncomeTimer()
    {
        yield return new WaitForSecondsRealtime(120);
        Geekplay.Instance.PlayerData.Income = 1;
        incomeButton.interactable = true;
    }
}
