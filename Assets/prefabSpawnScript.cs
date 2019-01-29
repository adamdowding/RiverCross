using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prefabSpawnScript : MonoBehaviour
{
    public int lilypadAmt;
    public GameObject lilypad;
    public bool ready = true;
    
    // Start is called before the first frame update



    void Start()
    {
        GameObject sp1 = gameObject.transform.GetChild(0).gameObject;
        GameObject sp2 = gameObject.transform.GetChild(1).gameObject;
        GameObject sp3 = gameObject.transform.GetChild(2).gameObject;
        GameObject sp4 = gameObject.transform.GetChild(3).gameObject;
        GameObject sp5 = gameObject.transform.GetChild(4).gameObject;
        GameObject[] sPoints = new GameObject[5];
    }

    IEnumerator SpawnPrefab()
    {
        ready = false;
        int spawnPointX = Random.Range(3, -16);
        Vector3 spawnPosition = new Vector3(spawnPointX, -4.5f, -37.7f);
        Instantiate(lilypad, spawnPosition, transform.rotation);
        yield return new WaitForSeconds(1.5f);
        ready = true;
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody lilyrb = lilypad.GetComponent<Rigidbody>();
        lilyrb.AddForce(0, 0, 5);

        if (ready)
        {
            StartCoroutine(SpawnPrefab());
        }
    }
}
