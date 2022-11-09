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
        foreach (Vector3 point in movement.waypoints)
        {
            if (point == movement.waypoints[0]) { Handles.color = Color.green; }
            else if (point == movement.waypoints[movement.waypoints.Length - 1]) { Handles.color = Color.red; }
            else { Handles.color = Color.yellow; }

            Handles.DrawWireCube(point, Vector3.one * 0.5f);
        }
    }
}
