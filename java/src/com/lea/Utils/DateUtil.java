package com.lea.Utils;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;

public class DateUtil {

    private static final String DATE_FORMAT = "yyyy-MM-dd";

    public String getStringFromDate(Date date) {
        SimpleDateFormat sdf = new SimpleDateFormat(DATE_FORMAT);
        return sdf.format(date);
    }

    public Date getDateFromString(String date) throws ParseException {
        SimpleDateFormat sdf = new SimpleDateFormat(DATE_FORMAT);
        return sdf.parse(date);
    }

    public boolean validateDateNotInFuture(Date date) {
        return date.compareTo(new Date()) <= 0;
    }

    public boolean validateDateStringNotInFuture(String date) {
        return date.compareTo(getStringFromDate(new Date())) <= 0;
    }

    public boolean validateDateStringNotBefore2000(String date) {
        return date.compareTo("2000-01-01") >= 0;
    }

}
