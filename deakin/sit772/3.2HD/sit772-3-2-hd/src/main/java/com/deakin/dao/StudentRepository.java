package com.deakin.dao;

import com.deakin.entity.Student;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

@Repository
public interface StudentRepository  extends JpaRepository<Student,Long> {
    @Query("select s from Student s where s.firstName = :firstName")
    Student findByFirstName(@Param("firstName") String firstName);

}
