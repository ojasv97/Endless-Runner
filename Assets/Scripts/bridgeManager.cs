using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bridgeManager : MonoBehaviour {
    public GameObject[] bridgePrefab;
    private Transform playerTransform;
    private float spawnZ = 0.0f;
    private float bridgeLength = 7.57f;
    private int amnOfBridgesOnScreen = 15;
    private List<GameObject> activeBridge;
    private float bridgeGlitch = 9.0f;
    private int lastPrefabIndex = 0;
    // Use this for initialization
    void Start() {
        activeBridge = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        for (int i = 0; i < amnOfBridgesOnScreen; i++)
        {
            if(i<2)
            {
                spawnBridge(0);
            }
            else
            {
                spawnBridge();
            }
           
        }
	}
	
	// Update is called once per frame
	void Update () {
		if(playerTransform.position.z - bridgeGlitch > (spawnZ - amnOfBridgesOnScreen*bridgeLength))
        {
            spawnBridge();
            deleteBridge();
        }
	}
    private void spawnBridge(int prefabIndex=-1 )
    {
        GameObject go;

        if(prefabIndex==-1)
          go = Instantiate(bridgePrefab[randomPrefabIndex()]) as GameObject;
        else
            go = Instantiate(bridgePrefab[prefabIndex]) as GameObject;

        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += bridgeLength;
        activeBridge.Add(go);
    }
    private void deleteBridge()
    {
        Destroy(activeBridge[0]);
        activeBridge.RemoveAt(0);
    }
    private int randomPrefabIndex()
    {
        if(bridgePrefab.Length <= 1)
            return 0;
        
        
            int randomIndex = lastPrefabIndex;
            while(randomIndex==lastPrefabIndex)
            {
            randomIndex = Random.Range(0, bridgePrefab.Length);
            }
        lastPrefabIndex = randomIndex;
        return randomIndex;

    }
}
