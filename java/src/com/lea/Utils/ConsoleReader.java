package com.lea.Utils;

import java.text.ParseException;
import java.util.Date;
import java.util.Scanner;

public class ConsoleReader {

    private Scanner scanner;
    private DateUtil dateUtil;

    public ConsoleReader() {
        scanner = new Scanner(System.in);
        dateUtil = new DateUtil();
    }

    public String readString(String message) {
        String input;
        do {
            System.out.print(message);
            input = scanner.next();
        } while (input == null || input.trim().equals(""));
        return input;
    }

    public Date readValidDate(String message) {
        String input;
        do {
            System.out.print(message);
            input = scanner.next();
        } while(!isDateString(input));
        try {
            return dateUtil.getDateString(input);
        } catch (ParseException e) {
            e.printStackTrace();
            return null;
        }
    }

    public int readInt(String message) {
        String input;
        do {
            System.out.print(message);
            input = scanner.next();
        } while (!isInteger(input));
        return Integer.parseInt(input);
    }

    private boolean isInteger(String string) {
        try {
            Integer.valueOf(string);
            return true;
        } catch (NumberFormatException e) {
            return false;
        }
    }

    private boolean isDateString(String string) {
        try {
            dateUtil.getDateString(string);
            return true;
        } catch (ParseException e) {
            return false;
        }
    }
}
