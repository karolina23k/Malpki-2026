using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class towerRange : MonoBehaviour 
{
    [SerializeField] private Tower Tower;
    private List<GameObject> targets = new List<GameObject>();

    private void Start()
    {
        UpdateRange();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.tag == "Enemy")
        {
            targets.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            targets.Remove(collision.gameObject);
           
        }


    }
    void Update()
    {
        if (targets.Count > 0)
        {
            Tower.target = targets[0];
        }
        else
        {
            Tower.target = null;
        }
    }
    public void UpdateRange()
    {
        transform.localScale = new Vector3(Tower.range, Tower.range, Tower.range);
    }
}
