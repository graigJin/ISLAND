using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSpawner : MonoBehaviour
{
    public GameObject woodResourcePrefab;
    public GameObject stoneResourcePrefab;
    public WorldManager worldManager;

    // Start is called before the first frame update
    void Awake()
    {
        for (int z = 1; z < worldManager.Height - 1; z++)
        {
            for (int x = 1; x < worldManager.Width - 1; x++)
            {
                float r = Random.Range(0, 1f);

                if (r <= 0.05f)
                {
                    CreateObjectInstance(woodResourcePrefab, x, z);
                } else if (r <= 0.1f)
                {
                    CreateObjectInstance(stoneResourcePrefab, x, z);
                }
            }
        }
    }

    private void CreateObjectInstance(GameObject obj, float x, float z)
    {
        GameObject go = Instantiate(obj, transform, true);
        go.transform.position = new Vector3(x, 0, z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
