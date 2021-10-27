using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ElephantSDK;

public class LevelController : MonoBehaviour
{

    [SerializeField] private List<GameObject> _leveller = new List<GameObject>();

    private int _levelNumarasi; //Listedeki level index

    private GameObject guncelLevel;

    private int _level;

    private int _guncelLevelNumarasi;

    private int _levelNumber; //UI'da yazan level text

    private int _toplamLevelSayisi;

    void Start()
    {
        if (guncelLevel)
        {
            Destroy(guncelLevel);
        }
        else
        {

        }
        // PlayerPrefs.SetInt("LevelNumaras?", 0);
        //_g?ncelLevelNumarasi = PlayerPrefs.GetInt("G?ncelLevelNumaras?");
        MainCharacterControl.lifeCount = 1;
        _levelNumarasi = PlayerPrefs.GetInt("LevelNumarasi");
        _levelNumber = PlayerPrefs.GetInt("LevelNumber");
        _toplamLevelSayisi = _leveller.Count - 1;

        if (_levelNumber < _toplamLevelSayisi)
        {
            _levelNumarasi = PlayerPrefs.GetInt("LevelNumarasi");
            guncelLevel = Instantiate(_leveller[_levelNumarasi], new Vector3(0, 0, 0), Quaternion.identity);
            Elephant.LevelStarted(_levelNumber);
        }
        else
        {
            _levelNumarasi = PlayerPrefs.GetInt("LevelNumarasi");

            guncelLevel = Instantiate(_leveller[_levelNumarasi], new Vector3(0, 0, 0), Quaternion.identity);
            Elephant.LevelStarted(_levelNumber);
        }
    }


    public void LevelDegistir()
    {
        MainCharacterControl.lifeCount = 1;
        Destroy(guncelLevel);
        _levelNumarasi = PlayerPrefs.GetInt("LevelNumarasi");
        _levelNumber = PlayerPrefs.GetInt("LevelNumber");
        _toplamLevelSayisi = _leveller.Count - 1;
        Elephant.LevelCompleted(_levelNumber);

        if (_levelNumber < _toplamLevelSayisi)
        {
            _levelNumarasi = PlayerPrefs.GetInt("LevelNumarasi");
            _levelNumarasi += 1;
            _levelNumber++;

            guncelLevel = Instantiate(_leveller[_levelNumarasi], new Vector3(0, 0, 0), Quaternion.identity);
            PlayerPrefs.SetInt("LevelNumarasi", _levelNumarasi);
            PlayerPrefs.SetInt("LevelNumber", _levelNumber);
            Elephant.LevelStarted(_levelNumber);
        }
        else
        {
            _levelNumarasi = PlayerPrefs.GetInt("LevelNumarasi");
            int _geciciLevelNumarasi = _levelNumarasi;

            _levelNumarasi = Random.Range(0, _toplamLevelSayisi);

            if (_levelNumarasi == _geciciLevelNumarasi)
            {
                LevelDegistir();
            }
            else
            {
                _levelNumber++;
                guncelLevel = Instantiate(_leveller[_levelNumarasi], new Vector3(0, 0, 0), Quaternion.identity);
                PlayerPrefs.SetInt("LevelNumarasi", _levelNumarasi);
                PlayerPrefs.SetInt("LevelNumber", _levelNumber);
                Elephant.LevelStarted(_levelNumber);
            }
            //PlayerPrefs.SetInt("G?ncelLevelNumaras?", _g?ncelLevelNumarasi);



        }


    }

    public void LevelRestart()
    {
        MainCharacterControl.lifeCount = 1;
        Destroy(guncelLevel);
        _levelNumarasi = PlayerPrefs.GetInt("LevelNumarasi");
        _toplamLevelSayisi = _leveller.Count - 1;
        Elephant.LevelFailed(_levelNumber);

        if (_levelNumber < _toplamLevelSayisi)
        {
            _levelNumarasi = PlayerPrefs.GetInt("LevelNumarasi");
            guncelLevel = Instantiate(_leveller[_levelNumarasi], new Vector3(0, 0, 0), Quaternion.identity);
            Elephant.LevelStarted(_levelNumber);
        }
        else
        {
            _levelNumarasi = PlayerPrefs.GetInt("LevelNumarasi");

            guncelLevel = Instantiate(_leveller[_levelNumarasi], new Vector3(0, 0, 0), Quaternion.identity);
            Elephant.LevelStarted(_levelNumber);
        }
    }
}
