using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    Health damage;
    public GameObject hitPoints;

    public float speed;
    public bool left = true;

    // Start is called before the first frame update
    void Start()
    {
        damage = hitPoints.GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (left)
        {
            transform.position = new Vector2(transform.position.x - speed, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x + speed, transform.position.y);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            damage.TakeDamage(1);
        }
        if (coll.tag == "Wall" && left == true)
        {
            left = false;
        }
        else if (coll.tag == "Wall" && left == false)
        {
            left = true;
        }
    }
}

    