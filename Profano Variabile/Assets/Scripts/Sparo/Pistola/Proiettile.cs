using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proiettile : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    float damage;

    private void Update()
    {
        transform.Translate((Vector2.right * speed) * Time.deltaTime);
    }
}
