package com.lea.Models;

import java.util.Date;

public class Cow implements Comparable<Cow> {
    private int cowId;
    private String name;
    private String breed;
    private Date dateOfBirth;
    private Date dateOfArrival;
    private int numberOfCalf;
    private String veterinaryId;

    @Override
    public int compareTo(Cow o) {
        return this.getVeterinaryId().compareTo(o.getVeterinaryId());
    }

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


    public String getBreed() {
        return breed;
    }


    public Date getDateOfBirth() {
        return dateOfBirth;
    }


    public Date getDateOfArrival() {
        return dateOfArrival;
    }


    public int getNumberOfCalf() {
        return numberOfCalf;
    }


    public String getVeterinaryId() {
        return veterinaryId;
    }

    @Override
    public String toString() {
        return  name + ", " + breed + ", vetID: " + veterinaryId;
    }

}
