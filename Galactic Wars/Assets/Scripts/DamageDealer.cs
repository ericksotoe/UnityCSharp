using UnityEngine;

public class DamageDealer : MonoBehaviour {

    // config parameters
    [SerializeField] int damage = 100;

    // getter method that returns damage
    public int GetDamage() {
        return damage;
    }

    public void Hit() {
        Destroy(gameObject);
    }

}
