using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    [SerializeField] private List<GameObject> _leveller = new List<GameObject>();

    private int _levelNumarasi; //Listedeki level index

    private GameObject güncelLevel;

    private int _level;

    private int _güncelLevelNumarasi;

    private int _levelNumber; //UI'da yazan level text

    private int _toplamLevelSayisi;

    void Start()
    {
        if (güncelLevel)
        {
            Destroy(güncelLevel);
        }
        else
        {

        }
        // PlayerPrefs.SetInt("LevelNumarasý", 0);
        //_güncelLevelNumarasi = PlayerPrefs.GetInt("GüncelLevelNumarasý");
        _levelNumarasi = PlayerPrefs.GetInt("LevelNumarasý",0);
        _levelNumber = PlayerPrefs.GetInt("LevelNumber",1);
        _toplamLevelSayisi = _leveller.Count - 1;

        if (_levelNumber < _toplamLevelSayisi)
        {
            _levelNumarasi = PlayerPrefs.GetInt("LevelNumarasý");
            güncelLevel = Instantiate(_leveller[_levelNumarasi], new Vector3(0, 0, 0), Quaternion.identity);
        }
        else
        {
            _levelNumarasi = PlayerPrefs.GetInt("LevelNumarasý");

            güncelLevel = Instantiate(_leveller[_levelNumarasi], new Vector3(0, 0, 0), Quaternion.identity);
        }
    }


    public void LevelDegistir()
    {
        Destroy(güncelLevel);
        _levelNumarasi = PlayerPrefs.GetInt("LevelNumarasý");
        _levelNumber = PlayerPrefs.GetInt("LevelNumber");
        _toplamLevelSayisi = _leveller.Count - 1;

        if (_levelNumber < _toplamLevelSayisi)
        {
            _levelNumarasi = PlayerPrefs.GetInt("LevelNumarasý");
            _levelNumarasi += 1;
            _levelNumber++;

            güncelLevel = Instantiate(_leveller[_levelNumarasi], new Vector3(0, 0, 0), Quaternion.identity);
            PlayerPrefs.SetInt("LevelNumarasý", _levelNumarasi);
            PlayerPrefs.SetInt("LevelNumber", _levelNumber);
        }
        else
        {
            _levelNumarasi = PlayerPrefs.GetInt("LevelNumarasý");
            int _geciciLevelNumarasi = _levelNumarasi;

            _levelNumarasi = Random.Range(0, _toplamLevelSayisi);

            if (_levelNumarasi == _geciciLevelNumarasi)
            {
                LevelDegistir();
            }
            else
            {
                _levelNumber++;
                güncelLevel = Instantiate(_leveller[_levelNumarasi], new Vector3(0, 0, 0), Quaternion.identity);
                PlayerPrefs.SetInt("LevelNumarasý", _levelNumarasi);
                PlayerPrefs.SetInt("LevelNumber", _levelNumber);
            }
            //PlayerPrefs.SetInt("GüncelLevelNumarasý", _güncelLevelNumarasi);



        }


    }

    public void LevelRestart()
    {
        Destroy(güncelLevel);
        _levelNumarasi = PlayerPrefs.GetInt("LevelNumarasý");
        _toplamLevelSayisi = _leveller.Count - 1;

        if (_levelNumber < _toplamLevelSayisi)
        {
            _levelNumarasi = PlayerPrefs.GetInt("LevelNumarasý");
            güncelLevel = Instantiate(_leveller[_levelNumarasi], new Vector3(0, 0, 0), Quaternion.identity);
        }
        else
        {
            _levelNumarasi = PlayerPrefs.GetInt("LevelNumarasý");

            güncelLevel = Instantiate(_leveller[_levelNumarasi], new Vector3(0, 0, 0), Quaternion.identity);
        }
    }
}
