using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float HorizontalSpawnRange = 10f;
    public float VerticalSpawnRange = 10f;
    public float SpawnStartDelay = 2.0f;
    public float SpawnInterval = 1.5f;
    public ORIENTATION SpawnOrientation = ORIENTATION.Downwards;

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
        var zOffset = Random.Range(-VerticalSpawnRange, VerticalSpawnRange);
        var position = new Vector3(x + xOffset, 0f, z + zOffset);

        var rotation = animal.transform.rotation;
        switch (SpawnOrientation)
        {
            case ORIENTATION.Downwards:
                rotation *= Quaternion.LookRotation(Vector3.forward);
                break;
            case ORIENTATION.Upwards:
                rotation *= Quaternion.LookRotation(Vector3.back);
                break;
            case ORIENTATION.Leftwards:
                rotation *= Quaternion.LookRotation(Vector3.right);
                break;
            case ORIENTATION.Rightwards:
                rotation *= Quaternion.LookRotation(Vector3.left);
                break;
        }
        Instantiate(animal, position, rotation);
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Color gizmoColor = Color.cyan;
        Handles.color = gizmoColor;
        Gizmos.color = gizmoColor;

        var guiStyle = new GUIStyle();
        guiStyle.alignment = TextAnchor.LowerCenter;
        guiStyle.normal.textColor = gizmoColor;

        var middleX = transform.position.x;
        var left = middleX - HorizontalSpawnRange;
        var right = middleX + HorizontalSpawnRange;
        var middleZ = transform.position.z;
        var bottom = middleZ - VerticalSpawnRange;
        var top = middleZ + VerticalSpawnRange;

        var size = new Vector3(HorizontalSpawnRange * 2f, 0f, VerticalSpawnRange * 2f);
        Gizmos.DrawWireCube(transform.position, size);

        var labelPosition = new Vector3(middleX, 0f, top + 0.5f);
        Handles.Label(labelPosition, "Animal Spawn Range", guiStyle);
    }
#endif

    public enum ORIENTATION
    {
        Downwards,
        Upwards,
        Leftwards,
        Rightwards
    }
}
