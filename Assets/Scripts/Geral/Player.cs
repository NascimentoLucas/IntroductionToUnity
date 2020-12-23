using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";

    [Header("Debug")]
    [SerializeField]
    private Vector3 forward;
    private Vector3 right;

    [Header("GD")]
    [SerializeField]
    private float speed = 0.1f;
    private float oldPosX;

    //https://satellasoft.com/artigo/unity-3d/rotacionando-camera-com-mouse-na-unity-3d
    private bool travarMouse = true; //Controla se o cursor do mouse é exibido
    private float sensibilidade = 2.0f; //Controla a sensibilidade do mouse
    private float mouseX = 0.0f;
    private float mouseY = 0.0f; //Variáveis que controla a rotação do mouse

    private void Start()
    {
        forward = Vector3.zero;

        //Cursor.visible = false; //Oculta o cursor do mouse
    }

    void Update()
    {
        mouseX += Input.GetAxis("Mouse X") * sensibilidade; // Incrementa o valor do eixo X e multiplica pela sensibilidade
        mouseY -= Input.GetAxis("Mouse Y") * sensibilidade; // Incrementa o valor do eixo Y e multiplica pela sensibilidade. (Obs. usamos o - para inverter os valores)

        if (Input.GetMouseButton(1))
        {
            Cursor.lockState = CursorLockMode.Locked; //Trava o cursor do centro
            Camera.main.transform.eulerAngles = new Vector3(mouseY, mouseX, 0); //Executa a rotação da câmera de acordo com os eixos 
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
        forward = Camera.main.transform.forward;
        right = Camera.main.transform.right;

        forward *= Input.GetAxisRaw(Vertical);
        right *= Input.GetAxisRaw(Horizontal);

        forward.y = 0;
        right.y = 0;
        transform.position += (forward + right) * speed;
    }

    private void OnGUI()
    {
        GUILayout.Label(forward.ToString());
    }
}
