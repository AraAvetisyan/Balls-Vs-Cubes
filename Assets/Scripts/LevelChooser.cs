using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChooser : MonoBehaviour
{
    [SerializeField] private GameObject[] levels;
    void Start()
    {
        StartCoroutine(WaitAFrame());
    }
    public IEnumerator WaitAFrame()
    {
        yield return new WaitForEndOfFrame();
        for (int i = 0; i < levels.Length; i++)
        {
            levels[i].SetActive(false);
        }
        levels[Geekplay.Instance.PlayerData.Level].SetActive(true);
    }
}
