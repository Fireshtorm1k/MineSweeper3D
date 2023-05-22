using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = System.Random;


public class GridManager : MonoBehaviour
{
    [SerializeField] public static int _width, _height,third, mineChance;
    [SerializeField] private Tile _tilePrefab;
    [SerializeField] private Transform _cam;
    [SerializeField] private GameObject _mine;
    [SerializeField] private TMP_Text mineCountTMPText;
    public static int correctNumber, mineCount;
    public Slider _camSlide;
    public static int save;
    public GameObject text;
    private Random r = new Random();
    private void Start()
    {
        mineCount = 0;
        correctNumber = 0;
        save = 0;
        GenerateGrid();
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("Menu");
    }
    private void GenerateGrid()
    {
        int xpref = _width / 2;
        int ypref = third / 2;
        int zpref = _height / 2;
        for (int x = 0; x < _width; x++)
        {
            for (int z = 0; z < _height; z++)
            {
                for (int y = 0; y < third; y++)
                {
                    {
                        var spawnedTile = Instantiate(_tilePrefab, new Vector3(x, y, z), Quaternion.identity);

                        if (r.Next(1, 100) < mineChance)
                        {
                            spawnedTile.tag = "Mine";
                            mineCount++;
                        }

                        spawnedTile.name = $"{x}{y}{z}";
                        if (spawnedTile.transform.position == new Vector3((float)xpref, (float)ypref, (float)zpref))
                        { 
                            Camera.main.GetComponent<CameraController>().target = spawnedTile.transform;
                            Camera.main.GetComponent<CameraController>().targetpos = spawnedTile.transform.position; 
                        }
                    var isOffset = (x % 2 == 0 && z % 2 != 0) || (x % 2 != 0 && z % 2 == 0);
                        spawnedTile.Init(isOffset);
                    }
                }
            }
        }
        Debug.Log(mineCount);
        mineCountTMPText.text = mineCount.ToString();
    }
}
