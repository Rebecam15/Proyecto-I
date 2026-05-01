using UnityEngine;

[CreateAssetMenu(fileName = "Configuración Cangrejo", menuName = "NPC/Datos del Cangrejo")]
public class ConfCangrejo : ScriptableObject
{
    public float velocidad = 3f;
    public float tiempoParaCambiar = 2f;
    public Color colorNPC = Color.white;
}
