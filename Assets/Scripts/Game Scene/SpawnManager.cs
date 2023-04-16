using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float HorizontalSpawnRange = 15f;
    public float SpawnStartDelay = 2.0f;
    public float SpawnInterval = 1.5f;

    public GameObject[] AnimalPrefabs;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnRandomAnimal), SpawnStartDelay, SpawnInterval);
    }

    private void SpawnRandomAnimal()
    {
        var index = Random.Range(0, AnimalPrefabs.Length);
        var animal = AnimalPrefabs[index];

        var x = transform.position.x;
        var xOffset = Random.Range(-HorizontalSpawnRange, HorizontalSpawnRange);
        var z = transform.position.z;
        var position = new Vector3(x + xOffset, 0f, z);

        var rotation = animal.transform.rotation;

        Instantiate(animal, position, rotation);
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Color gizmoColor = Color.cyan;
        Handles.color = gizmoColor;
        Gizmos.color = gizmoColor;

        var guiStyle = new GUIStyle();
        guiStyle.alignment = TextAnchor.UpperCenter;
        guiStyle.normal.textColor = gizmoColor;

        var middleX = transform.position.x;
        var left = middleX - HorizontalSpawnRange;
        var right = middleX + HorizontalSpawnRange;
        var middleZ = transform.position.z;
        var bottom = middleZ - 0.5f;
        var top = middleZ + 0.5f;

        var leftMiddle = new Vector3(left, 0f, middleZ);
        var rightMiddle = new Vector3(right, 0f, middleZ);
        Gizmos.DrawLine(leftMiddle, rightMiddle);

        var leftBottom = new Vector3(left, 0f, bottom);
        var leftTop = new Vector3(left, 0f, top);
        Gizmos.DrawLine(leftBottom, leftTop);

        var rightBottom = new Vector3(right, 0f, bottom);
        var rightTop = new Vector3(right, 0f, top);
        Gizmos.DrawLine(rightBottom, rightTop);

        var labelPosition = new Vector3(middleX, 0f, top - 0.5f);
        Handles.Label(labelPosition, "Animal Spawn Range", guiStyle);
    }
#endif
}
