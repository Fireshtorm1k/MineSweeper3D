using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnNumber : MonoBehaviour
{
    [SerializeField] private Vector3 rad = new Vector3(1.035f, 0.25f, 0.845f);
    public Vector3 center;

    [SerializeField] private Material onMouse, even, odd, flag;

    // Start is called before the first frame update
    private void Start()
    {
        center = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.5f);
    }

    private void OnMouseEnter()
    {
        if (!Tile.isused)
        {
            Collider[] overlappedColliders = Physics.OverlapBox(center, rad);
            foreach (Collider coll in overlappedColliders)
            {
                if (coll.gameObject.tag == "Tile" || coll.gameObject.tag == "Mine")
                {
                    coll.gameObject.GetComponent<Renderer>().material = onMouse;
                    Color color = coll.gameObject.GetComponent<Renderer>().material.color;
                    color.a = 0.6f;
                    coll.gameObject.GetComponent<Renderer>().material.color = color;
                }
            }
        }
    }

    private void OnMouseExit()
    {
        if (!Tile.isused)
        {
            Collider[] overlappedColliders = Physics.OverlapBox(center, rad);
            foreach (Collider coll in overlappedColliders)
            {
                if (coll.gameObject.GetComponent<Tile>() != null && !Tile.isused)
                {
                    if (coll.gameObject.GetComponent<Tile>().odd && !Tile.isused)
                    {
                        coll.gameObject.GetComponent<Renderer>().material = odd;
                    }
                    else if (!coll.gameObject.GetComponent<Tile>().odd && !Tile.isused)
                    {
                        coll.gameObject.GetComponent<Renderer>().material = even;
                    }
                }
                if (coll.gameObject.tag == "Flag")
                {
                    coll.gameObject.GetComponent<Renderer>().material = flag;
                }
            }
        }
    }
}
