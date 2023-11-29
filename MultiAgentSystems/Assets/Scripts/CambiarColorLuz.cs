using UnityEngine;

public class CambiarColorLuz : MonoBehaviour
{
    
    public Light[] Alight; // Arreglo para almacenar las referencias a las luces verdes
    public Light[] Bligt; // Arreglo para almacenar las referencias a las luces rojas

    string Acolor = "green";
    string Bcolor = "red"; 

    // Método para cambiar el color de un grupo de luces
    public void CambiarColorGrupo(Light[] grupoLuces, Color nuevoColor)
    {
        foreach (Light luz in grupoLuces)
        {
            luz.color = nuevoColor; // Asignar el nuevo color a cada luz en el arreglo
        }
    }

    // Ejemplo de cómo llamar al método para cambiar el color desde otro script
    private void Update()
    {
        if (Acolor == "green")
        {
            CambiarColorGrupo(Alight, Color.green); 
        }else{
            CambiarColorGrupo(Alight, Color.red);
        }

        if (Bcolor == "red")
        {
            CambiarColorGrupo(Bligt, Color.red); // Cambiar a color rojo al presionar la tecla R
        }else{
           CambiarColorGrupo(Bligt, Color.green); 
        }
    }
}





