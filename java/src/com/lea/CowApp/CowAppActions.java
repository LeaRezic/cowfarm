package com.lea.CowApp;

public enum CowAppActions {
    EXIT(0, "Exit Program"),
    PRINT_COWS(1, "Print Cows"),
    ENTER_COW(2, "Enter new Cow");

    private final int actionKey;
    private final String actionMessage;

    CowAppActions(int actionKey, String message) {
        this.actionKey = actionKey;
        this.actionMessage = message;
    }

    public int getActionKey() {
        return actionKey;
    }

    public String getActionMessage() {
        return actionMessage;
    }

    public String getDisplay() {
        return String.format("[%d] %s", getActionKey(), getActionMessage());
    }

}
