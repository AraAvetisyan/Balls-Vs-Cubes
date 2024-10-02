using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncomeTextScript : MonoBehaviour
{
    [SerializeField] private float speed;
    void Start()
    {
        Destroy(gameObject, 0.2f);
    }
    private void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
}
