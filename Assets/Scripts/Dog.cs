using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    public GameObject _food;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MakeFood", 0f, 0.5f);
    }

    private void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float x = mousePos.x;

        if (x > 8.5f)
        {
            x = 8.5f;
        }
        else if(x < -8.5f)
        {
            x = -8.5f;
        }

        transform.position = new Vector2(x, transform.position.y);
    }

    void MakeFood()
    {
        float x = transform.position.x;
        float y = transform.position.y + 2.0f;
        Instantiate(_food, new Vector2(x, y), Quaternion.identity);
    }
}
