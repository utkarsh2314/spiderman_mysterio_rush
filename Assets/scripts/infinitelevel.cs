using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infinitelevel : MonoBehaviour
{
    public Transform nextMapReference;
    public GameObject mapPrefab;
 

    private Vector3 lastMapPosition;

    private void Start()
    {
        lastMapPosition = nextMapReference.position;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collision");
            // Instantiate a new map at the position of the nextMapReference
            GameObject newMap = Instantiate(mapPrefab, nextMapReference.position, Quaternion.identity);

            // Calculate the offset based on the size of the previous map's collider
            Vector3 pivotOffset = CalculatePivotOffset(newMap);

            // Adjust the position of the new map
            newMap.transform.position = lastMapPosition + pivotOffset;

            // Update the lastMapPosition to the current position of the new map
            lastMapPosition = newMap.transform.position;

            // Update the nextMapReference to the new map's empty object
            nextMapReference = newMap.transform.Find("endpoint"); // Replace "EmptyObject" with the actual name of your empty object
        
    }

    private Vector3 CalculatePivotOffset(GameObject map)
    {
        Vector3 pivotOffset = Vector3.zero;

        // Get the collider of the map
        Collider mapCollider = map.GetComponentInChildren<BoxCollider>();
        if (mapCollider != null)
        {
            pivotOffset.y = mapCollider.bounds.size.y * 0.5f;
            pivotOffset.x = 0;
        }
        else
        {
            Debug.LogError("Collider2D component not found in the map prefab!");
        }

        return pivotOffset;
    }
}
