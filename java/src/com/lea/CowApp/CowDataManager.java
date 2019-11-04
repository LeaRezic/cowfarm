package com.lea.CowApp;

import com.lea.Models.Cow;
import com.lea.Utils.DateUtil;

import java.io.*;
import java.nio.file.FileSystems;
import java.text.ParseException;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class CowDataManager {

    private static final String FILE_PATH_DATA = "src/com/lea/resources/cowData.txt";
    private static final String FILE_PATH_EXPORT = "src/com/lea/resources/export.txt";
    private static final String DELIMITER = "\\|";
    private static final char DELIMITER_CHAR = '|';
    private static final String IGNORE_LINE = "#";

    private DateUtil dateUtil;

    public CowDataManager() {
        dateUtil = new DateUtil();
    }

    public List<Cow> getAllCows() {
        List<Cow> cows = new ArrayList<>();
        String absolutePath = FileSystems.getDefault().getPath(FILE_PATH_DATA).normalize().toAbsolutePath().toString();
        try (BufferedReader bufferedReader = new BufferedReader(new InputStreamReader(new FileInputStream(absolutePath)))) {
            String line;
            while ((line = bufferedReader.readLine()) != null) {
                if (line.startsWith(IGNORE_LINE) || line.trim().equals("")) {
                    continue;
                }
                Cow cow = getCowFromLine(line);
                if (cow == null) {
                    System.out.println(String.format("Error while parsing line: %s", line));
                } else {
                    cows.add(cow);
                }
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
        return cows;
    }

    private Cow getCowFromLine(String line) {
        String[] details = line.split(DELIMITER);
        try {
            return new Cow(
                    Integer.parseInt(details[0]),
                    details[1],
                    details[2],
                    dateUtil.getDateFromString(details[3]),
                    dateUtil.getDateFromString(details[4]),
                    Integer.parseInt(details[5]),
                    details[6]
            );
        } catch (ParseException e) {
            System.out.println(String.format("Parsing error on line: %s", line));
            return null;
        }
    }

    public void addCow(Cow cow) {
        cow.setCowId(getNextCowId());
        String newCowLine = getLineFromCow(cow);
        String absolutePath = FileSystems.getDefault().getPath(FILE_PATH_DATA).normalize().toAbsolutePath().toString();
        try (PrintWriter out = new PrintWriter(new BufferedWriter(new FileWriter(absolutePath, true)))) {
            out.println(newCowLine);
        } catch (IOException e) {
            System.err.println(e);
        }
    }

    private String getLineFromCow(Cow cow) {
        StringBuilder sb = new StringBuilder();
        sb.append(cow.getCowId())
                .append(DELIMITER_CHAR)
                .append(cow.getName())
                .append(DELIMITER_CHAR)
                .append(cow.getBreed())
                .append(DELIMITER_CHAR)
                .append(dateUtil.getStringFromDate(cow.getDateOfBirth()))
                .append(DELIMITER_CHAR)
                .append(dateUtil.getStringFromDate(cow.getDateOfArrival()))
                .append(DELIMITER_CHAR)
                .append(cow.getNumberOfCalf())
                .append(DELIMITER_CHAR)
                .append(cow.getVeterinaryId());
        return sb.toString();
    }

    private int getNextCowId() {
        int id = 0;
        for (Cow cow : getAllCows()) {
            if (cow.getCowId() >= id) {
                id = cow.getCowId() + 1;
            }
        }
        return id;
    }

    public void exportCowDataToTextFile() {
        List<Cow> cows = getAllCows();
        Collections.sort(cows);
        String absolutePath = FileSystems.getDefault().getPath(FILE_PATH_EXPORT).normalize().toAbsolutePath().toString();
        try (PrintWriter out = new PrintWriter(new BufferedWriter(new FileWriter(absolutePath)))) {
            for (Cow cow : cows) {
                String line = getLineFromCow(cow);
                out.println(line);
            }
        } catch (IOException e) {
            System.err.println(e);
        }
    }
}