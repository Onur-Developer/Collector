using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] Objeler;
    public float x1, x2;
    void Start()
    {
        x1 = transform.position.x - GetComponent<BoxCollider2D>().bounds.size.x / 2;
        x2 = transform.position.x + GetComponent<BoxCollider2D>().bounds.size.x / 2;
        // InvokeRepeating("Clone", 1, 2);
        StartCoroutine(CloneF(2));
    }

    void Update()
    {

    }
    IEnumerator CloneF(float zaman)
    {
        yield return new WaitForSeconds(zaman);
        Instantiate(Objeler[Random.Range(0, Objeler.Length)], new Vector3(Random.Range(x1,x2),transform.position.y,transform.position.z), Quaternion.identity);
        StartCoroutine(CloneF(Random.Range(1, 2)));
    }
    void Clone()
    {
        Instantiate(Objeler[Random.Range(0, Objeler.Length)], transform.position, Quaternion.identity);
        transform.position = new Vector2(Random.Range(-2.5f, 2.5f), 6.49f);
    }
}
