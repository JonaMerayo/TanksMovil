using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrationClass : MonoBehaviour
{
    public static VibrationClass SharedInstance;    
    public static AndroidJavaObject vibrator=null;
    public static AndroidJavaClass vibrationEffectClass=null;

    private void Awake(){
        SharedInstance = this;
    }

    private void Start(){

        //Inicializar referencias vibración
        using (AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        using (AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))
        {
            if (currentActivity != null){
                vibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator");
                vibrationEffectClass = new AndroidJavaClass("android.os.VibrationEffect");
            }
        }
    
    }

    public AndroidJavaClass getvibrationEffectClass(){
        return vibrationEffectClass;
    }
    
    public AndroidJavaObject getVibrator(){
        return vibrator;
    }

    
}
