package com.lea.CowApp;

import com.lea.Models.Cow;
import com.lea.Utils.ConsoleReader;

import java.util.Date;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class CowApp {

    private static final String SPLIT_LINE = "--------------------------------";
    private boolean isRunning;
    private Map<Integer, CowAppAction> appActions;
    private ConsoleReader consoleReader;
    private CowDataManager cowDataManager;

    public CowApp() {
        isRunning = true;
        appActions = new HashMap<>();
        for (CowAppAction action : CowAppAction.values()) {
            appActions.put(action.getActionKey(), action);
        }
        consoleReader = new ConsoleReader();
        cowDataManager = new CowDataManager();
    }

    public void showMenu() {
        System.out.println(SPLIT_LINE);
        System.out.println("Available actions:");
        for (CowAppAction act : appActions.values()) {
            System.out.println(act.getDisplay());
        }
        int response;
        do {
            response =  consoleReader.readInt("Choose action: ");
        } while (isInvalidActionKey(response));
        System.out.println(SPLIT_LINE);
        doAction(appActions.get(response));
    }

    private void doAction(CowAppAction action) {
        switch (action) {
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
                break;
        }
    }

    private void printCows() {
        System.out.println("PRINTING COWS...");
        List<Cow> cows = cowDataManager.getAllCows();
        if (cows == null || cows.size() == 0) {
            System.out.println("No data...");
        } else {
            cows.forEach(System.out::println);
        }
    }

    private void enterCow() {
        System.out.println("ENTERING A NEW COW...");
        String name = consoleReader.readString("Enter name: ");
        String breed = consoleReader.readString("Enter breed: ");
        Date dob = consoleReader.readValidDate("Enter date of birth [yyyy-MM-dd]: ");
        Date doa = consoleReader.readValidDate("Enter date of arrival [yyyy-MM-dd]: ");
        int numCalf = consoleReader.readInt("Enter number of calf: ");
        String vetId = consoleReader.readString("Enter veterinary ID: ");
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
        cowDataManager.exportCowDataToTextFile();
    }

    private boolean isInvalidActionKey(int response) {
        for (CowAppAction action : appActions.values()) {
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
