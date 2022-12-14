using UnityEngine;

[CreateAssetMenu(fileName = "GameParameters", menuName = "ScriptableObjects/Create GameParameters ScriptableObject", order = 1)]
public class GameParameters : SingletonScriptableObject<GameParameters>
{
    public float ClimberJumpForce;
    public float MinGrabDistance = 1f;

    [SerializeField] private float _sawObstacleSpeed;
    public float SawObstacleSpeed { get => 1f / Mathf.Clamp(_sawObstacleSpeed, 0.1f, Mathf.Infinity); }
}
