using UnityEngine;

public class curar : Ability
{
    salud salud1;
    [SerializeField] salud health;
    private float cooldownTimer;

    private void Update()
    {
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
            icon.fillAmount = 1 - (cooldownTimer / cooldown); // La barra se vacía en 1 segundo
        }
    }

    public override void Trigger()
    {
        if (cooldownTimer <= 0) // Solo se activa si el cooldown ha terminado
        {
            health.currentHealth += 60;
            print("+60");

            cooldownTimer = cooldown; 
            icon.fillAmount = 0; 
        }
    }
}

