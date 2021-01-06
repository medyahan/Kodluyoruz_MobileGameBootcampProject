using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private static ObjectPool _instance;
    public static ObjectPool SharedInstance { get { return _instance; } }

    public GameObject tower;
    public GameObject[] towerPiecesToPool;
    [HideInInspector]
    public List<GameObject> pooledTowerPieces;
    public int towerPieceCount;

   private int spawnedTowerPieceCount = 0;

    private void Awake()
    {
        // Singleton Pattern
        if (_instance != null && _instance != this)
            Destroy(gameObject);
        else
            _instance = this;

        pooledTowerPieces = new List<GameObject>();

        CreateTowerPiecesPool();

    }

    /// <summary>
    /// creates a pool of tower pieces --> pooledTowerPieces List
    /// towerPiecesToPool is the array of tower pieces we got from inspector
    /// towerPieceCount how many of that piece we want to have
    /// </summary>
    public void CreateTowerPiecesPool()
    {
        for (int i = 0; i < towerPiecesToPool.Length; i++) {
            for (int j = 0; j < towerPieceCount; j++) {
                GameObject obj = Instantiate(towerPiecesToPool[i]);
                pooledTowerPieces.Add(obj);
                obj.transform.parent = tower.transform;
                obj.SetActive(false);
            }

        }
    }

    /// <summary>
    /// for getting a random pooledTowerPiece
    /// 
    /// 
    /// </summary>
    /// <returns></returns>
    public GameObject GetPooledTowerPiece()
    {
        int randTowerPiece;

        if (!(spawnedTowerPieceCount == pooledTowerPieces.Count)) {// If there is no remaining available pooled objects.
            do {
                randTowerPiece = Random.Range(0, pooledTowerPieces.Count);
            } while (pooledTowerPieces[randTowerPiece].activeInHierarchy);
            spawnedTowerPieceCount++;
            return pooledTowerPieces[randTowerPiece];
        } else { // expand if pool is not enough
            CreateTowerPiecesPool();
            return GetPooledTowerPiece();
        }

    }

    
}
