using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector2 movement;
    private Transform Apple;
    public Rigidbody2D rb;
    FruitSpawnerScript apple_spawner;
    public Vector2 out_vector2;

    void Awake()
    {
        apple_spawner = GameObject.Find("Apple spawner").GetComponent<FruitSpawnerScript>();
        rb = this.GetComponent<Rigidbody2D>();
        Find_Apple();
    }
    public void Find_Apple()
    {

        if (apple_spawner.apple_list.Count > 0)
        {
            Apple = apple_spawner.apple_list[0].transform;
        }

    }
    void Update()
    {
        if (Apple == null)
        {
            Find_Apple();
        }
        else
        {
            if (out_vector2 == new Vector2(0, 0))
            {
                transform.position = Vector2.MoveTowards(transform.position, Apple.position, moveSpeed * Time.deltaTime);
                Vector3 direction = Apple.position - transform.position;
            }
            else
            {

            }
        }

    }
    private void FixedUpdate()
    {
        moveCharacter(movement);
    }
    void moveCharacter(Vector2 direction)
    {
        float down = (direction.x * direction.x + direction.y * direction.y);
        if (down != 0)
        {
            rb.MovePosition((Vector2)transform.position + (direction/ down * moveSpeed * Time.deltaTime) + out_vector2);
        }
        else
        {
            rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime) + out_vector2);
        }
        if (out_vector2 != new Vector2(0, 0))
        {
            out_vector2 = new Vector2(0, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Apple"))
        {
            Destroy(other.gameObject);
            apple_spawner.apple_list.Remove(other.gameObject);
            GameObject.Find("Center_Manager").GetComponent<Center_Manager>().enemy_point += 1;
        }
    }
    
}
