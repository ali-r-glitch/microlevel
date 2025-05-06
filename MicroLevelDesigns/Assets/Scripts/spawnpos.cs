using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnpos : MonoBehaviour
{
    public Transform defaultSpawn;
    public Transform fromLeftSpawn;
    public Transform fromRightSpawn;
    public Transform fromTopSpawn;
    public Transform fromBottomSpawn;

    private void Start()
    {
        EntranceID entrance = GameManager.Instance?.lastEntrance ?? EntranceID.Default;

        Transform spawnPoint = entrance switch
        {
            EntranceID.FromLeft => fromLeftSpawn,
            EntranceID.FromRight => fromRightSpawn,
            EntranceID.FromTop => fromTopSpawn,
            EntranceID.FromBottom => fromBottomSpawn,
            _ => defaultSpawn
        };

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null && spawnPoint != null)
        {
            player.transform.position = spawnPoint.position;
        }
    }
}
