using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    public GameObject _hungryCat;
    public GameObject _fullCat;

    public RectTransform _front;

    float _full = 5.0f;
    float _energy = 0.0f;

    bool _isFull = false;

    // Start is called before the first frame update
    void Start()
    {
        float x = Random.Range(-9.0f, 9.0f);
        float y = 30.0f;
        transform.position = new Vector2 (x, y);
    }

    // Update is called once per frame
    void Update()
    {
        if(_energy < _full)
        {
            transform.position += Vector3.down * 0.05f;

            if(transform.position.y < -16.0f)
            {
                GameManager._instance.GameOver();
            }
        }
        else
        {
            if(transform.position.x > 0)
            {
                transform.position += Vector3.right * 0.05f;
            }
            else
            {
                transform.position += Vector3.left * 0.05f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Food"))
        {
            if(_energy < _full)
            {
                _energy += 1.0f;
                _front.localScale = new Vector3(_energy / _full, 1.0f, 1.0f);
                Destroy(collision.gameObject);

                if(_energy >= _full)
                {
                    if(!_isFull)
                    {
                        _hungryCat.SetActive(false);
                        _fullCat.SetActive(true);
                        Destroy(gameObject, 3.0f);
                        GameManager._instance.AddScore();

                        _isFull = true;
                    }
                }
            }
        }
    }
}
