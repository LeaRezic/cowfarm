package com.lea.Models;

import java.util.Date;

public class Cow {
    private int cowId;
    private String name;
    private String breed;
    private Date dateOfBirth;
    private Date dateOfArrival;
    private int numberOfCalf;
    private String veterinaryId;

    public Cow(int cowId, String name, String breed, Date dateOfBirth, Date dateOfArrival, int numberOfCalf, String veterinaryId) {
        this.cowId = cowId;
        this.name = name;
        this.breed = breed;
        this.dateOfBirth = dateOfBirth;
        this.dateOfArrival = dateOfArrival;
        this.numberOfCalf = numberOfCalf;
        this.veterinaryId = veterinaryId;
    }

    public int getCowId() {
        return cowId;
    }

    public void setCowId(int cowId) {
        this.cowId = cowId;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getBreed() {
        return breed;
    }

    public void setBreed(String breed) {
        this.breed = breed;
    }

    public Date getDateOfBirth() {
        return dateOfBirth;
    }

    public void setDateOfBirth(Date dateOfBirth) {
        this.dateOfBirth = dateOfBirth;
    }

    public Date getDateOfArrival() {
        return dateOfArrival;
    }

    public void setDateOfArrival(Date dateOfArrival) {
        this.dateOfArrival = dateOfArrival;
    }

    public int getNumberOfCalf() {
        return numberOfCalf;
    }

    public void setNumberOfCalf(int numberOfCalf) {
        this.numberOfCalf = numberOfCalf;
    }

    public String getVeterinaryId() {
        return veterinaryId;
    }

    public void setVeterinaryId(String veterinaryId) {
        this.veterinaryId = veterinaryId;
    }
}
