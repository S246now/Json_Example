using System.IO;
using UnityEngine;
using UnityEngine.UI;
 
public class ReadWriteSystem : MonoBehaviour
{
    public InputField campoNombre;//nombreJugador
    public InputField campoVida;//vidas disponibles
    public InputField campoPuntaje;//puntaje obtenido
    private const string fileName = "file.data";
 
    public void SaveToJson()
    {
        dataPractice data = new dataPractice();
        data.nombre = campoNombre.text;
        data.vida = campoVida.text;
        data.puntaje = campoPuntaje.text;
 
        string json = JsonUtility.ToJson(data);
        string path = Path.Combine(Application.persistentDataPath, fileName);
        File.WriteAllText(path, json);
    }
 
    public void LoadFromJson()
    {
        string path = Path.Combine(Application.persistentDataPath, fileName);
        string json = File.ReadAllText(path);
        dataPractice data = JsonUtility.FromJson<dataPractice>(json);
 
        campoNombre.text = data.nombre;
        campoVida.text = data.vida;
        campoPuntaje.text = data.puntaje;
    }
}