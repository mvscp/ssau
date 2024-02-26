package com.example.androidstudio2dgamedevelopment.gameobject;

import android.content.Context;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.Canvas;
import android.support.v4.content.ContextCompat;

import com.example.androidstudio2dgamedevelopment.GameDisplay;
import com.example.androidstudio2dgamedevelopment.GameLoop;
import com.example.androidstudio2dgamedevelopment.R;

public class Spell extends Circle {
    public static final double SPEED_PIXELS_PER_SECOND = 800.0;
    private static final double MAX_SPEED = SPEED_PIXELS_PER_SECOND / GameLoop.MAX_UPS;
    private Bitmap bitmap;

    public Spell(Context context, Player spellcaster) {
        super(
            context,
            ContextCompat.getColor(context, R.color.spell),
            spellcaster.getPositionX(),
            spellcaster.getPositionY(),
      25
        );
        velocityX = spellcaster.getDirectionX()*MAX_SPEED;
        velocityY = spellcaster.getDirectionY()*MAX_SPEED;
        bitmap = BitmapFactory.decodeResource(context.getResources(), R.drawable.vector1);
    }

    @Override
    public void update() {
        positionX = positionX + velocityX;
        positionY = positionY + velocityY;
    }
    @Override
    public void draw(Canvas canvas, GameDisplay gameDisplay) {
        /*canvas.drawCircle(
                (float) gameDisplay.gameToDisplayCoordinatesX(positionX),
                (float) gameDisplay.gameToDisplayCoordinatesY(positionY),
                (float) radius,
                paint
        );*/
        canvas.drawBitmap(bitmap, (float) gameDisplay.gameToDisplayCoordinatesX(positionX),
                (float) gameDisplay.gameToDisplayCoordinatesY(positionY), null);
    }
}
