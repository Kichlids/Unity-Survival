using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float maxHealth;
    public float maxThirst;
    public float maxHunger;

    public float thirstDecreaseRate;
    public float hungerDecreaseRate;

    private float health;
    private float thirst;
    private float hunger;

    public bool dead;

    private void Start() {
        health = maxHealth;
        thirst = maxThirst;
        hunger = maxHunger;
    }

    private void Update() {
        if (!dead) {
            thirst -= thirstDecreaseRate * Time.deltaTime;
            hunger -= hungerDecreaseRate * Time.deltaTime;
        }

        if (thirst <= 0 || hunger <= 0) {
            Die();
        }
    }

    public void Die() {
        dead = true;
    }
}
