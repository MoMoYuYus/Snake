using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCreator : MonoBehaviour
{
    [SerializeField]
    private GameObject food;
    public bool createFood = true;
    Head head;
    LinkedList<GameObject> body2;

    private void Awake()
    {
        head = FindObjectOfType<Head>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (createFood)
        {
            bool notOk;
            body2 = head.body;
            int x, y;
            do
            {
                notOk = false;
                x = (int)Random.Range(-14, 14);
                y = (int)Random.Range(-6, 6);
                foreach (GameObject gameObject in body2)
                {
                    if (y == (int)gameObject.transform.position.y && x == (int)gameObject.transform.position.x)
                    {
                        notOk = true;
                        break;
                    }
                }
            } while (notOk);
            Instantiate(food, new Vector2(x, y), Quaternion.identity);
            createFood = false;
        }
    }
}
