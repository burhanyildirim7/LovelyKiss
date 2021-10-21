using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    [SerializeField] private List<GameObject> _leveller = new List<GameObject>();

    private int _levelNumarasi; //Listedeki level index

    private GameObject g�ncelLevel;

    private int _level;

    private int _g�ncelLevelNumarasi;

    private int _levelNumber; //UI'da yazan level text

    private int _toplamLevelSayisi;

    void Start()
    {
        if (g�ncelLevel)
        {
            Destroy(g�ncelLevel);
        }
        else
        {

        }
        // PlayerPrefs.SetInt("LevelNumaras�", 0);
        //_g�ncelLevelNumarasi = PlayerPrefs.GetInt("G�ncelLevelNumaras�");
        _levelNumarasi = PlayerPrefs.GetInt("LevelNumaras�",0);
        _levelNumber = PlayerPrefs.GetInt("LevelNumber",1);
        _toplamLevelSayisi = _leveller.Count - 1;

        if (_levelNumber < _toplamLevelSayisi)
        {
            _levelNumarasi = PlayerPrefs.GetInt("LevelNumaras�");
            g�ncelLevel = Instantiate(_leveller[_levelNumarasi], new Vector3(0, 0, 0), Quaternion.identity);
        }
        else
        {
            _levelNumarasi = PlayerPrefs.GetInt("LevelNumaras�");

            g�ncelLevel = Instantiate(_leveller[_levelNumarasi], new Vector3(0, 0, 0), Quaternion.identity);
        }
    }


    public void LevelDegistir()
    {
        Destroy(g�ncelLevel);
        _levelNumarasi = PlayerPrefs.GetInt("LevelNumaras�");
        _levelNumber = PlayerPrefs.GetInt("LevelNumber");
        _toplamLevelSayisi = _leveller.Count - 1;

        if (_levelNumber < _toplamLevelSayisi)
        {
            _levelNumarasi = PlayerPrefs.GetInt("LevelNumaras�");
            _levelNumarasi += 1;
            _levelNumber++;

            g�ncelLevel = Instantiate(_leveller[_levelNumarasi], new Vector3(0, 0, 0), Quaternion.identity);
            PlayerPrefs.SetInt("LevelNumaras�", _levelNumarasi);
            PlayerPrefs.SetInt("LevelNumber", _levelNumber);
        }
        else
        {
            _levelNumarasi = PlayerPrefs.GetInt("LevelNumaras�");
            int _geciciLevelNumarasi = _levelNumarasi;

            _levelNumarasi = Random.Range(0, _toplamLevelSayisi);

            if (_levelNumarasi == _geciciLevelNumarasi)
            {
                LevelDegistir();
            }
            else
            {
                _levelNumber++;
                g�ncelLevel = Instantiate(_leveller[_levelNumarasi], new Vector3(0, 0, 0), Quaternion.identity);
                PlayerPrefs.SetInt("LevelNumaras�", _levelNumarasi);
                PlayerPrefs.SetInt("LevelNumber", _levelNumber);
            }
            //PlayerPrefs.SetInt("G�ncelLevelNumaras�", _g�ncelLevelNumarasi);



        }


    }

    public void LevelRestart()
    {
        Destroy(g�ncelLevel);
        _levelNumarasi = PlayerPrefs.GetInt("LevelNumaras�");
        _toplamLevelSayisi = _leveller.Count - 1;

        if (_levelNumber < _toplamLevelSayisi)
        {
            _levelNumarasi = PlayerPrefs.GetInt("LevelNumaras�");
            g�ncelLevel = Instantiate(_leveller[_levelNumarasi], new Vector3(0, 0, 0), Quaternion.identity);
        }
        else
        {
            _levelNumarasi = PlayerPrefs.GetInt("LevelNumaras�");

            g�ncelLevel = Instantiate(_leveller[_levelNumarasi], new Vector3(0, 0, 0), Quaternion.identity);
        }
    }
}
