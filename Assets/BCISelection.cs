using Gtec.Chain.Common.Templates.Utilities;
using Gtec.UnityInterface;
using UnityEngine;
using System.Net.Sockets;
using System.Text;

public class BCISelection : MonoBehaviour
{
    // Change this to your PC's local IP address
    private string serverIP = "172.20.10.8";
    private int serverPort = 5005;

    public void OnClassificationSelection(ERPPipeline erpPipeline, ClassSelection classSelection)
    {
        int selectedClass = classSelection.Class;
        UnityEngine.Debug.Log("Selected class: " + selectedClass);
        SendToServer(selectedClass.ToString());
    }

    public void SimulateSelection(int classId)
    {
        UnityEngine.Debug.Log("Simulated: " + classId);
        SendToServer(classId.ToString());
    }

    private void SendToServer(string message)
    {
        try
        {
            TcpClient client = new TcpClient(serverIP, serverPort);
            NetworkStream stream = client.GetStream();
            byte[] data = Encoding.UTF8.GetBytes(message);
            stream.Write(data, 0, data.Length);
            stream.Close();
            client.Close();
            UnityEngine.Debug.Log("Sent to server: " + message);
        }
        catch (System.Exception e)
        {
            UnityEngine.Debug.LogError("Failed to send: " + e.Message);
        }
    }
}