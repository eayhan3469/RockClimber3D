using UnityEngine;

[CreateAssetMenu(fileName = "GameParameters", menuName = "ScriptableObjects/Create GameParameters ScriptableObject", order = 1)]
public class GameParameters : SingletonScriptableObject<GameParameters>
{
    public float ClimberJumpForce;
}
