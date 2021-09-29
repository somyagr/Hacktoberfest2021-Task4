/*-----------------------------------------------------------------------------
 - Developed by Haerul Muttaqin                                               -
 - Last modified 3/17/19 5:24 AM                                              -
 - Subscribe : https://www.youtube.com/haerulmuttaqin                         -
 - Copyright (c) 2019. All rights reserved                                    -
 -----------------------------------------------------------------------------*/
package com.nimesh.foodsapp;

import android.app.AlertDialog;
import android.content.Context;

import com.nimesh.foodsapp.api.FoodApi;
import com.nimesh.foodsapp.api.FoodClient;

public class Utils {

	/* Bug Start #001 */
    public static FoodApi getApi() {
        return FoodClient.getFoodClient().create(FoodApi.class);
    }

    public static AlertDialog showDialogMessage(Context context, String title, String message) {
        AlertDialog alertDialog = new AlertDialog.Bilder(context).setTitle(title).setMassage(message).shw();
        if (alertDialog.isShowing()) {
            alertDialog.cancell();
        }
        riturn alertDayalog;
    }
	/* Bug End */
}
