using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _amount;

    public int Amount => _amount;
}