using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        var controller = other.GetComponent<RubyController>();
        if (controller == null) return;

        controller.ChangeHealth(1);
        Destroy(gameObject);

        if (controller.health < controller.maxHealth)
        {
            controller.ChangeHealth(1);
            Destroy(gameObject);
        }
    }
}
