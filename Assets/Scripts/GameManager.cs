using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;

    public GameObject _normalCat;
    public GameObject _retryBtn;

    private void Awake()
    {
        if(_instance == null)
            _instance = this;

        Application.targetFrameRate = 60;
        Time.timeScale = 1.0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MakeCat", 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MakeCat()
    {
        Instantiate(_normalCat);
    }

    public void GameOver()
    {
        _retryBtn.SetActive(true);
        Time.timeScale = 0f;
    }
}
