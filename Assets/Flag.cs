using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using Object = System.Object;

public class Flag : MonoBehaviour
{
    private bool selected;
    [SerializeField] private Vector3 center, size = new Vector3(0.2f, 8f, 0.2f);
    public TMP_Text Text;
    public static int score;
  [SerializeField] public bool correct;
  [SerializeField] private LayerMask mask;
    private void OnMouseEnter()
    {
        selected = true;
    }

    private void Start()
    {
       this.correct = false;
        Collider[] colls;
        center = transform.position;
        colls = Physics.OverlapBox(center, size);
        foreach (Collider coll in colls)
        {
            if (coll.gameObject.tag == "Mine")
            {
                this.correct = true;
                GridManager.correctNumber += 1;
                score ++;
            }

            if (coll.gameObject.tag == "Tile")
            {
                this.correct = false;
                GridManager.correctNumber--;
            }
            
        }
        Debug.Log(GridManager.correctNumber);
    }

    private void OnMouseExit()
    {
        selected = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && selected)
        {
            if (this.correct)
            {
                GridManager.correctNumber--;
            }
            else if (!this.correct)
            {
                GridManager.correctNumber++;
            }
            Destroy(gameObject);
            Debug.Log(GridManager.correctNumber);
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawCube(center, size);
    }
}
 