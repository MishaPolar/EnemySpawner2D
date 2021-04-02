using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public void Spawn(GameObject gameObject)
    {
        Instantiate(gameObject, transform.position, Quaternion.identity);
    }
}
