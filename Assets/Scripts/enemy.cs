using System;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
public class enemy : MonoBehaviour
{
    [SerializeField] private float movespeed = 3f;
    private Rigidbody2D rb;
    private Transform checkpoint;
    private int index = 0;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
       checkpoint = EnemyMenager.main.checkpoints[index];
    }
    void Update()
    {
        checkpoint = EnemyMenager.main.checkpoints[index];
       
        if (Vector2.Distance(checkpoint.position, transform.position) <= 0.1f)
        {
            Debug.Log("Checkpoint reached" + index);
            index++;
            if(index >= EnemyMenager.main.checkpoints.Length)
            {
                Destroy(gameObject);
            }
        }
    }
    void FixedUpdate()
    {
        Vector2 direction = (checkpoint.position - transform.position).normalized;
        transform.right = checkpoint.position - transform.position;
        rb.linearVelocity = direction * movespeed;
    }
}
