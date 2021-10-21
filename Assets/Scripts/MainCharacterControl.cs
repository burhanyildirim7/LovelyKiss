using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterControl : MonoBehaviour
{
    [SerializeField] private Vector3 growthValue = new Vector3(0.3f, 0.2f, 0f);
    [Header("Oyun sonu karakterin hýzýný arttýrmak için RunningObject atamasý yapýyoruz.")]
    [SerializeField] private GameObject runningObject;
    [Header("Öpücüðün X'te büyüyebileceði maksimum deðer")]
    [SerializeField] private float _maxScaleForX = 9f;
    static public bool _isGameStarted = false;
    static public bool _isFinishLinePassed = false; //Karakter bitiþ çizgisini geçtiðinde PlayerMovement'in dart'ýn merkezine gitmesi için bu deðeri kontrol edecek.
    private UiController uiController;
    private int _levelPoints = 0;
    private int _totalPoints = 0;
    private int lifeCount;
    void Start()
    {
        _levelPoints = PlayerPrefs.GetInt("LeveldeToplananElmasSayisi", 0);
        _totalPoints = PlayerPrefs.GetInt("ToplamElmasSayisi", 0);
        lifeCount = 1;
        _isGameStarted = true;
        uiController = GameObject.Find("UiController").GetComponent<UiController>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ruj")
        {
            transform.localScale += growthValue;
            lifeCount++;
            Destroy(other.gameObject);
        }
        else if (other.tag == "Engel")
        {
            transform.localScale -= growthValue;
            lifeCount--;
            other.gameObject.GetComponent<EnemyController>().EnemyKissed();
            other.gameObject.GetComponent<EnemyController>().CreateKissFx();
            if (lifeCount == 0)
            {
                CalculatePoints();
                uiController.Lose();
            }
        }
        else if (other.tag == "Elmas")
        {
            GameController.collectedDiamondNumber++;
            _totalPoints = PlayerPrefs.GetInt("ToplamElmasSayisi", 0);
            _totalPoints++;
            PlayerPrefs.SetInt("ToplamElmasSayisi", _totalPoints);
            PlayerPrefs.Save();
            Destroy(other.gameObject);
        }
        else if (other.tag == "FinishLine")
        {
            CameraControl.cameraFinish = true;
            _isFinishLinePassed = true;
            runningObject.GetComponent<RunningObject>()._speed = 20f;
        }
        else if (other.tag == "Dart")
        {
            GameController.isGameActive = false;
            CalculatePoints();
            uiController.Win();
        }

    }

    void CalculatePoints()
    {
        _levelPoints = PlayerPrefs.GetInt("LeveldeToplananElmasSayisi", 0);
        var katsayi = transform.localScale.x / _maxScaleForX * 10;
        if (katsayi == 0)
            katsayi = 1;
        _levelPoints = (int)(GameController.collectedDiamondNumber * katsayi);
        PlayerPrefs.SetInt("LeveldeToplananElmasSayisi", _levelPoints);
        PlayerPrefs.Save();
    }


}

