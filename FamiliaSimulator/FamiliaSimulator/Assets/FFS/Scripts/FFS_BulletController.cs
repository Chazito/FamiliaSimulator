using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FFS_BulletController : MonoBehaviour {

    public GameObject shooter;

    private int damage;
    private int speed;
    private bool initialized = false;

    void InitBullet(GameObject shooter)
    {
        this.shooter = shooter;
        damage = shooter.GetComponent<FFS_CharacterStats>().damage.GetValue();
        speed = shooter.GetComponent<FFS_CharacterStats>().bulletSpeed.GetValue();
    }
    
	// Update is called once per frame
	void Update () {
        if (initialized)
        {
            transform.Translate(new Vector3(0, -speed * Time.deltaTime));
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((collision.gameObject != shooter))
        {
            FFS_BulletController cousin = collision.gameObject.GetComponent<FFS_BulletController>();
            if(cousin == null)
            {
                FFS_CharacterStats livingObject = collision.gameObject.GetComponent<FFS_CharacterStats>();
                if(livingObject != null)
                {
                    livingObject.TakeDamage(damage);
                }
                Destroy(this.gameObject);
            }
        }
    }
}
