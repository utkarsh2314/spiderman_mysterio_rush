using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 20f;

    [SerializeField] private Transform levelPart_Start;
    [SerializeField] private List<Transform> levelPartList;
    [SerializeField] private Transform player;

    private Vector3 lastEndPosition;

    private void Awake()
    {
        lastEndPosition = levelPart_Start.Find("endposition").position;

    }

    private void Update()
    {
        Debug.Log(Vector3.Distance(player.transform.position, lastEndPosition));
        if (Vector3.Distance(player.transform.position, lastEndPosition) < PLAYER_DISTANCE_SPAWN_LEVEL_PART)
        {
            SpawnLevelPart();
        }
    }

    private void SpawnLevelPart()
    {
        Transform chosenLevelPart = levelPartList[Random.Range(0, levelPartList.Count)];
        Vector3 spawnPosition = lastEndPosition;
        Quaternion spawnRotation = Quaternion.identity;

        Transform levelPartTransform = Instantiate(chosenLevelPart, spawnPosition, spawnRotation);
        lastEndPosition = levelPartTransform.Find("endposition").position;
    }
}
