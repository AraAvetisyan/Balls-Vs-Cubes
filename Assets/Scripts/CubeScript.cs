using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] LevelsUIController _levelUIController;
    public int Health;
    private void Start()
    {
        if(Geekplay.Instance.PlayerData.BallPower == 0)
        {
            Geekplay.Instance.PlayerData.BallPower = 1;
            Geekplay.Instance.Save();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Health = Health - Geekplay.Instance.PlayerData.BallPower;
            
            healthText.text=Health.ToString();
            for (int i = 0; i < Geekplay.Instance.PlayerData.BallPower; i++)
            {
                _levelUIController.ChangeValue();
            }
            if(Health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
