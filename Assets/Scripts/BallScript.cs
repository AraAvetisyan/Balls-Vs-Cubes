using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BallScript : MonoBehaviour
{
    [SerializeField] private Transform[] moveTransforms;

    private int health;
    Vector2 direction;
    [SerializeField] private TextMeshProUGUI incomeTextPrefab;
    [SerializeField] private Transform incomeSpawnPos;
    [SerializeField] private GameObject trail;
    [SerializeField] private Image ballImage;
    [SerializeField] private TrailRenderer trailRenderer;
    void Start()
    {
        int randDir = Random.Range(0, moveTransforms.Length);
        direction = (moveTransforms[randDir].position - transform.position).normalized;        
        health = Geekplay.Instance.PlayerData.BallHealth;
        ballImage.color = BallSpawner.Instance.BallColors[BallSpawner.Instance.ColorIndex];
        trailRenderer.startColor = BallSpawner.Instance.TrailColors[BallSpawner.Instance.ColorIndex];
        trailRenderer.endColor = BallSpawner.Instance.TrailColors[BallSpawner.Instance.ColorIndex];
    }

    private void Update()
    {
        transform.Translate(direction * Geekplay.Instance.PlayerData.BallSpeed * Time.deltaTime * BallSpawner.Instance.SpeedBoost * BallSpawner.Instance.FireSpeedBoost);
        if (BallSpawner.Instance.PanelIsActive)
        {
            trail.SetActive(false);
        }
        else
        {
            trail.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(Geekplay.Instance.PlayerData.BallSpeed * BallSpawner.Instance.SpeedBoost * BallSpawner.Instance.FireSpeedBoost);
        if (collision.gameObject.CompareTag("Cube"))
        {
            health--;
            if (health == 0)
            {
                BallSpawner.Instance.SpawnedObjects.Remove(gameObject);
                BallSpawner.Instance.SpawnCount++;
                Destroy(gameObject);
            }
            else
            {
                Vector2 normal = collision.contacts[0].normal;

                direction = Vector2.Reflect(direction, normal);
            }
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            Vector2 normal = collision.contacts[0].normal;

            direction = Vector2.Reflect(direction, normal);
        }
    }
   
  
   
}