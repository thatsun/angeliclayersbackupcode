using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_player_bullets : MonoBehaviour {
	
	public GameObject pooled_object;
    public GameObject pooled_object2;
    public GameObject pooled_object3;
    public int pool_amount=20;
	public bool willGrow=true;

	List<GameObject> pooled_objects;
    List<c_bollet_rebote> pooled_objects_i;
    // Use this for initialization
    int counter = 0;
    public bool rebotadora=false;
    void Awake(){
		
	}
	void Start () {
		pooled_objects= new List<GameObject>();
        pooled_objects_i = new List<c_bollet_rebote>();
        for (int i =0 ; i  < pool_amount; i ++){
           
			GameObject obj = (GameObject)Instantiate(pooled_object);
            

            obj.SetActive(false);
			pooled_objects.Add(obj);
            if (rebotadora==true)
            {
                c_bollet_rebote boollet = obj.GetComponent<c_bollet_rebote>();
                pooled_objects_i.Add(boollet);

                if (counter == 0)
                {
                    pooled_objects_i[i].offset = 0.5f;
                }
                if (counter == 1)
                {
                    pooled_objects_i[i].offset = -0.5f;
                }
                if (counter == 2)
                {
                    pooled_objects_i[i].offset = -0.25f;
                }
                if (counter == 3)
                {
                    pooled_objects_i[i].offset = 0.25f;
                }
                counter++;
                if (counter == 4) counter=0 ;
            }
            
        }

    }

	// Update is called once per frame
	public GameObject GetPooledObjet(){
		for (int i =0; i< pooled_objects.Count; i++){
			if(!pooled_objects[i].activeInHierarchy){
				return pooled_objects[i];
			}
		}
		if(willGrow){
			GameObject obj = (GameObject)Instantiate(pooled_object);
			pooled_objects.Add(obj);

		}
		return null;
	}
}
