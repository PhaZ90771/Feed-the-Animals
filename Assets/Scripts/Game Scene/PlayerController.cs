using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float HorizontalMovementRange = 10.0f;
    public float VerticalMovementRange = 10.0f;
    public float MovementSpeed = 20.0f;
    public GameObject[] FoodPrefabs;

    public ScoreTracker ScoreTracker;

    private void Awake()
    {
        ScoreTracker = FindAnyObjectByType<ScoreTracker>();
    }

    private void Update()
    {
        MovePlayer();
        BoundPlayerPosition();
        TryThrowFood();        
    }

    private void MovePlayer()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(horizontalInput * MovementSpeed * Time.deltaTime * Vector3.right);
        var verticalInput = Input.GetAxis("Vertical");
        transform.Translate(verticalInput * MovementSpeed * Time.deltaTime * Vector3.forward);
    }

    private void BoundPlayerPosition()
    {
        var pos = transform.position;
        pos.x = BoundValue(pos.x, -HorizontalMovementRange, HorizontalMovementRange);
        pos.z = BoundValue(pos.z, -VerticalMovementRange, VerticalMovementRange);
        transform.position = pos;
    }

    private float BoundValue(float value, float lowerBound, float upperBound)
    {
        if (value < lowerBound) return lowerBound;
        if (value > upperBound) return upperBound;
        return value;
    }

    private void TryThrowFood()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var index = Random.Range(0, FoodPrefabs.Length);
            var food = FoodPrefabs[index];
            Instantiate(food, transform.position, food.transform.rotation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var animal = other.gameObject.GetComponent<Animal>();
        if (animal)
        {
            animal.Feed();
        }
    }

    public void Kill()
    {
        SceneManager.LoadScene(2);
        Destroy(this.gameObject);
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

        Handles.Label(topMiddle, "Player Movement Range", guiStyle);
    }
#endif
}
