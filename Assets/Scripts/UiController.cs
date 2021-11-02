using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;

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

    [SerializeField] private GameObject _runningObjectPrefab;

    [SerializeField] private GameObject _kadinObjectPrefab;

    private GameObject _kadin;

    private GameObject _dudak;

    RunningObject runningObject;
    private int _levelNumber = 1;
    private int _levelPoints = 0;
    private int _totalPoints = 0;

    private int _oyunBasladi = 0;

    void Start()
    {
        _TapToStartScreen.SetActive(true);
        _levelNumber = PlayerPrefs.GetInt("LevelNumber");
        _oyunBasladi = PlayerPrefs.GetInt("OyunBasladi");
        if (_oyunBasladi == 0)
        {
            PlayerPrefs.SetInt("LevelNumber", 1);
            _oyunBasladi = 1;
            PlayerPrefs.SetInt("OyunBasladi", _oyunBasladi);
        }
        else
        {

        }

        _kadin = Instantiate(_kadinObjectPrefab, new Vector3(0, 0.5f, -1), Quaternion.identity);

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
        GameObject.FindGameObjectWithTag("Kadin").GetComponent<kissAtma>().KissAt();
       // Instantiate(_runningObjectPrefab, new Vector3(0, 4, 0), Quaternion.identity);
       // GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraControl>().CameraSetTarget();
        //GameController.isGameActive = true;
        Invoke("IsGameActive", 2f);
       // GameObject.Find("DudakPrefab").GetComponent<Animator>().SetBool("Start",true);
       // runningObject = GameObject.FindGameObjectWithTag("RunningObject").GetComponent<RunningObject>();

    }

    public void btn_NextLevel()
    {
        Destroy(_kadin);
        Destroy(_dudak);

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

        _kadin = Instantiate(_kadinObjectPrefab, new Vector3(0, 0.5f, -1), Quaternion.identity);

        levelController.LevelDegistir();

        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraControl>().CameraResetPosition();
    }

    public void btn_RestartButton()
    {
        Destroy(_kadin);
        Destroy(_dudak);

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

        _kadin = Instantiate(_kadinObjectPrefab, new Vector3(0, 0.5f, -1), Quaternion.identity);

        levelController.LevelRestart();

        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraControl>().CameraResetPosition();
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

    private void IsGameActive()
    {
        _dudak = Instantiate(_runningObjectPrefab, new Vector3(0, 4, 0), Quaternion.identity);
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraControl>().CameraSetTarget();
        GameController.isGameActive = true;
        GameObject.Find("DudakPrefab").GetComponent<Animator>().SetBool("Start", true);
        runningObject = GameObject.FindGameObjectWithTag("RunningObject").GetComponent<RunningObject>();

    }
}
