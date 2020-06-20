using UnityEngine;

public class c_flameloop : MonoBehaviour {
    public ParticleSystem flames;
    // Use this for initialization
    public float starttime=5.0f;
    public float frecuence = 5.0f;
    public int activo = 0;
    public GameObject particleobject;
    
	void fireflames () {
        if (activo ==0)
        {
            
            return;
        }
        flames.Play();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "activador" & activo == 0)
        {
            activo = 1;
            particleobject.SetActive(true);
            InvokeRepeating("fireflames", starttime, frecuence); 
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        
        if (collider.tag == "activador" & activo == 1 )
        {
            activo = 0;
            CancelInvoke();
            particleobject.SetActive(false);

        }
    }
}
