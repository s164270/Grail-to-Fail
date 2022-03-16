using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{    public Transform Weapon;
    public GameObject Attack1;

    public Camera maincamera;

    public float Attackforce = 20f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            CurrentAttack();
        }
    }
    private void CurrentAttack()
    {
        GameObject attack = Instantiate(Attack1, Weapon.position,  Weapon.rotation);

        Rigidbody2D rb2d = attack.GetComponent<Rigidbody2D>();

        Vector3 lookDir = maincamera.ScreenToWorldPoint(Input.mousePosition);

        lookDir.z = 0;

        lookDir = (lookDir - attack.transform.position).normalized;

        rb2d.AddForce(lookDir * Attackforce, ForceMode2D.Impulse);

    }

}
