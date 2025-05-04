using UnityEngine;
using System.Threading.Tasks;

public class ControllerMover : MonoBehaviour
{
    public MoverQ1 q1;
    public MoverQ2 q2;
    public async void Move1()
    {
        q2.shouldMove = false;
        await Esperar();
        q1.shouldMove = false;
    }
    public async void Move2()
    {
        q1.shouldMove = false;
        await Esperar();
        q2.shouldMove = true;
        
    }
    private async Task Esperar()
    {
        await Task.Delay(200); // Espera 2 segundos
    }
}
