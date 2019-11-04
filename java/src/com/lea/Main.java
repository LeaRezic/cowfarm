package com.lea;

import com.lea.CowApp.CowApp;

public class Main {

    public static void main(String[] args) {
        System.out.println("Program starting...");
        CowApp app = new CowApp();
        while (app.isRunning()) {
            app.showMenu();
        }
        System.out.println("Shutting down...");
    }
}
