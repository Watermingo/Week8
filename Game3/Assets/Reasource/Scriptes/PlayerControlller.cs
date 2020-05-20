using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControlller : MonoBehaviour
{
    
    public Animator animator;
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    Vector2 movement;

    public KeyCode left;
    public KeyCode right;
    public KeyCode up;
    public KeyCode down;
    FruitSpawnerScript apple_spawner;

    

    // Start is called before the first frame update
    public float out_velocity = 20;
    public Vector2 out_vector2;
    void Start()
    {
        apple_spawner = GameObject.Find("Apple spawner").GetComponent<FruitSpawnerScript>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        
            movement.x = Input.GetAxisRaw("Horizontal");
        
        movement.y = Input.GetAxisRaw("Vertical");
      
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Apple"))
        {
            Destroy(other.gameObject);
            apple_spawner.apple_list.Remove(other.gameObject);
            GameObject.Find("Center_Manager").GetComponent<Center_Manager>().my_point += 1;
        }
       
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        print("111");
        if (other.gameObject.CompareTag("Enemy"))
        {
            print("222");

            out_vector2.x = -(other.transform.position - transform.position).normalized.x * out_velocity * Time.deltaTime;
            out_vector2.y = -(other.transform.position - transform.position).normalized.y * out_velocity * Time.deltaTime;



            
            other.gameObject.GetComponent<Enemy>().out_vector2.x= (other.transform.position - transform.position).normalized.x * out_velocity * Time.deltaTime;
            other.gameObject.GetComponent<Enemy>().out_vector2.y = (other.transform.position - transform.position).normalized.y * out_velocity * Time.deltaTime;
        }
    }
    private void FixedUpdate() 
    {
        float down = (movement.x * movement.x + movement.y * movement.y);
        if (down != 0)
        {
            rb.MovePosition(rb.position + movement/ down * moveSpeed * Time.fixedDeltaTime + out_vector2);
        }
        else
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime + out_vector2);
        }

        if (out_vector2 != new Vector2(0, 0))
        {
            out_vector2 = new Vector2(0, 0);
        }
        
    }
}
