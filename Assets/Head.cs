using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    public GameObject node;
    Vector2 direction = Vector2.down; 
    bool ateFood = false;
    public LinkedList<GameObject> body;
    FoodCreator foodCreator;
    bool dead = false;

    GameManager gameManager;

    private void Awake()
    {
        body = new LinkedList<GameObject>();
        foodCreator = FindObjectOfType<FoodCreator>();

        gameManager = FindObjectOfType<GameManager>();
    }


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Move", 0f, 0.2f);
               
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(direction != Vector2.right)
            {
                direction = Vector2.left;
            }           
        }else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(direction != Vector2.left)
            {
                direction = Vector2.right;
            }    
        }
        else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(direction != Vector2.down)
            {
                direction = Vector2.up;
            }
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(direction != Vector2.up)
            {
                direction = Vector2.down;
            }           
        }
    }
    void Move()
    {
        if (dead) return;

        var curHeadPosition = transform.position;
        transform.Translate(direction);
        if ((ateFood)) {
            var newNode = Instantiate(node, curHeadPosition, Quaternion.identity);
            body.AddFirst(newNode);
            ateFood = false;
            foodCreator.createFood = true;
        }
        else
        {
            if (body.Count <= 2)
            {
                var newNode = Instantiate(node, curHeadPosition, Quaternion.identity);
                body.AddFirst(newNode);                
            }
            var tail = body.Last.Value;
            tail.transform.position = curHeadPosition;
            body.RemoveLast();
            body.AddFirst(tail);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Food")
        {
            ateFood = true;
            Destroy(collision.gameObject);
        }
        else
        {
            dead = true;
            //ËÀÍöºóµ¯³öUI°´Å¥
            gameManager.button_restart.gameObject.SetActive(true);
            gameManager.button_backmenu.gameObject.SetActive(true);
            gameManager.txt_gameover.gameObject.SetActive(true);
        }
    }
}
