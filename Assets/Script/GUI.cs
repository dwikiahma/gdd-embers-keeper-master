using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlay(){
            
		    SceneManager.LoadScene("Stage1");
            saveLevel(1);
	}
	public void OnResume(){
		int level=LoadLevel();
        if(level==1){
			SceneManager.LoadScene("Stage1");
		}else if(level==2){
			SceneManager.LoadScene("Stage2");
		}else if(level==3){
			SceneManager.LoadScene("Stage3");
		}
	}
    public void OnRetry(){
        if(LoadLevel()==2){
            SceneManager.LoadScene("Stage2");
        }
        else{
            SceneManager.LoadScene("Stage1");
        }
    }
    public void OnMenu(){
		    SceneManager.LoadScene("Menu");
	}
    void OnCollisionEnter2D(Collision2D coll){
		if(coll.gameObject.tag == "Player"){
			int level=LoadLevel();
			if(level==1){
				SceneManager.LoadScene("Stage2");
			}else if(level==2){
				SceneManager.LoadScene("Stage3");
			}else if(level==3){
				SceneManager.LoadScene("Ending");
			}
            saveLevel(level+1);
		}
	}
    public static int LoadLevel(){
		int hg =0;
		if(!PlayerPrefs.HasKey("level")){
			PlayerPrefs.SetInt("level",0);
		}else{
			hg=PlayerPrefs.GetInt("level");
		}
		return hg;
	}
	public static void saveLevel(int lvl){
		if(!PlayerPrefs.HasKey("level")){
			PlayerPrefs.SetInt("level",0);
		}else{
			PlayerPrefs.SetInt("level",lvl);
		}
	}
}
