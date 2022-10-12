using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Transform Plr1, Plr1_turret, Plr1_shoot, Plr2, Plr2_turret, Plr2_shoot;

    [SerializeField] float speed = 5f, rotationSpeed = 100.0f, turret_rot = 2f;

    [SerializeField] GameObject Shell;

    void Update()
    {
        float Plr1_verticalInput = Input.GetAxis("Plr1_Vertical") * speed * Time.deltaTime;
        float Plr1_horizontalInput = Input.GetAxis("Plr1_Horizontal") * rotationSpeed * Time.deltaTime;
        float Plr2_verticalInput = Input.GetAxis("Plr2_Vertical") * speed * Time.deltaTime;
        float Plr2_horizontalInput = Input.GetAxis("Plr2_Horizontal") * rotationSpeed * Time.deltaTime;

        Plr1.Translate(0, 0, Plr1_verticalInput);
        Plr2.Translate(0, 0, Plr2_verticalInput);

        Plr1.Rotate(0, Plr1_horizontalInput, 0);
        Plr2.Rotate(0, Plr2_horizontalInput, 0);

        float x = 0;

        if (Input.GetKey(KeyCode.Comma))
        {
            Plr1_turret.RotateAround(Plr1_turret.position, Plr1_turret.right, -turret_rot);
        }
        else if (Input.GetKey(KeyCode.Period))
        {
            Plr1_turret.RotateAround(Plr1_turret.position, Plr1_turret.right, turret_rot);
        }
        else if (Input.GetKeyDown(KeyCode.Slash))
        {
            Instantiate(Shell, Plr1_shoot.position, Plr1_shoot.rotation);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            Plr2_turret.RotateAround(Plr2_turret.position, Plr2_turret.right, -turret_rot);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            Plr2_turret.RotateAround(Plr2_turret.position, Plr2_turret.right, turret_rot);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Shell, Plr2_shoot.position, Plr2_shoot.rotation);
        }
    }
}
