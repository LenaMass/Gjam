using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private Transform spawnPoint;
    private Transform playerPos;
    

    private void Start()
    {
       playerPos = GameObject.FindGameObjectWithTag("Player").transform;
       spawnPoint = GameObject.FindGameObjectWithTag("Respawn").transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Entered Trigger");
            playerPos.position = new Vector3(spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.z);
        }


    }
}
