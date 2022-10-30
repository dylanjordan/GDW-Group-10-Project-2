using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EnemyMovement))]
public class EnemyMovementEditor : Editor
{
    private void OnSceneGUI()
    {
        EnemyMovement movement = (EnemyMovement)target;

        Handles.color = Color.red;
        Handles.DrawPolyLine(movement.waypoints);
        Handles.DrawLine(movement.waypoints[movement.waypoints.Length - 1], movement.waypoints[0]);
    }
}
