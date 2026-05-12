using UnityEngine;

[System.Serializable]
public struct ProgresoJuego 
{
 public int vidas; 
 public Vector3 posicion;
 public LucesManager.Zona ultimoCP;//Quizas borrar
 public LucesManager.Zona zonaAnterior;
}
