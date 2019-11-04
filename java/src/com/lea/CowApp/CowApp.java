package com.lea.CowApp;

import com.lea.Models.Cow;
import com.lea.Utils.ConsoleReader;
import com.lea.Utils.CowReader;

import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;

public class CowApp {

    private static final String SPLIT_LINE = "--------------------------------";
    private boolean isRunning;
    private HashMap<Integer, CowAppActions> appActions;
    private ConsoleReader reader;
    private CowReader cowDataManager;
    private ArrayList<Cow> cows;

    public CowApp() {
        isRunning = true;
        appActions = new HashMap<>();
        for (CowAppActions act : CowAppActions.values()) {
            appActions.put(act.getActionKey(), act);
        }
        reader = new ConsoleReader();
        cowDataManager = new CowReader();
        cows = null;
    }

    public void showMenu() {
        System.out.println(SPLIT_LINE);
        System.out.println("Available actions:");
        for (CowAppActions act : appActions.values()) {
            System.out.println(act.getDisplay());
        }
        int response;
        do {
            response =  reader.readInt("Choose action: ");
        } while (isInvalidActionKey(response));
        System.out.println(SPLIT_LINE);
        doAction(appActions.get(response));
    }

    private void doAction(CowAppActions cowAppActions) {
        switch (cowAppActions) {
            case EXIT:
                isRunning = false;
                break;
            case PRINT_COWS:
                printCows();
                break;
            case ENTER_COW:
                enterCow();
                break;
            default:
                return;
        }
    }

    private void printCows() {
        System.out.println("PRINTING COWS...");
        if (cows == null) {
            cows = new ArrayList<>();
        }
        cows = (ArrayList<Cow>) cowDataManager.getCowsFromFile();
        cows.forEach(cow -> System.out.println(cow.getName() + " " + cow.getBreed() + " " + cow.getVeterinaryId()));
    }

    private void enterCow() {
        System.out.println("ENTERING A NEW COW...");
        String name = reader.readString("Enter name: ");
        String breed = reader.readString("Enter breed: ");
        Date dob = reader.readValidDate("Enter date of birth [yyyy-MM-dd]: ");
        Date doa = reader.readValidDate("Enter date of arrival [yyyy-MM-dd]: ");
        int numCalf = reader.readInt("Enter number of calf: ");
        String vetId = reader.readString("Enter veterinary ID: ");
        Cow cow = new Cow(
                0,
                name,
                breed,
                dob,
                doa,
                numCalf,
                vetId
        );
        cowDataManager.addCow(cow);
    }

    private boolean isInvalidActionKey(int response) {
        for (CowAppActions action : appActions.values()) {
            if (action.getActionKey() == response) {
                return false;
            }
        }
        return true;
    }

    public boolean isRunning() {
        return isRunning;
    }
}
