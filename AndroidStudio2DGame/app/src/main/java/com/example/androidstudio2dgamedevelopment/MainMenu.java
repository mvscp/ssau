package com.example.androidstudio2dgamedevelopment;

import android.content.Intent;
import android.content.pm.ActivityInfo;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.view.Window;
import android.view.WindowManager;
import android.widget.Button;
import android.widget.Toast;

//import androidx.appcompat.app.AppCompatActivity;

public class MainMenu extends AppCompatActivity {

    private long backPressedTime;
    private Toast backToast;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.mainmenu);

        Button button_campaign = (Button)findViewById(R.id.button_campaign);
        button_campaign.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                try {
                    Intent intent = new Intent(MainMenu.this, Campaign.class);
                    startActivity(intent); finish();
                }catch (Exception e) {

                }
            }
        });

        Button button_settings = (Button)findViewById(R.id.button_settings);
        button_settings.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                try {
                    Intent intent = new Intent(MainMenu.this, Settings.class);
                    startActivity(intent); finish();
                }catch (Exception e) {

                }
            }
        });

        Button button_exit = (Button)findViewById(R.id.button_exit);
        button_exit.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                MainMenu.super.onBackPressed();
            }
        });

        Window w = getWindow();
        w.setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN, WindowManager.LayoutParams.FLAG_FULLSCREEN);
    }
    @Override
    public void onBackPressed(){
        if (backPressedTime + 2000 > System.currentTimeMillis()){
            backToast.cancel();
            super.onBackPressed();
            return;
        }else{
            backToast = Toast.makeText(getBaseContext(), "Нажмите еще раз, чтобы выйти", Toast.LENGTH_SHORT);
            backToast.show();
        }
        backPressedTime = System.currentTimeMillis();
    }
}