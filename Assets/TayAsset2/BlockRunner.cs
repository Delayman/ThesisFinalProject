using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockRunner : MonoBehaviour
{
    [SerializeField] private List<GameObject> spawner;
    private int id = 0;
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            id = SavedRole.savedRoleID;
            var spawnPos = new Vector3();
            switch (id)
            {
                case 0: spawnPos = spawner[0].transform.localPosition; break;
                case 1: spawnPos = spawner[1].transform.localPosition; break;
                case 2: spawnPos = spawner[2].transform.localPosition; break;
            }
            if (id == 1 || id == 2)
            {
                other.transform.localPosition = spawnPos;
            }

        }
    }
}
