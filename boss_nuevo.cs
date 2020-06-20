using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class boss_nuevo : MonoBehaviour {
	public float maxhealth=10;
	float enemyhp=10;
	public Image hpbar;
	// Use this for initialization
	[HideInInspector]
	public int activo=0;

	public Renderer enemy_renderer;
	public GameObject die_efect;
	public zion_fire_bullet_script shoterbolas;
	public zion_fire_bullet_script shoterbolasboss;
	public C_disparar_ondasbalas shoterbolascirculares;

	public bool isboss=false;

	public Animator bossanim;
	public Animator bossanim2;
	public C_sonidos_player sonidocontrol;

	public bool dropitem = true;
	public my_item_poolscript pooleritems;
	public GameObject poolitemobj;
	public bool newbosstype = false;

	public Animator animpuertas1;
	public Animator animpuertas2;
	public bool bossdead = false;

	public C_enemyboss_handler gfacehandler;
	public GameObject bossvisulefect;
	public int bossindex=0;
	void Start () {		
		enemyhp = maxhealth;

		if(dropitem==true){
			poolitemobj = GameObject.Find ("poolitems");
			if(poolitemobj!=null){
				pooleritems = poolitemobj.GetComponent<my_item_poolscript>();
			}
		}
	}
	public void activarboss(){
		
		bossanim.enabled=true; 
		bossanim2.Play("stand"); 

		this.gameObject.layer=12;
		if(shoterbolas!=null){
			shoterbolas.shoter=1; 
		}
		if(shoterbolasboss!=null){
			shoterbolasboss.shoter=1; 
		}
		if(shoterbolascirculares!=null){
			shoterbolascirculares.shoter = 1; 
		}
	}
	public void jefedetectado(){
		activo = 1;
		sonidocontrol.music.Stop();
		sonidocontrol.bossmusic.Play();
		bossanim2.enabled = true; 
		sonidocontrol.dialogosnivel.bossdialogostart();

		if(animpuertas1!=null){
			animpuertas1.SetTrigger("close");
		}
		if(animpuertas2!=null){
			animpuertas2.SetTrigger("close");
		}

	}
	void OnTriggerEnter2D(Collider2D collider){
		if(game_control.control.stopreactions==1){
			return;
		}
		if (game_control.control.pausedgame == 1) {
			return;
		}
		if(activo==0){
			return;
		}
		if (collider.tag == "bala_azul" ) {

			if (isboss == true) {
				enemyhp -= 15;
				hpbar.fillAmount = enemyhp * 0.001f;
				bossanim2.Play ("hited", 0);  
				bossanim.SetTrigger("moveaway"); 
			} else {
				enemyhp -= 5;
			}

			if(enemyhp <= 0){
				activo = 0; 

				enemy_renderer.enabled = false; 
				if(shoterbolas!=null){
					shoterbolas.shoter=0; 
				}
				die_efect.SetActive(true); 

				if(pooleritems!=null){
					GameObject obj=pooleritems.GetPooledObjet();
					if (obj != null) {
						obj.transform.position = this.transform.position;
						obj.SetActive(true);	
					}
				}
				bossdeadbehaviour ();
				this.gameObject.layer=14;
			}
		}
		if (collider.tag == "darksword" ) {

			if (isboss == true) {
				enemyhp -= 25;
				hpbar.fillAmount = enemyhp * 0.001f;
				bossanim2.Play ("hited", 0);  
				bossanim.SetTrigger("moveaway"); 
			} else {
				enemyhp -= enemyhp;
			}

			if(enemyhp <= 0){
				activo = 0; 

				enemy_renderer.enabled = false; 
				if(shoterbolas!=null){
					shoterbolas.shoter=0; 
				}
				die_efect.SetActive(true); 

				if(pooleritems!=null){
					GameObject obj=pooleritems.GetPooledObjet();
					if (obj != null) {
						obj.transform.position = this.transform.position;
						obj.SetActive(true);	
					}
				}
				bossdeadbehaviour ();
				this.gameObject.layer=14;
			}
		}
		if (collider.tag == "holysword" ) {

			if (isboss == true) {
				enemyhp -= 30;
				hpbar.fillAmount = enemyhp * 0.001f;
				bossanim2.Play ("hited", 0);  
				bossanim.SetTrigger("moveaway"); 
			} else {
				enemyhp -= enemyhp;
			}

			if(enemyhp <= 0){
				activo = 0; 

				enemy_renderer.enabled = false; 
				if(shoterbolas!=null){
					shoterbolas.shoter=0; 
				}
				die_efect.SetActive(true); 

				if(pooleritems!=null){
					GameObject obj=pooleritems.GetPooledObjet();
					if (obj != null) {
						obj.transform.position = this.transform.position;
						obj.SetActive(true);	
					}
				}
				bossdeadbehaviour ();
				this.gameObject.layer=14;
			}
		}

	}
	void bossdeadbehaviour(){
		bossdead = true;
		bossanim.enabled=false; 
		bossanim2.Play("die"); 
		gfacehandler.enabled = false; 
		bossvisulefect.SetActive (false); 
		if(shoterbolasboss!=null){
			shoterbolasboss.shoter=0; 
		}
		if(shoterbolascirculares!=null){
			shoterbolascirculares.shoter = 0; 
		}

		if (game_control.control.isbossrush == 1) {
			game_control.control.bosrushactual++;
			game_control.control.health = 100;
			game_control.control.energy = 100;
			if (game_control.control.bosrushactual < game_control.control.bossrushscenes.dialogos.Length) {
				game_control.control.change_levelsecure (game_control.control.bossrushscenes.dialogos [game_control.control.bosrushactual]);
			} else {
				game_control.control.bossrushcelared = 1;
				game_control.control.save_Espsetup(); 
				game_control.control.Save_playerdata();
				game_control.control.change_levelsecure("gd_mapa_completo");
			}

		} else {
			game_control.control.catalogo_calabozos [bossindex].bosskilled = 1;    


			if(animpuertas1!=null){
				animpuertas1.SetTrigger("open");
			}
			if(animpuertas2!=null){
				animpuertas2.SetTrigger("open");
			}
			//opendoors and invoqueorb

		}

	}
	IEnumerator ChangeLevel(string scene){
		float fadeTime= GameObject.Find("game control").GetComponent<Fading>().BeginFade(1);
		yield return new WaitForSeconds(fadeTime);
		Application.LoadLevel(scene);

	}
	public void damegbyomega(){
		if(activo ==0){
			return;
		}
		if (isboss == true) {
			enemyhp -= 300;
			hpbar.fillAmount = enemyhp * 0.001f;
			bossanim2.Play ("hited", 0);  
			bossanim.SetTrigger("moveaway"); 
		} else {
			enemyhp -= enemyhp;
		}

		if(enemyhp <= 0){
			activo = 0; 

			enemy_renderer.enabled = false; 
			if(shoterbolas!=null){
				shoterbolas.shoter=0; 
			}
			die_efect.SetActive(true); 

			if(pooleritems!=null){
				GameObject obj=pooleritems.GetPooledObjet();
				if (obj != null) {
					obj.transform.position = this.transform.position;
					obj.SetActive(true);	
				}
			}
			bossdeadbehaviour ();
			this.gameObject.layer=14;
		}
	}
}
