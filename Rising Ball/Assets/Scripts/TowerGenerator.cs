using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerGenerator : MonoBehaviour
{
    private int towerCount = 0;

    [SerializeField] private GameObject deadFall;

    private void Start()
    {
        
        for (int i = 0; i < 10; i++) {
            SpawnTowerPiece(towerCount++ * 10);
        }
    }

    private void SpawnTowerPiece(int yPos)
    {
        GameObject towerPiece = ObjectPool.SharedInstance.GetPooledTowerPiece();
        if (towerPiece != null) {
            Vector3 pos = new Vector3(0, yPos, 0);
            towerPiece.transform.position = pos;
            towerPiece.transform.localRotation = new Quaternion(0, 0, 0, 1);
            towerPiece.SetActive(true);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Tower") {

            UpdateDeadFallPos(other.gameObject.transform.position.y);
            other.gameObject.SetActive(false);
            SpawnTowerPiece(towerCount++ * 10);

        }
    }

    private void UpdateDeadFallPos(float yPos)
    {
        Vector3 pos = new Vector3(0, yPos, 0);
        deadFall.transform.position = pos;
    }
}
