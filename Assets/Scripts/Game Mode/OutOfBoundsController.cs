using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class OutOfBoundsController : MonoBehaviour
{
    public float HorizontalMovementRange = 10.0f;
    public float VerticalMovementRange = 10.0f;

    private BoxCollider boxCollider;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
        var size = new Vector3(HorizontalMovementRange * 2f, 0f, VerticalMovementRange * 2f);
        boxCollider.size = size;
    }

    private void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Food>())
        {
            Destroy(other.gameObject);
        }
        else if (other.gameObject.GetComponent<Animal>())
        {
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        }
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

        var topLeft = new Vector3(-HorizontalMovementRange, 0f, VerticalMovementRange);
        var topRight = new Vector3(HorizontalMovementRange, 0f, VerticalMovementRange);
        var bottomLeft = new Vector3(-HorizontalMovementRange, 0f, -VerticalMovementRange);
        var bottomRight = new Vector3(HorizontalMovementRange, 0f, -VerticalMovementRange);
        var topMiddle = new Vector3(0f, 0f, VerticalMovementRange - 0.25f);

        Gizmos.DrawLine(topLeft, topRight);
        Gizmos.DrawLine(topRight, bottomRight);
        Gizmos.DrawLine(bottomRight, bottomLeft);
        Gizmos.DrawLine(bottomLeft, topLeft);

        Handles.Label(topMiddle, "In Bounds Range", guiStyle);
    }
#endif
}
