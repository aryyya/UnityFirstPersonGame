using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] private int _health = 5;

    void Start()
    {
    }

    void Update()
    {
    }

    public void Hurt(int damage)
    {
        _health -= damage;
        Debug.Log("Player health: " + _health);

        if (_health < 1)
        {
            Debug.Log("Player is dead.");
        }
    }
}
