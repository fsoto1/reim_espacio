using UnityEngine;


public class Minimapa : MonoBehaviour
{
    public Transform player;
    private Vector3 posicion;
    private void LateUpdate()
    {
        posicion = player.position;
        posicion.z = transform.position.z;
        transform.position = posicion;
       // transform.rotation = Quaternion.Euler(player.eulerAngles.x, 0f, 0f);
    }


}
