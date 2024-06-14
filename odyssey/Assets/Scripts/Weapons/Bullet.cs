using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] public float speed = 10f;
    [SerializeField] private bool clampToScreen;
    public bool active { get; set; }

    void Update()
    {
        //transform.Translate(Vector3.forward * speed * Time.deltaTime); Esta linea no funciona, la bala no se mueve
        transform.position += transform.up * speed * Time.deltaTime;
        if (IsOutOfScreen())
        {
            // Desactiva la bala
            gameObject.SetActive(false);
            
        }

    }
    private bool IsOutOfScreen()
    {
        // Convierte la posición de la bala a coordenadas de la pantalla
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);

        // Verifica si la bala está fuera de los límites de la pantalla
        return screenPosition.y > Screen.height || screenPosition.y < 0 || screenPosition.x > Screen.width || screenPosition.x < 0;
    }


}
