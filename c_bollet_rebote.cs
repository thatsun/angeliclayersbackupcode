using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c_bollet_rebote : MonoBehaviour {
    Rigidbody2D rb;
    Vector2 direccion;
    Vector2 reflejado_aux;
    bool pega = false;
    // Use this for initialization
    [SerializeField]
    float speed = 1.0f;
    int activa = 0;
    public Controller2D player2dcontrol;
    public Player currentplayer;
    Vector3 normaliseddirection = Vector2.zero;
    
    public float offset = 0.5f ;
    void Awake()
    {
        player2dcontrol = GameObject.Find("Player").GetComponent<Controller2D>();
        currentplayer = GameObject.Find("Player").GetComponent<Player>();
    }
    public void OnEnable()
    {
        if (currentplayer.wallSliding == true)
        {
            if (player2dcontrol.collisions.faceDir == 1)
            {
                normaliseddirection.x = -1;
            }
            else
            {
                normaliseddirection.x = 1;
            }

        }
        else
        {
            if (player2dcontrol.collisions.faceDir == 1)
            {
                normaliseddirection.x = 1;
            }
            else
            {
                normaliseddirection.x = -1;
            }
        }
        normaliseddirection.y = offset;
        normaliseddirection = normaliseddirection.normalized;

        direccion.x = normaliseddirection.x;
        direccion.y = normaliseddirection.y;
        pega = false;
        activa = 1;
        
        Invoke("disablebullet", 5.0f);

    }
    void disablebullet()
    {
        activa = 0;
        this.gameObject.SetActive(false);
    }    
    void Update()
    {

        //Almacenamos la velocidad que lleva antes de la colision
        
        if (game_control.control.pausedgame == 1)
        {
            return;
        }
        if (game_control.control.stopreactions == 1)
        {
            activa = 0;
            CancelInvoke();
            this.gameObject.SetActive(false);
            return;
        }

        transform.position += normaliseddirection * speed * Time.deltaTime;
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        
       
        //coll.contacts nos devuelve una matriz con los contactos de la colision
        if (coll.contacts.Length>0)
        {
            pega = true;
            Vector2 reflejado = Vector2.Reflect(direccion, coll.contacts[0].normal);

            direccion = reflejado;
            normaliseddirection.x = reflejado.x;
            normaliseddirection.y = reflejado.y;
        }
       
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (game_control.control.pausedgame == 1)
        {
            return;
        }
        if (game_control.control.stopreactions == 1)
        {
            return;
        }
        if (activa == 0)
        {
            return;
        }
        
        
    }
    void OnCollisionExit2D(Collision2D coll)
    {
            pega = false;
    }
}
