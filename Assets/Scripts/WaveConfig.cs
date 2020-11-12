using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveConfig : MonoBehaviour
{
    [Header("Enemy prefab and delay before the spawn")]
    [SerializeField] List<(Attacker, float)> enemies;
}
