package com.deakin.entity;

import lombok.Data;
import lombok.NoArgsConstructor;

import javax.persistence.*;

@Entity
@Table(name = "students")
@Data
@NoArgsConstructor
public class Student {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private long id;
    private String firstName;
    private String surname;

    public Student(int i) {
        this.firstName = "test first name-"+i;
        this.surname = "test surname-"+i;
    }
}
