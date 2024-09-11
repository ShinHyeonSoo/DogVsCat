using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;

    public GameObject _normalCat;
    public GameObject _fatCat;
    public GameObject _pirateCat;
    public GameObject _retryBtn;

    public RectTransform _levelFront;
    public Text _levelText;

    int _level = 0;
    int _score = 0;

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

        // Lv.1 20% 확률로 고양이를 더 생성해준다.
        // Lv.2 50% 확률로 고양이를 더 생성해준다.
        // Lv.3 뚱뚱한 고양이를 더 생성해준다.
        if (_level == 1)
        {
            int percent = Random.Range(0, 10);
            if(percent < 2) Instantiate(_normalCat);
        }
        else if (_level == 2)
        {
            int percent = Random.Range(0, 10);
            if (percent < 5) Instantiate(_normalCat);
        }
        else if (_level == 3)
        {
            Instantiate(_fatCat);
        }
        else if (_level == 4)
        {
            Instantiate(_pirateCat);
        }
    }

    public void GameOver()
    {
        _retryBtn.SetActive(true);
        Time.timeScale = 0f;
    }

    public void AddScore()
    {
        ++_score;
        _level = _score / 5;
        _levelText.text = _level.ToString();
        _levelFront.localScale = new Vector3((_score - _level * 5) / 5.0f, 1f, 1f);
    }
}
