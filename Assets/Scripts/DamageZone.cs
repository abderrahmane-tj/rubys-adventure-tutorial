using UnityEngine;

public class DamageZone : MonoBehaviour
{
    public void OnTriggerStay2D(Collider2D other)
    {
        var controller = other.GetComponent<RubyController>();
        if (controller == null || controller.health == 0) return;

        controller.ChangeHealth(-1);
    }
}
