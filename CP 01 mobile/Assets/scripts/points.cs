using UnityEngine;
using UnityEngine.UI;

public class points : MonoBehaviour
{
    public static int pontos;
    public Text numeros;
    void Start()
    {
        pontos = 0;
    }

    
    void Update()
    {
        numeros.text = pontos.ToString();
    }
}
