using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private enum PlayerType {None,Wizard,Archer,Heroes}
    [SerializeField] PlayerType playerType;
    [SerializeField] private float speed;
    [SerializeField] private float defend;
    [SerializeField] private float attack;
    [SerializeField] private float health;
    [SerializeField] private float jumpHeight;
    [SerializeField] private bool canJump;

    [SerializeField] private UnityEvent deathEvent;
}
