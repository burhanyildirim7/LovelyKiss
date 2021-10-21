using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    [SerializeField] private GameObject _TapToStartScreen;
    [SerializeField] private GameObject _LevelScreen;
    [SerializeField] private GameObject _WinScreen;
    [SerializeField] private GameObject _LoseScreen;

    [SerializeField] private Text _TapToStart_DiamondCounter;
    [SerializeField] private Text _LevelScreen_DiamondCounter;
    [SerializeField] private Text _LevelScreen_LevelText;
    [SerializeField] private Text _WinScreen_DiamondCounter;
    [SerializeField] private Text _LoseScreen_DiamondCounter;

    [SerializeField] private LevelController levelController;
    RunningObject runningObject;
    private int _levelNumber = 1;
    private int _levelPoints = 0;
    private int _totalPoints = 0;

    void Start()
    {
        _TapToStartScreen.SetActive(true);
        _levelNumber = PlayerPrefs.GetInt("LevelNumber", 1);
        runningObject = GameObject.FindGameObjectWithTag("RunningObject").GetComponent<RunningObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_TapToStartScreen.activeSelf)
        {
            _TapToStart_DiamondCounter.text = PlayerPrefs.GetInt("ToplamElmasSayisi").ToString();
        }
        else if (_LevelScreen.activeSelf)
        {
            _LevelScreen_DiamondCounter.text = PlayerPrefs.GetInt("ToplamElmasSayisi").ToString();
            _LevelScreen_LevelText.text = "Level " + PlayerPrefs.GetInt("LevelNumber").ToString();
        }
    }

    public void btn_TapToStart()
    {
        _TapToStartScreen.SetActive(false);
        _LevelScreen.SetActive(true);
        GameController.isGameActive = true;
    }
    public void btn_NextLevel()
    {
        _totalPoints = PlayerPrefs.GetInt("ToplamElmasSayisi", 0);
        _levelPoints = PlayerPrefs.GetInt("LeveldeToplananElmasSayisi", 0);
        _totalPoints += _levelPoints;
        PlayerPrefs.SetInt("LeveldeToplananElmasSayisi", _levelPoints);
        PlayerPrefs.SetInt("ToplamElmasSayisi", _totalPoints);
        PlayerPrefs.Save();

        SetStaticsDefaultValues();
        runningObject.ResetCharacterTransform();

        _WinScreen.SetActive(false);
        _TapToStartScreen.SetActive(true);

        levelController.LevelDegistir();
    }
    public void btn_RestartButton()
    {
        _totalPoints = PlayerPrefs.GetInt("ToplamElmasSayisi", 0);
        _levelPoints = PlayerPrefs.GetInt("LeveldeToplananElmasSayisi", 0);
        _totalPoints += _levelPoints;
        PlayerPrefs.SetInt("LeveldeToplananElmasSayisi", _levelPoints);
        PlayerPrefs.SetInt("ToplamElmasSayisi", _totalPoints);
        PlayerPrefs.Save();

        SetStaticsDefaultValues();
        runningObject.ResetCharacterTransform();

        _LoseScreen.SetActive(false);
        _TapToStartScreen.SetActive(true);

        levelController.LevelRestart();
    }

    public void Win()
    {
        GameController.isGameActive = false;
        _LevelScreen.SetActive(false);
        _WinScreen.SetActive(true);
        _WinScreen_DiamondCounter.text = PlayerPrefs.GetInt("LeveldeToplananElmasSayisi").ToString();
    }

    public void Lose()
    {
        GameController.isGameActive = false;
        _LevelScreen.SetActive(false);
        _LoseScreen.SetActive(true);
        _LoseScreen_DiamondCounter.text = PlayerPrefs.GetInt("LeveldeToplananElmasSayisi").ToString();
    }

    public void SetStaticsDefaultValues()
    {
        CameraControl.cameraFinish = false;
        GameController.collectedDiamondNumber = 0;
        GameController.collectedLipstickNumber = 0;
        MainCharacterControl._isFinishLinePassed = false;
        MainCharacterControl._isGameStarted = false;
    }
}
