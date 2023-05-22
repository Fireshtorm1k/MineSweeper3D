using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.UI;
using Slider = UnityEngine.UI.Slider;
public class MenuController : MonoBehaviour
{
   public GameObject slidex;
   public GameObject slidey;
   public GameObject slidez;
   public GameObject mineChanceobject;
   public Slider x;
   public Slider y;
   public Slider mineChance;
   public Slider z;
   public void PlayPressed()
   {
      mine();
      xSlider();
      ySlider();
      zSlider();
      SceneManager.LoadScene("SampleScene");
   }

   public void Start()
   {
      x = slidex.GetComponent<Slider>();
      y = slidey.GetComponent<Slider>();
      z = slidez.GetComponent<Slider>();
      mineChance = mineChanceobject.GetComponent<Slider>();
      if (PlayerPrefs.HasKey("GridX"))
      {
         x.value = PlayerPrefs.GetInt("GridX");
         y.value = PlayerPrefs.GetInt("GridY");
         z.value = PlayerPrefs.GetInt("GridZ");
         mineChance.value = PlayerPrefs.GetInt("MineChance");
      }
   }
   
   public void mine()
   {
      GridManager.mineChance = (int)mineChance.value;
   }

   public void xSlider()
   {
      GridManager._width = (int)x.value;
   }
   public void ySlider()
   {
      GridManager._height = (int)y.value;
   }
   public void zSlider()
   {
      GridManager.third = (int)z.value;
   }
   public void Quit()
   {
      Application.Quit();
   }
}
