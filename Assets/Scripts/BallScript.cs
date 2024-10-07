using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] private Transform[] moveTransforms;

    private int health;
    Vector2 direction;
    [SerializeField] private TextMeshProUGUI incomeTextPrefab;
    [SerializeField] private Transform incomeSpawnPos;
    void Start()
    {
        int randDir = Random.Range(0, moveTransforms.Length);
        direction = (moveTransforms[randDir].position - transform.position).normalized;        
        health = Geekplay.Instance.PlayerData.BallHealth;
      
    }

    private void Update()
    {
        transform.Translate(direction * Geekplay.Instance.PlayerData.BallSpeed * Time.deltaTime * BallSpawner.Instance.SpeedBoost);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
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