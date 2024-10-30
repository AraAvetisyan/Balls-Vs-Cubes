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
    [SerializeField] private TextMeshProUGUI levelText;
    private int progressValue;

    private Coroutine enumerator;

    public Transform SpawnPoint;
    public TextMeshProUGUI SpawnText;
    private void Awake()
    {

    }
    void Start()
    {
        if (Geekplay.Instance.language == "en")
            levelText.text = "LEVEL " + LevelChooser.Instance.CurrentLevelCount;
        else if (Geekplay.Instance.language == "ru")
            levelText.text = "УРОВЕНЬ " + LevelChooser.Instance.CurrentLevelCount;
        else if (Geekplay.Instance.language == "tr")
            levelText.text = "SEVİYE " + LevelChooser.Instance.CurrentLevelCount;
        else if (Geekplay.Instance.language == "es")
            levelText.text = "NIVEL " + LevelChooser.Instance.CurrentLevelCount;
        else if (Geekplay.Instance.language == "de")
            levelText.text = "NIVEAU " + LevelChooser.Instance.CurrentLevelCount;
        else if (Geekplay.Instance.language == "ar")
            levelText.text = LevelChooser.Instance.CurrentLevelCount + " المستوى ";
        StartCoroutine(WaitFrameBeforeStart());
        progress.interactable = false;

    }
    public IEnumerator WaitFrameBeforeStart()
    {
        yield return new WaitForEndOfFrame();
        for (int i = 0; i < cubes.Length; i++)
        {
            maxValue += cubes[i].Health;
        }
        progress.maxValue = maxValue;
    }
    public void ChangeValue(int value)
    {
        progressValue+= value;
        MoneyScript.Instance.AddMoney();
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
        progressValue = 0;
        yield return new WaitForSeconds(0.1f);
        for(int i = 0;i< BallSpawner.Instance.SpawnedObjects.Count; i++)
        {
            Destroy(BallSpawner.Instance.SpawnedObjects[i]);
        }
        BallSpawner.Instance.SpawnedObjects.Clear();
        BallSpawner.Instance.SpawnCount = BallSpawner.Instance.MaximumBallCount;            
        Geekplay.Instance.PlayerData.Level += 1;   
        LevelChooser.Instance.SpawnNewLevel();
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
