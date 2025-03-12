using UnityEngine;

public class Teletransportacion : Ability
{
    [SerializeField] private atributos attributes;
    [SerializeField] private Camera camara;
    public ParticleSystem particulas;
    [SerializeField] private SpriteRenderer player;

    private float cooldownTimer;
    public float time = 10;
    private void Update()
    {
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
            icon.fillAmount = 1 - (cooldownTimer / cooldown); 
        }
    }
    private void Start()
    {
            particulas.Stop();

    }

    public override void Trigger()
    {
        if (cooldownTimer <= 0)
        {
            var main = particulas.main;
            main.startColor = player.color;
            particulas.Play();
            Vector3 objetivo = camara.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -camara.transform.position.z));
            transform.position = new Vector3(objetivo.x, objetivo.y, transform.position.z);
            cooldownTimer = cooldown;
            icon.fillAmount = 0;


        }


    }
}


