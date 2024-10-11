using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LocalisationScript : MonoBehaviour
{
    [Header("Upgrades")]
    [SerializeField] private TextMeshProUGUI upgradesTitleText;

    [SerializeField] private TextMeshProUGUI upgradesHealthText;
    [SerializeField] private TextMeshProUGUI upgradesHealthLevelText;

    [SerializeField] private TextMeshProUGUI upgradesPowerText;
    [SerializeField] private TextMeshProUGUI uphradesPowerLevelText;

    [SerializeField] private TextMeshProUGUI upgradesIncomeText;
    [SerializeField] private TextMeshProUGUI upgradesIncomeLevelText;

    [SerializeField] private TextMeshProUGUI upgradesBallsText;
    [SerializeField] private TextMeshProUGUI upgradesBallsLevelText;

    [Header("Boosts")]
    [SerializeField] private TextMeshProUGUI boostsTitleText;

    [SerializeField] private TextMeshProUGUI ballsBoostText;
    [SerializeField] private TextMeshProUGUI incomeBoostText;
    [SerializeField] private TextMeshProUGUI autoBoostText;
    [SerializeField] private TextMeshProUGUI clickBoostText;

    [Header("InAppBoosts")]
    [SerializeField] private TextMeshProUGUI ballForeverText;
    [SerializeField] private TextMeshProUGUI incomeForeverText;
    [SerializeField] private TextMeshProUGUI autoClickForeverText;

    [Header("Header")]
    [SerializeField] private TextMeshProUGUI settingsHeaderText;
    [SerializeField] private TextMeshProUGUI marketHeaderText;
    [SerializeField] private TextMeshProUGUI rebornHeaderText;

    [Header("Settings")]
    [SerializeField] private TextMeshProUGUI settingsTitleText;
    [SerializeField] private TextMeshProUGUI soundEffectsVolumeText;
    [SerializeField] private TextMeshProUGUI musicVolumeText;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
