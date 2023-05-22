using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Save : MonoBehaviour
{
    public Slider x, y, mineChance, z;
    // Start is called before the first frame update
  public void SaveConfig()
    {
        PlayerPrefs.SetInt("GridX", GridManager._width);
        PlayerPrefs.SetInt("GridY", GridManager._height);
        PlayerPrefs.SetInt("GridZ", GridManager.third);
        PlayerPrefs.SetInt("MineChance", GridManager.mineChance);
    }
  public void LoadConfig()
    {
        if (PlayerPrefs.HasKey("GridX"))
        {
            x.value = PlayerPrefs.GetInt("GridX");
            y.value = PlayerPrefs.GetInt("GridY");
            z.value = PlayerPrefs.GetInt("GridZ");
            mineChance.value = PlayerPrefs.GetInt("MineChance");
        }
    }

    // Update is called once per frame
    
}
