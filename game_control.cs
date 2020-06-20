using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public class game_control : MonoBehaviour {
	//referencia estatica de la clase para gestionar desde otros scripts
	public static game_control control;
	//mis variables
	public int puntos=0;
	public string juego;
	public string savefile;

	public float health=100;
	public float energy=100;

	//permite probar el juego desde cuaquier punto de la aplicacion

	//varaibles de sustentacion de nivel
	public int nivel_actual=0;
	public int area_actual=0;
	public int checkpoint_actual=0;
	public int vidas=5;


	//suport to misions, items inventory and skills unlicking save data

	public Dictionary <int ,mision_data > catalogo_misiones=new Dictionary<int,mision_data>();
	public Dictionary <int ,inventario_data > catalogo_inventario=new Dictionary<int,inventario_data>();
	public Dictionary <string ,skills_data > catalogo_skills=new Dictionary<string,skills_data>();
	public Dictionary <int ,mision_data_clearence > catalogo_calabozos=new Dictionary<int,mision_data_clearence>();


    public Dictionary<int, mision_orbes_data> catalogo_orbes_misiones= new Dictionary<int, mision_orbes_data>();


    public bool dialogo_inicialoido=false;
	public bool dialogo_bossoido=false;

	public int stopreactions = 1;
	public int pausedgame = 0;

	public int is_changing_scene=1;
	public int poisoned=0;
	public float temperature = 100;
	public int frozen=0;
	public int cursed = 0;
	public int warping = 0;
	public int luck=1;
	public int venominmune=0;
	public string cinematico1="";
	public string cinematico2="";
	public string idioma ="Esp";//Esp,Eng

	public int currentarmor=0;
	public int currentespecial=0;
	public int armorunlocked=0;
	public int espunlocked=0;

	public List <int> notificaciones=new List<int>();

	public int historiainicialoida=0;
	public int languageselected = 0;
	public int currentmodel=0;
	public int isbossrush=0;
	public int bosrushactual=0;
	public historia_sc bossrushscenes;
	public int bossrushcelared=0;
	public int gamecleared=0;


	public int puertafacedir=1;
	public int savepoint = 0;

	public string saveroome_xitscene = "";
	public int saveroom_exit=0;
	public int darkheist=0;


	public int base_nivel = 1;
	public int experience = 0;
	public int skillpoints=0;
	public int fuerza = 1;
	public int speed = 1;
	public int defensa = 1;
	public int autocura = 0;
	public int autopotion = 0;
    public int enhanced = 0;

    //resetfeature
    public bool clearfile(string _clearfile) {
        Dictionary<int, mision_data> _catalogo_misiones = new Dictionary<int, mision_data>();
        Dictionary<int, inventario_data> _catalogo_inventario = new Dictionary<int, inventario_data>();
        Dictionary<string, skills_data> _catalogo_skills = new Dictionary<string, skills_data>();
        Dictionary<int, mision_data_clearence> _catalogo_calabozos = new Dictionary<int, mision_data_clearence>();
        Dictionary<int, mision_orbes_data> _catalogo_orbes_misiones = new Dictionary<int, mision_orbes_data>();

        _catalogo_misiones.Add(0, resret_addmision(1));
        _catalogo_misiones.Add(1, resret_addmision(0));
        _catalogo_misiones.Add(2, resret_addmision(0));
        _catalogo_misiones.Add(3, resret_addmision(0));
        _catalogo_misiones.Add(4, resret_addmision(0));
        _catalogo_misiones.Add(5, resret_addmision(0));
        _catalogo_misiones.Add(6, resret_addmision(0));
        _catalogo_misiones.Add(7, resret_addmision(0));
        _catalogo_misiones.Add(8, resret_addmision(0));

        _catalogo_inventario.Add(0, reset_additem(1,100));
        _catalogo_inventario.Add(1, reset_additem(1,300));
        _catalogo_inventario.Add(2, reset_additem(1,50));
        _catalogo_inventario.Add(3, reset_additem(1,100));
        _catalogo_inventario.Add(4, reset_additem(1,500));
        _catalogo_inventario.Add(5, reset_additem(1,1000));
        _catalogo_inventario.Add(6, reset_additem(1,50));
        _catalogo_inventario.Add(7, reset_additem(1,50));
        _catalogo_inventario.Add(8, reset_additem(1,2000));
        _catalogo_inventario.Add(9, reset_additem(1,2000));

        _catalogo_orbes_misiones.Add(0, resetmsionorebsdata());
        _catalogo_orbes_misiones.Add(1, resetmsionorebsdata());
        _catalogo_orbes_misiones.Add(2, resetmsionorebsdata());
        _catalogo_orbes_misiones.Add(3, resetmsionorebsdata());
        _catalogo_orbes_misiones.Add(4, resetmsionorebsdata());

        _catalogo_inventario[0].inventario = 3;
        _catalogo_inventario[1].inventario = 1;
        _catalogo_inventario[2].inventario = 3;

        _catalogo_inventario[0].unlocked = 1;
        _catalogo_inventario[2].unlocked = 1;
        _catalogo_inventario[3].unlocked = 1;
        _catalogo_inventario[4].unlocked = 1;
        _catalogo_inventario[5].unlocked = 0;
        _catalogo_inventario[6].unlocked = 0;
        _catalogo_inventario[7].unlocked = 0;
        _catalogo_inventario[8].unlocked = 0;
        _catalogo_inventario[9].unlocked = 0;


        languageselected = 0;
        Reset_playerdata(_catalogo_misiones, _catalogo_inventario,_catalogo_orbes_misiones, _clearfile);
        return true;
    }
    mision_data resret_addmision(int unlock)
    {
        mision_data misionnew = new mision_data();
        misionnew.unlocked = unlock;
        

        return misionnew;
    }
    inventario_data reset_additem( int unlock, int _price)
    {
        inventario_data itemnew = new inventario_data();
        itemnew.unlocked = unlock;
        itemnew.price = _price;
        return itemnew;
    }
    mision_orbes_data resetmsionorebsdata()
    {
        mision_orbes_data itemnew = new mision_orbes_data();       
        itemnew.catalogo_orbes.Add(0,new orbes_info());
        itemnew.catalogo_orbes.Add(1, new orbes_info());
        itemnew.catalogo_orbes.Add(2, new orbes_info());
        itemnew.catalogo_orbes.Add(3, new orbes_info());
        itemnew.catalogo_orbes.Add(4, new orbes_info());
        itemnew.catalogo_orbes.Add(5, new orbes_info());
        itemnew.catalogo_orbes.Add(6, new orbes_info());
        itemnew.catalogo_orbes.Add(7, new orbes_info());

        itemnew.black_catalogo_orbes.Add(0, new orbes_info());
        itemnew.black_catalogo_orbes.Add(1, new orbes_info());
        itemnew.black_catalogo_orbes.Add(2, new orbes_info());

        


        return itemnew;
    }
    public void reset_dictionary_data()
    {
        Dictionary<int, mision_data> _catalogo_misiones = new Dictionary<int, mision_data>();
        Dictionary<int, inventario_data> _catalogo_inventario = new Dictionary<int, inventario_data>();
        Dictionary<int, mision_orbes_data> _catalogo_orbes_misiones = new Dictionary<int, mision_orbes_data>();

        //Dictionary<string, skills_data> _catalogo_skills = new Dictionary<string, skills_data>();
        //Dictionary<int, mision_data_clearence> _catalogo_calabozos = new Dictionary<int, mision_data_clearence>();

        _catalogo_misiones.Add(0, resret_addmision(1));
        _catalogo_misiones.Add(1, resret_addmision(0));
        _catalogo_misiones.Add(2, resret_addmision(0));
        _catalogo_misiones.Add(3, resret_addmision(0));
        _catalogo_misiones.Add(4, resret_addmision(0));
        _catalogo_misiones.Add(5, resret_addmision(0));
        _catalogo_misiones.Add(6, resret_addmision(0));
        _catalogo_misiones.Add(7, resret_addmision(0));
        _catalogo_misiones.Add(8, resret_addmision(0));

        _catalogo_inventario.Add(0, reset_additem(1, 100));
        _catalogo_inventario.Add(1, reset_additem(1, 300));
        _catalogo_inventario.Add(2, reset_additem(1, 50));
        _catalogo_inventario.Add(3, reset_additem(1, 100));
        _catalogo_inventario.Add(4, reset_additem(1, 500));
        _catalogo_inventario.Add(5, reset_additem(1, 1000));
        _catalogo_inventario.Add(6, reset_additem(1, 50));
        _catalogo_inventario.Add(7, reset_additem(1, 50));
        _catalogo_inventario.Add(8, reset_additem(1, 2000));
        _catalogo_inventario.Add(9, reset_additem(1, 2000));

        _catalogo_orbes_misiones.Add(0, resetmsionorebsdata());
        _catalogo_orbes_misiones.Add(1, resetmsionorebsdata());
        _catalogo_orbes_misiones.Add(2, resetmsionorebsdata());
        _catalogo_orbes_misiones.Add(3, resetmsionorebsdata());
        _catalogo_orbes_misiones.Add(4, resetmsionorebsdata());

        _catalogo_inventario[0].inventario = 3;
        _catalogo_inventario[1].inventario = 1;
        _catalogo_inventario[2].inventario = 3;

        _catalogo_inventario[0].unlocked = 1;
        _catalogo_inventario[2].unlocked = 1;
        _catalogo_inventario[3].unlocked = 1;
        _catalogo_inventario[4].unlocked = 1;
        _catalogo_inventario[5].unlocked = 0;
        _catalogo_inventario[6].unlocked = 0;
        _catalogo_inventario[7].unlocked = 0;
        _catalogo_inventario[8].unlocked = 0;
        _catalogo_inventario[9].unlocked = 0;

        catalogo_misiones = _catalogo_misiones;
        catalogo_inventario = _catalogo_inventario;
        catalogo_orbes_misiones = _catalogo_orbes_misiones;
    }
    public void Reset_playerdata(Dictionary<int, mision_data> _catalogo_misiones, Dictionary<int, inventario_data> _catalogo_inventario, Dictionary<int, mision_orbes_data> _catalogo_orbes_misiones, string _savefile)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/" + juego + _savefile + "094.dat");
        PlayerData data = new PlayerData();

        data.puntos = puntos;

        data.currentarmor = 0;
        data.currentespecial = 0;
        data.armorunlocked = 0;
        data.espunlocked = 0;

        data.historiainicialoida = 0;

        data.catalogo_misiones = _catalogo_misiones;
        data.catalogo_inventario = _catalogo_inventario;
        data.catalogo_skills = catalogo_skills;


        bf.Serialize(file, data);
        file.Close();
        Debug.Log("datos player guardadas");

        BinaryFormatter bf2 = new BinaryFormatter();
        FileStream file2 = File.Create(Application.persistentDataPath + "/" + juego + _savefile + "especialdata.dat");
        EspData data2 = new EspData();

        data2.bossrushcelared = 0;
        data2.gamecleared = 0;

        bf2.Serialize(file2, data2);
        file2.Close();
        Debug.Log("datos especial guardadas");

        BinaryFormatter bf3 = new BinaryFormatter();
        FileStream file3 = File.Create(Application.persistentDataPath + "/" + juego + _savefile + "expdata0911.dat");
        experiencedata data3 = new experiencedata();



        data3.base_nivel = 1;
        data3.experience = 0;
        data3.fuerza = 1;
        data3.speed = 1;
        data3.defensa = 1;
        data3.autocura = 0;
        data3.autopotion = 0;
        data3.skillpoints = 0;


        bf3.Serialize(file3, data3);
        file3.Close();
        Debug.Log("exp datos guardadas");

        BinaryFormatter bf4 = new BinaryFormatter();
        FileStream file4 = File.Create(Application.persistentDataPath + "/" + juego + savefile + "idiomasetup07.dat");
        IdiomaData data4 = new IdiomaData();

        data4.idioma = idioma;
        data4.languageselected = languageselected;
        bf4.Serialize(file4, data4);
        file4.Close();
        Debug.Log("datos idioma guardadas");


        BinaryFormatter bf5 = new BinaryFormatter();
        FileStream file5 = File.Create(Application.persistentDataPath + "/" + juego + savefile + "orbes03.dat");
        main_orbes_data data5 = new main_orbes_data();
        

       
        data5.catalogo_orbes_misiones = _catalogo_orbes_misiones;
        bf5.Serialize(file5, data5);
        file5.Close();
        Debug.Log("datos orbes guardadas");
    }


    //end of reset feature
    void Awake () {
		if (control == null){
			DontDestroyOnLoad(gameObject);
			control = this;

			//adding defaul data to mision catalog
			addmision(0,1);
			addmision(1,0);
			addmision(2,0);
			addmision(3,0);
			addmision(4,0);
			addmision(5,0);
			addmision(6,0);
			addmision(7,0);
			addmision(8,0);
			addmision(9,0);

			additem(0,1,100);
			additem(1,1,300);
			additem(2,1,50);
			additem(3,1,100);
			additem(4,1,500);
			additem(5,1,1000);
			additem(6,1,50);
			additem(7,1,50);
			additem(8,1,2000);
			additem(9,1,2000);
			catalogo_inventario[0].inventario = 3;
			catalogo_inventario[1].inventario = 1;
			catalogo_inventario[2].inventario = 3;

			catalogo_inventario[0].unlocked = 1;
			catalogo_inventario[2].unlocked = 1;
			catalogo_inventario[3].unlocked = 1;
			catalogo_inventario[4].unlocked = 1;
			catalogo_inventario[5].unlocked = 0;
			catalogo_inventario[6].unlocked = 0;
			catalogo_inventario[7].unlocked = 0;
			catalogo_inventario[8].unlocked = 0;
			catalogo_inventario[9].unlocked = 0;

            catalogo_orbes_misiones.Add(0, resetmsionorebsdata());
            catalogo_orbes_misiones.Add(1, resetmsionorebsdata());
            catalogo_orbes_misiones.Add(2, resetmsionorebsdata());
            catalogo_orbes_misiones.Add(3, resetmsionorebsdata());
            catalogo_orbes_misiones.Add(4, resetmsionorebsdata());


            idioma ="Esp";

			addmisioncalabozo(0,1);

			Load_playerdata();
			load_idiomasetup(); 
			load_Espsetup();
			load_calabozodata();
			load_expdata();
            load_orbesdata();
        }
		else if(control!=this){
			Destroy(gameObject);
		}
	}	
	void Start(){
		


	}
	void addmisioncalabozo(int index,int unlock){
		mision_data_clearence misionnew=new mision_data_clearence();

		catalogo_calabozos.Add(index,misionnew);  


	}
	void addmision(int index,int unlock){
		mision_data misionnew=new mision_data();
		misionnew.unlocked=unlock;
		catalogo_misiones.Add(index,misionnew);  

		
	}
	void additem(int index,int unlock,int _price){
		inventario_data itemnew=new inventario_data();
		itemnew.unlocked=unlock;
		itemnew.price=_price;
		catalogo_inventario.Add(index,itemnew);
	}
	void addskill(string _nombre,string _desc,int unlock,int _price){
		skills_data skillnew=new skills_data();
		skillnew.unlocked=unlock;
		skillnew.nombre=_nombre;
		skillnew.desc=_desc;
		skillnew.price=_price;
		catalogo_skills.Add(_nombre,skillnew);  


	}
	public void Load_playerdata (){
		if (File.Exists(Application.persistentDataPath+"/"+juego+savefile+"094.dat")){
			BinaryFormatter bf = new BinaryFormatter();
			FileStream my_file = File.Open(Application.persistentDataPath+"/"+juego+savefile+"094.dat",FileMode.Open);
			PlayerData  my_data= (PlayerData)bf.Deserialize(my_file);
			
			puntos=my_data.puntos;

			currentarmor=my_data.currentarmor;
			currentespecial=my_data.currentespecial;
			armorunlocked=my_data.armorunlocked;
			espunlocked=my_data.espunlocked;
			historiainicialoida=my_data.historiainicialoida;

			catalogo_misiones = my_data.catalogo_misiones;
			catalogo_inventario = my_data.catalogo_inventario;
			catalogo_skills = my_data.catalogo_skills;



			my_file.Close();
			Debug.Log("datos player cargadas");

            
        }
		else{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Create(Application.persistentDataPath+"/"+juego+savefile+"094.dat");
			PlayerData data = new PlayerData();
			
			data.puntos=puntos;
			data.currentarmor=currentarmor;
			data.currentespecial=currentespecial;
			data.armorunlocked=armorunlocked;
			data.espunlocked=espunlocked;
			data.historiainicialoida=historiainicialoida;

			data.catalogo_misiones=catalogo_misiones;

			data.catalogo_inventario =catalogo_inventario ;
			data.catalogo_skills =catalogo_skills ;

			bf.Serialize(file,data);
			file.Close();
			Debug.Log("datos player guardadas"); 
		}
	}
	public void Save_playerdata (){
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath+"/"+juego+savefile+"094.dat");
		PlayerData data = new PlayerData();
		
		data.puntos=puntos;

		data.currentarmor=currentarmor;
		data.currentespecial=currentespecial;
		data.armorunlocked=armorunlocked;
		data.espunlocked=espunlocked;

		data.historiainicialoida=historiainicialoida;

		data.catalogo_misiones=catalogo_misiones;
		data.catalogo_inventario =catalogo_inventario ;
		data.catalogo_skills =catalogo_skills ;


		bf.Serialize(file,data);
		file.Close();
		Debug.Log("datos player guardadas"); 

	}
	public void save_idiomasetup(){
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath+"/"+juego+savefile+"idiomasetup07.dat");
		IdiomaData data = new IdiomaData();

		data.idioma = idioma;
		data.languageselected = languageselected;
		bf.Serialize(file,data);
		file.Close();
		Debug.Log("datos idioma guardadas"); 
	}
	public void load_idiomasetup(){
		if (File.Exists(Application.persistentDataPath+"/"+juego+savefile+"idiomasetup07.dat")){
			BinaryFormatter bf = new BinaryFormatter();
			FileStream my_file = File.Open(Application.persistentDataPath+"/"+juego+savefile+"idiomasetup07.dat",FileMode.Open);
			IdiomaData  my_data= (IdiomaData)bf.Deserialize(my_file);


			idioma = my_data.idioma; 
			languageselected =my_data.languageselected;


			my_file.Close();
			Debug.Log("datos idioma cargadas"); 
		}
		else{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Create(Application.persistentDataPath+"/"+juego+savefile+"idiomasetup07.dat");
			IdiomaData data = new IdiomaData();

			data.idioma = idioma; 
			data.languageselected = languageselected;
			bf.Serialize(file,data);
			file.Close();
			Debug.Log("datos idioma guardadas"); 
		}
	}
	//especialdata
	public void save_Espsetup(){
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath+"/"+juego+savefile+"especialdata.dat");
		EspData data = new EspData();

		data.bossrushcelared = bossrushcelared;
		data.gamecleared = gamecleared; 

		bf.Serialize(file,data);
		file.Close();
		Debug.Log("datos especial guardadas"); 
	}
	public void load_Espsetup(){
		if (File.Exists(Application.persistentDataPath+"/"+juego+savefile+"especialdata.dat")){
			BinaryFormatter bf = new BinaryFormatter();
			FileStream my_file = File.Open(Application.persistentDataPath+"/"+juego+savefile+"especialdata.dat",FileMode.Open);
			EspData  my_data= (EspData)bf.Deserialize(my_file);


			bossrushcelared = my_data.bossrushcelared; 
			gamecleared = my_data.gamecleared;


			my_file.Close();
			Debug.Log("datos especial cargadas");

            if (control.bossrushcelared == 1)
            {
                
                control.armorunlocked = 5;
            }
        }
		else{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Create(Application.persistentDataPath+"/"+juego+savefile+"especialdata.dat");
			EspData data = new EspData();

			data.bossrushcelared = bossrushcelared; 
			data.gamecleared = gamecleared; 

			bf.Serialize(file,data);
			file.Close();
			Debug.Log("datos especial guardadas"); 
		}
	}
	//scene manegment
	public void change_levelsecure(string scenename){
		if(is_changing_scene==1){
			return;
		}
		is_changing_scene = 1;
		stopreactions = 1; 
		Time.timeScale = 1;  
		StartCoroutine(ChangeLevel(scenename)); 
	}
	IEnumerator ChangeLevel(string scene){
		float fadeTime= GameObject.Find("game control").GetComponent<Fading>().BeginFade(1);
		yield return new WaitForSeconds(fadeTime);
		Application.LoadLevel(scene);

	}
	//newmisions
	public void save_calabozaodata(){
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath+"/"+juego+savefile+"newmisions091.dat");
		calabozodata data = new calabozodata();


		data.catalogo_calabozos  = catalogo_calabozos;
		data.savepoint = savepoint;  
		data.saveroome_xitscene = saveroome_xitscene; 
		data.saveroom_exit = saveroom_exit; 


		bf.Serialize(file,data);
		file.Close();
		Debug.Log("extra datos guardadas"); 
	}
	public void load_calabozodata(){
		if (File.Exists(Application.persistentDataPath+"/"+juego+savefile+"newmisions091.dat")){
			BinaryFormatter bf = new BinaryFormatter();
			FileStream my_file = File.Open(Application.persistentDataPath+"/"+juego+savefile+"newmisions091.dat",FileMode.Open);
			calabozodata  my_data= (calabozodata)bf.Deserialize(my_file);



			catalogo_calabozos =my_data.catalogo_calabozos;
			savepoint = my_data.savepoint;    
			saveroom_exit = my_data.saveroom_exit;  
			saveroome_xitscene = my_data.saveroome_xitscene;  

			my_file.Close();
			Debug.Log("extra datos cargadas"); 
		}
		else{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Create(Application.persistentDataPath+"/"+juego+savefile+"newmisions091.dat");
			calabozodata data = new calabozodata();


			data.catalogo_calabozos = catalogo_calabozos;
			data.savepoint = savepoint;

			data.saveroome_xitscene = saveroome_xitscene; 
			data.saveroom_exit = saveroom_exit; 


			bf.Serialize(file,data);
			file.Close();
			Debug.Log("extra datos guardadas"); 
		}
	}
	public void save_expdata(){
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath+"/"+juego+savefile+"expdata0911.dat");
		experiencedata data = new experiencedata();



		data.base_nivel = base_nivel;
		data.experience = experience;
		data.fuerza = fuerza; 
		data.speed = speed; 
		data.defensa = defensa; 
		data.autocura = autocura; 
		data.autopotion = autopotion; 
		data.skillpoints = skillpoints;


		bf.Serialize(file,data);
		file.Close();
		Debug.Log("exp datos guardadas"); 
	}
	public void load_expdata(){
		if (File.Exists(Application.persistentDataPath+"/"+juego+savefile+"expdata0911.dat")){
			BinaryFormatter bf = new BinaryFormatter();
			FileStream my_file = File.Open(Application.persistentDataPath+"/"+juego+savefile+"expdata0911.dat",FileMode.Open);
			experiencedata  my_data= (experiencedata)bf.Deserialize(my_file);

			base_nivel =my_data.base_nivel;
			experience = my_data.experience;
			fuerza = my_data.fuerza; 
			speed = my_data.speed; 
			defensa = my_data.defensa; 
			autocura = my_data.autocura; 
			autopotion = my_data.autopotion; 
			skillpoints = my_data.skillpoints;


			my_file.Close();
			Debug.Log("exp datos cargadas"); 
		}
		else{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Create(Application.persistentDataPath+"/"+juego+savefile+"expdata0911.dat");
			experiencedata data = new experiencedata();


			data.base_nivel = base_nivel;
			data.experience = experience;
			data.fuerza = fuerza; 
			data.speed = speed; 
			data.defensa = defensa; 
			data.autocura = autocura; 
			data.autopotion = autopotion; 
			data.skillpoints = skillpoints;



			bf.Serialize(file,data);
			file.Close();
			Debug.Log("exp datos guardadas"); 
		}
	}
    public void save_orbesdata()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/" + juego + savefile + "orbes03.dat");
        main_orbes_data data = new main_orbes_data();

        data.catalogo_orbes_misiones = catalogo_orbes_misiones;
        
        bf.Serialize(file, data);
        file.Close();
        Debug.Log("datos orbes guardadas");
    }
    public void load_orbesdata()
    {
        if (File.Exists(Application.persistentDataPath + "/" + juego + savefile + "orbes03.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream my_file = File.Open(Application.persistentDataPath + "/" + juego + savefile + "orbes03.dat", FileMode.Open);
            main_orbes_data my_data = (main_orbes_data)bf.Deserialize(my_file);


            
            catalogo_orbes_misiones = my_data.catalogo_orbes_misiones;


            my_file.Close();
            Debug.Log("datos orbes cargadas");
        }
        else
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/" + juego + savefile + "orbes03.dat");
            main_orbes_data data = new main_orbes_data();

            
            data.catalogo_orbes_misiones = catalogo_orbes_misiones;
            bf.Serialize(file, data);
            file.Close();
            Debug.Log("datos orbes guardadas");
        }
    }

}
//orbes savingsetup

[Serializable]
public class PlayerData{
	public int puntos;

	public int currentarmor;
	public int currentespecial;
	public int armorunlocked;
	public int espunlocked;
	public int historiainicialoida;
	public Dictionary <int ,mision_data > catalogo_misiones;
	public Dictionary <int ,inventario_data > catalogo_inventario;
	public Dictionary <string ,skills_data > catalogo_skills;

}
[Serializable]
public class mision_data{
	public int score;
	public int unlocked;
	public int cleared;
	public mision_data(){
		score = 0;
		unlocked = 0;
		cleared = 0;
	}
}
[Serializable]
public class inventario_data{
	
	public int inventario;
	public int unlocked;
	public int price;
	public inventario_data(){
		inventario = 0;
		unlocked = 0;
		price = 0;
	}
}
[Serializable]
public class skills_data{
	public string nombre;
	public string desc;
	public int earned;
	public int unlocked;
	public int price;
	public skills_data(){
		nombre="";
		earned = 0;
		unlocked = 0;
		price = 0;
	}
}
[Serializable]
public class IdiomaData{
	public string idioma;
	public int languageselected;


}
[Serializable]
public class EspData{
	public int bossrushcelared;
	public int gamecleared;


}
[Serializable]
public class mision_data_clearence{
	public int bosskilled;
	public mision_data_clearence(){
		bosskilled = 0; 
	}
}
[Serializable]
public class calabozodata{
	public int savepoint;
	public int saveroom_exit;
	public string saveroome_xitscene;


	public Dictionary <int ,mision_data_clearence > catalogo_calabozos;


}
[Serializable]
public class experiencedata{
	public int base_nivel;
	public int experience;
	public int fuerza;
	public int speed;
	public int defensa;
	public int autocura;
	public int autopotion;
	public int skillpoints;

}
[Serializable]
public class orbes_info
{
    public bool collected;
    public orbes_info()
    {
        collected = false;
    }

}
[Serializable]
public class mision_orbes_data
{
    public bool cleared;
    public Dictionary<int, orbes_info> catalogo_orbes;
    public Dictionary<int, orbes_info> black_catalogo_orbes;
    public mision_orbes_data()
    {
        catalogo_orbes = new Dictionary<int, orbes_info>();
        black_catalogo_orbes = new Dictionary<int, orbes_info>();
        cleared = false;
    }


}
[Serializable]
public class main_orbes_data
{
    public Dictionary<int, mision_orbes_data> catalogo_orbes_misiones;


}