using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class C_damagenenmy : MonoBehaviour {
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
	public C_damagenenmy referencethis;
	public bool dropitem = true;
	public my_item_poolscript pooleritems;
	public GameObject poolitemobj;
	public bool newbosstype = false;

	public Animator animpuertas1;
	public Animator animpuertas2;
	public bool bossdead = false;

    public Animator hitanim;
	void Start () {		
		enemyhp = maxhealth;

		if(dropitem==true){
			poolitemobj = GameObject.Find ("poolitems");
			if(poolitemobj!=null){
				pooleritems = poolitemobj.GetComponent<my_item_poolscript>();
			}
		}
	}	
	// Update is called once per frame
	void OnTriggerExit2D(Collider2D collider){
		if (isboss == true) {
			return;
		}
		if (collider.tag == "activador" & activo == 1 & enemyhp != 0) {
			activo = 0; 
			enemy_renderer.enabled = false; 
			shoterbolas.shoter = 0; 
			this.gameObject.layer=14;  

		}
	}
	public void activarboss(){
		bossanim.enabled=true; 
		bossanim2.Play("stand"); 


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
	void OnTriggerEnter2D(Collider2D collider){
		if (bossdead==true) {
			return;
		}
		if (collider.tag == "activador" & activo == 0 & enemyhp != 0) {
			
			activo = 1;
			enemy_renderer.enabled = true;

			this.gameObject.layer=12;
			if (isboss == true ) {
				


				sonidocontrol.music.Stop();
				sonidocontrol.bossmusic.Play();  
				sonidocontrol.dialogosnivel.bossreference = referencethis; 
				bossanim2.enabled = true; 
				sonidocontrol.dialogosnivel.bossdialogostart();

				if(animpuertas1!=null){
					animpuertas1.SetTrigger("close");
				}
				if(animpuertas2!=null){
					animpuertas2.SetTrigger("close");
				}
				return;

			}
			shoterbolas.shoter = 1;
			return;

		} 
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
                if (hitanim!=null)
                {
                    hitanim.Play("hited", 0);
                }
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

				game_control.control.experience += 2;   

				bossdeadbehaviour ();
				this.gameObject.layer=14;
			}
		}
		if (collider.tag == "darksword" ) {

			if (isboss == true) {
				enemyhp -= 30;
				hpbar.fillAmount = enemyhp * 0.001f;
				bossanim2.Play ("hited", 0);  
				bossanim.SetTrigger("moveaway"); 
			} else {
				enemyhp -= enemyhp;
                if (hitanim != null)
                {
                    hitanim.Play("hited", 0);
                }
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
				game_control.control.experience += 2;
				bossdeadbehaviour ();
				this.gameObject.layer=14;
			}
		}
		if (collider.tag == "holysword" ) {

			if (isboss == true) {
				enemyhp -= 60;
				hpbar.fillAmount = enemyhp * 0.001f;
				bossanim2.Play ("hited", 0);  
				bossanim.SetTrigger("moveaway"); 
			} else {
				enemyhp -= enemyhp;
                if (hitanim != null)
                {
                    hitanim.Play("hited", 0);
                }
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
				game_control.control.experience += 2;
				bossdeadbehaviour ();
				this.gameObject.layer=14;
			}
		}

	}
	void bossdeadbehaviour(){
		if (newbosstype == true) {
			if (isboss == true) {
				bossdead = true;
				bossanim2.enabled=false; 
				bossanim.Play("die"); 

				if(shoterbolasboss!=null){
					shoterbolasboss.shoter=0; 
				}
				if(shoterbolascirculares!=null){
					shoterbolascirculares.shoter = 0; 
				}

				if (game_control.control.isbossrush == 1) {
					game_control.control.bosrushactual+=1;
					game_control.control.health = 100;
					game_control.control.energy = 100;
					if (game_control.control.bosrushactual < game_control.control.bossrushscenes.dialogos.Length) {
						game_control.control.change_levelsecure (game_control.control.bossrushscenes.dialogos [game_control.control.bosrushactual]);
					} else {
						game_control.control.bossrushcelared = 1;
                        game_control.control.armorunlocked = 5;
                        game_control.control.save_Espsetup(); 
						game_control.control.Save_playerdata();
						game_control.control.change_levelsecure("ge_archivo");
					}

				} else {

					if(animpuertas1!=null){
						animpuertas1.SetTrigger("open");
					}
					if(animpuertas2!=null){
						animpuertas2.SetTrigger("open");
					}
					//opendoors and invoqueorb

				}


			}

		} else {
			if (isboss == true) {
				
				bossanim.enabled=false; 
				bossanim2.enabled=false; 

				if(shoterbolasboss!=null){
					shoterbolasboss.shoter=0; 
				}
				if(shoterbolascirculares!=null){
					shoterbolascirculares.shoter = 0; 
				}
				Renderer[] bossrenderers = this.gameObject.GetComponentsInChildren<Renderer>();  
				foreach(Renderer rend in bossrenderers){
					rend.enabled = false; 
				}
				game_control.control.experience += 100;

				game_control.control.health = 100;
				game_control.control.energy = 100;
				if (game_control.control.isbossrush == 1) {
					game_control.control.bosrushactual+=1;
					if (game_control.control.bosrushactual < 8) {
						game_control.control.change_levelsecure (game_control.control.bossrushscenes.dialogos [game_control.control.bosrushactual]);
					} else {
						game_control.control.bossrushcelared = 1;
						game_control.control.save_Espsetup(); 
						game_control.control.Save_playerdata();
						game_control.control.change_levelsecure("ge_archivo");
					}

				} else {
					
					game_control.control.vidas = 5;
					game_control.control.change_levelsecure(game_control.control.cinematico1); 
				}

			}
		}

	}
	IEnumerator ChangeLevel(string scene){
		float fadeTime= GameObject.Find("game control").GetComponent<Fading>().BeginFade(1);
		yield return new WaitForSeconds(fadeTime);
		Application.LoadLevel(scene);

	}
	public void damegbyomega(){
		if (isboss == true) {
			enemyhp -= 800;
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
			game_control.control.experience += 2;
			bossdeadbehaviour ();
			this.gameObject.layer=14;
		}
	}
}
