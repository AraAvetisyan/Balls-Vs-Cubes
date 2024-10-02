using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelsUIController : MonoBehaviour
{
    [SerializeField] CubeScript[] cubes;
    [SerializeField] private Slider progress;
    [SerializeField] private int maxValue;
    private int progressValue;
    [SerializeField] private MoneyScript _moneyScript;
    [SerializeField] private GameObject nextLevel; 
    [SerializeField] private GameObject thisLevel;

    private Coroutine enumerator;
    void Start()
    {
        for(int i = 0; i < cubes.Length; i++)
        {
            maxValue += cubes[i].Health;
        }
        progress.maxValue = maxValue;
    }
    public void ChangeValue()
    {
        progressValue++;
        _moneyScript.AddMoney();
        progress.value = progressValue;
        if(progressValue >= maxValue) 
        {
            StartCorutine();
        }
    }
    public void StartCorutine()
    {
        enumerator = StartCoroutine(LevelPass());
    }
    public IEnumerator LevelPass()
    {
        
        yield return new WaitForSeconds(0.1f);
        nextLevel.SetActive(true);
        thisLevel.SetActive(false);
        for(int i = 0;i< BallSpawner.Instance.SpawnedObjects.Count; i++)
        {
            Destroy(BallSpawner.Instance.SpawnedObjects[i]);
        }
        BallSpawner.Instance.SpawnedObjects.Clear();
        BallSpawner.Instance.SpawnCount = Geekplay.Instance.PlayerData.MaxSpawnCount;
        StopCorutine();
    }
    public void StopCorutine()
    {
        if (enumerator != null)
        {
            StopCoroutine(enumerator);
            enumerator = null;
        }
    }
}
