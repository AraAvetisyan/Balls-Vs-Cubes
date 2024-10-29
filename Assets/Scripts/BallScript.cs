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

    [SerializeField] private GameObject fireballTrail;

    [SerializeField] private Image ballLight;
    [SerializeField] private int wallCounter;

    int startColorIndex;
    void Start()
    {
        startColorIndex = BallSpawner.Instance.ColorIndex;
        int randDir = Random.Range(0, moveTransforms.Length);

        if (HeaderButtonsScript.Instance.ChangeMat)
        {
            fireballTrail.SetActive(true);
            ballImage.color = BallSpawner.Instance.FireBallColor;
            trail.SetActive(false);
        }
        else
        {
            ballImage.color = BallSpawner.Instance.BallColors[BallSpawner.Instance.ColorIndex];
        }
        fireballTrail.GetComponent<TrailRenderer>().startColor = BallSpawner.Instance.FireBallColor;
        fireballTrail.GetComponent<TrailRenderer>().endColor = BallSpawner.Instance.FireBallColor;

        direction = (moveTransforms[randDir].position - transform.position).normalized;
        health = Geekplay.Instance.PlayerData.BallHealth;
       
        ballLight.color = BallSpawner.Instance.LightColors[BallSpawner.Instance.ColorIndex];
        trailRenderer.startColor = BallSpawner.Instance.TrailColors[BallSpawner.Instance.ColorIndex];
        trailRenderer.endColor = BallSpawner.Instance.TrailColors[BallSpawner.Instance.ColorIndex]; 

    }

    private void Update()
    {
        transform.Translate(direction * Geekplay.Instance.PlayerData.BallSpeed * Time.deltaTime * BallSpawner.Instance.SpeedBoost * BallSpawner.Instance.FireSpeedBoost);
        if (BallSpawner.Instance.PanelIsActive)
        {
            trail.SetActive(false);
            fireballTrail.SetActive(false);
        }
        else
        {
            trail.SetActive(true);
            fireballTrail.SetActive(true);
        }
        if (HeaderButtonsScript.Instance.ChangeMat)
        {
            fireballTrail.SetActive(true);
           
            ballImage.color = BallSpawner.Instance.FireBallColor;
            trail.SetActive(false);

        }
        else
        {
            ballImage.color = BallSpawner.Instance.BallColors[startColorIndex];
            fireballTrail.SetActive(false);
            trail.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(Geekplay.Instance.PlayerData.BallSpeed * BallSpawner.Instance.SpeedBoost * BallSpawner.Instance.FireSpeedBoost);
        if (collision.gameObject.CompareTag("Cube"))
        {
            wallCounter = 0;
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
          //  if (wallCounter < 5)
          //  {
                Vector2 normal = collision.contacts[0].normal;
                direction = Vector2.Reflect(direction, normal);
                wallCounter++;
           // }
            //else if (wallCounter >= 5)
            //{
            //    wallCounter = 0; 
            //    Vector2 normal = collision.contacts[0].normal;
            //    int randDir = Random.Range(0, moveTransforms.Length);
            //    direction = (moveTransforms[randDir].position - transform.position).normalized;                
            //    direction = Vector2.Reflect(direction, normal);
            //}
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Killer"))
        {
            BallSpawner.Instance.SpawnedObjects.Remove(gameObject);
            BallSpawner.Instance.SpawnCount++;
            Destroy(this.gameObject);
        }
    }



}