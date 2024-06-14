using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Vector3 lastCheckpoint;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("player"))
        {
            lastCheckpoint = other.transform.position;
            SaveGame();
        }
    }

    void SaveGame()
    {
        PlayerPrefs.SetFloat("LastchechpointX", lastCheckpoint.x);
        PlayerPrefs.SetFloat("LastcheckpointY", lastCheckpoint.y);
        PlayerPrefs.SetFloat("LastcheckpointZ", lastCheckpoint.z);
        PlayerPrefs.Save();
    }


    void LoadGame()
    {
        float x = PlayerPrefs.GetFloat("lastCheckpointX", 0);
        float y = PlayerPrefs.GetFloat("lastCheckpointY", 0);
        float z = PlayerPrefs.GetFloat("lastCheckpointZ", 0);
        lastCheckpoint = new Vector3(x,y,z);
    }

    
    
}
