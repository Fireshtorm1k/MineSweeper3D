using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class Tile : MonoBehaviour{
    [SerializeField] private Material _baseColor, _offsetColor;
    [SerializeField] private Renderer rend;
    [SerializeField] private GameObject flagPrefab;
    public AudioSource clickSound;
    private float rad = 1.4f;
    public List<GameObject> nums;
    private Vector3 coords;
    public bool selected;
    public static bool  isused;
    public bool odd;
    public bool clicked;

    private void Start()
    {
        clickSound = GameObject.Find("GridManager").GetComponent<AudioSource>();
        isused = false;
        rend = GetComponent<Renderer>();
        coords = transform.position;
    }

    public void Init(bool isOffset){
    
        if (isOffset) {GetComponent<MeshRenderer>().material = _offsetColor;
            odd = true;
        } else {GetComponent<MeshRenderer>().material = _baseColor;}
    }
    void OnMouseEnter()
    {
        if (!isused)
        {
            selected = true;
            Color color = rend.material.color;
            color.a = 0.6f;
            rend.material.color = color;
        }
    }

    void OnMouseExit()
    {
        if (!isused)
        {
            selected = false;
            Color color = rend.material.color;
            color.a = 1f;
            rend.material.color = color;
        }
    }

    void OnMouseUpAsButton()
    {
        if (!isused && gameObject.tag == "Tile")
        {
            clickSound.Play();
            click();
        }

        if (gameObject.tag == "Mine")
        {
            var mines = GameObject.FindGameObjectsWithTag("Mine");
            foreach (GameObject ren in mines)
            {
                ren.GetComponent<Renderer>().material.color = Color.red;
            }

            isused = true;

        }
    }

    public void click()
    {
        GridManager.save--;
        int minecount = 0;
        Collider[] overlappedColliders = Physics.OverlapSphere(transform.position, rad);
        foreach (Collider coll in overlappedColliders)
        {
            if (coll.gameObject.tag == "Mine")
            {
                minecount++;
            }
        }

        if (minecount != 0)
        {
            var spawnedNum = Instantiate(nums[minecount], new Vector3(coords.x, coords.y, coords.z - 0.5f),
                Quaternion.Euler(0, 0, 180));
        }
        else
        {
            foreach (Collider coll in overlappedColliders)
            {
                if (coll.gameObject.tag == "Tile") 
                {
                    coll.gameObject.GetComponent<Tile>().clicked = true;
                }
            }
        }
        Destroy(gameObject);
        
    }

   private void Update()
   {
       if (Input.GetKeyDown(KeyCode.Mouse1) && selected)
       {
           Instantiate(flagPrefab, new Vector3(coords.x, coords.y, coords.z), Quaternion.Euler(0, 0, 180));
       }

       if (clicked)
       {
           click();
           clicked = false;
       }
   }
}
