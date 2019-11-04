package com.lea.CowApp;

import com.lea.Models.Cow;
import com.lea.Utils.ConsoleReader;

import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.List;

public class CowApp {

    private static final String SPLIT_LINE = "--------------------------------";
    private boolean isRunning;
    private HashMap<Integer, CowAppActions> appActions;
    private ConsoleReader reader;
    private CowDataManager cowDataManager;
    private ArrayList<Cow> cows;

    public CowApp() {
        isRunning = true;
        appActions = new HashMap<>();
        for (CowAppActions act : CowAppActions.values()) {
            appActions.put(act.getActionKey(), act);
        }
        reader = new ConsoleReader();
        cowDataManager = new CowDataManager();
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
            case EXPORT_DATA:
                exportData();
                break;
            default:
                return;
        }
    }

    private void printCows() {
        System.out.println("PRINTING COWS...");
        cows = (ArrayList<Cow>) cowDataManager.getAllCows();
        cows.forEach(System.out::println);
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

    private void exportData() {
        System.out.println("EXPORTING (super duper sorted) DATA TO A TEXT FILE (another file)...");
        List<Cow> cows = cowDataManager.getAllCows();
        cowDataManager.exportCowDataToTextFile(cows);
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
