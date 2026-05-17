using UnityEngine;

[CreateAssetMenu(fileName = "Configuración Plataformas", menuName = "Plataforma/Datos de la Plataforma")]
public class ConfPlataformas : ScriptableObject
{
    public float velocidad = 3f;
    public float tiempoParaCambiar = 2f;
    public TipoMovimiento tipoMovimiento;
}
